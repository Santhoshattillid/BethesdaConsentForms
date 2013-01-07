using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Configuration;
using WindowsCEConsentForms.FormHandlerService;

namespace WindowsCEConsentForms
{
    public partial class DoctorsAndProcedures : System.Web.UI.UserControl
    {
        public ConsentType ConsentType;

        public bool IsStaticTextBoxForPrecedures;

        protected void Page_Load(object sender, EventArgs e)
        {
            var formHandlerServiceClient = Utilities.GetConsentFormSvcClient();
            if (!IsPostBack)
            {
                var procedures = new List<string>();

                if (!IsStaticTextBoxForPrecedures)
                {
                    procedures.AddRange(from DataRow row in formHandlerServiceClient.GetProcedures(ConsentType).Rows select row["CFName"].ToString());
                    procedures.Add("Other");
                }

                ViewState["ListOfProcedures"] = procedures;

                var primaryDoctors = new List<PrimaryDoctor> { new PrimaryDoctor() { Id = 0, Name = "----Select Primary Doctor----" } };
                var physicians = formHandlerServiceClient.GetDoctorDetails(ConsentType);
                if (physicians != null)
                {
                    primaryDoctors.AddRange(physicians.Select(doctorDetails => new PrimaryDoctor { Name = doctorDetails.Lname + ", " + doctorDetails.Fname, Id = doctorDetails.ID }));
                }

                ViewState["PrimaryDoctors"] = primaryDoctors;

                var doctorsProceduresState = new DoctorsProceduresState
                {
                    SelectedDoctorsIndex = new[] { "0" },
                    SelectedProcedures = new[] { "" }
                };
                ViewState["DoctorsProceduresState"] = doctorsProceduresState;

                string patientId = string.Empty;
                try
                {
                    patientId = Session["PatientID"].ToString();
                }
                catch (Exception)
                {
                    Response.Redirect("/PatientConsent.aspx");
                }

                LblPatientName.Text = Utilities.GetPatientName(patientId, ConsentType.ToString()).name;
            }
            else
            {
                var doctorsProceduresState = new DoctorsProceduresState
                                                 {
                                                     SelectedDoctorsIndex = Request.Form["DdlPrimaryDoctors"].Split(','),
                                                     SelectedProcedures =
                                                         IsStaticTextBoxForPrecedures
                                                             ? Request.Form["TxtProcedures"].Split(',')
                                                             : Request.Form["HdnSelectedProcedures"].Split(','),
                                                 };
                ViewState["DoctorsProceduresState"] = doctorsProceduresState;
            }
        }

        public List<DoctorAndProcedure> GetDoctorsAndProcedures()
        {
            var outPut = new List<DoctorAndProcedure>();
            if (IsStaticTextBoxForPrecedures)
            {
                int index = 0;
                string[] primaryDoctors = Request.Form["DdlPrimaryDoctors"].Split(',');
                foreach (string procedure in Request.Form["TxtProcedures"].Split(','))
                {
                    if (primaryDoctors.GetUpperBound(0) > index - 1)
                    {
                        if (!string.IsNullOrEmpty(primaryDoctors[index]) && !string.IsNullOrEmpty(procedure))
                        {
                            outPut.Add(new DoctorAndProcedure { _primaryDoctorId = primaryDoctors[index], _precedures = procedure });
                        }
                        index++;
                    }
                    else
                        break;
                }
            }
            else
            {
                int index = 0;
                string[] primaryDoctors = Request.Form["DdlPrimaryDoctors"].Split(',');
                string[] otherProcedures = Request.Form["TxtOtherProcedure"].Split(',');
                foreach (string procedure in Request.Form["HdnSelectedProcedures"].Split(','))
                {
                    if (primaryDoctors.GetUpperBound(0) > index - 1)
                    {
                        if (!string.IsNullOrEmpty(primaryDoctors[index]) && !string.IsNullOrEmpty(procedure))
                        {
                            if (procedure.IndexOf("Other", StringComparison.Ordinal) > 0 && otherProcedures.GetUpperBound(0) > index - 1)
                                outPut.Add(new DoctorAndProcedure { _primaryDoctorId = primaryDoctors[index], _precedures = procedure.Replace("#Other", "#" + otherProcedures[index]) });
                            else
                                outPut.Add(new DoctorAndProcedure { _primaryDoctorId = primaryDoctors[index], _precedures = procedure });
                        }
                        index++;
                    }
                    else
                        break;
                }
            }
            return outPut;
        }

        public void Reset()
        {
            var doctorsProceduresState = new DoctorsProceduresState
            {
                SelectedDoctorsIndex = new[] { "0" },
                SelectedProcedures = new[] { "" }
            };
            ViewState["DoctorsProceduresState"] = doctorsProceduresState;
        }
    }

    [Serializable]
    public class PrimaryDoctor
    {
        public string Name { get; set; }

        public int Id { get; set; }
    }

    [Serializable]
    public class DoctorsProceduresState
    {
        public string[] SelectedDoctorsIndex;

        public string[] SelectedProcedures;
    }
}