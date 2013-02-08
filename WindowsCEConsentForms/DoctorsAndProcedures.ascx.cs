using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using WindowsCEConsentForms.ConsentFormSvc;

namespace WindowsCEConsentForms
{
    public partial class DoctorsAndProcedures : System.Web.UI.UserControl
    {
        public ConsentType consentType;

        public bool IsStaticTextBoxForPrecedures;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var formHandlerServiceClient = Utilities.GetConsentFormSvcClient();
                if (!IsPostBack)
                {
                    var procedures = new List<string>();

                    if (!IsStaticTextBoxForPrecedures)
                    {
                        procedures.AddRange(from DataRow row in formHandlerServiceClient.GetProcedures(consentType).Rows select row["CFName"].ToString());
                        if (consentType != ConsentType.Endoscopy)
                            procedures.Add("Other");
                    }

                    ViewState["ListOfProcedures"] = procedures;

                    var primaryDoctors = new List<PrimaryDoctor> { new PrimaryDoctor() { Id = 0, Name = "----Select Primary Doctor----" } };
                    var physicians = formHandlerServiceClient.GetDoctorDetails();
                    if (physicians != null)
                    {
                        primaryDoctors.AddRange(physicians.Select(doctorDetails => new PrimaryDoctor { Name = doctorDetails.Lname + ", " + doctorDetails.Fname, Id = doctorDetails.ID }));
                    }

                    ViewState["PrimaryDoctors"] = primaryDoctors;

                    var doctorsProceduresState = new DoctorsProceduresState
                    {
                        SelectedDoctorsIndex = new[] { "0" },
                        SelectedProcedures = new[] { "" },
                        OtherProcedures = new[] { "" }
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

                    LblPatientName.Text = Utilities.GetPatientName(patientId, consentType.ToString(), Session["Location"].ToString()).name;
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
                                                         OtherProcedures = Request.Form["TxtOtherProcedure"] != null ? Request.Form["TxtOtherProcedure"].Split(',') : new string[] { "" }
                                                     };
                    ViewState["DoctorsProceduresState"] = doctorsProceduresState;
                }
            }
            catch (Exception ex)
            {
                var client = Utilities.GetConsentFormSvcClient();
                client.CreateLog(Utilities.GetUsername(Session), LogType.E, GetType().Name + "-" + new StackTrace().GetFrame(0).GetMethod().ToString(),
                                 ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        public List<DoctorAndProcedure> GetDoctorsAndProcedures()
        {
            var outPut = new List<DoctorAndProcedure>();
            try
            {
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
            }
            catch (Exception ex)
            {
                var client = Utilities.GetConsentFormSvcClient();
                client.CreateLog(Utilities.GetUsername(Session), LogType.E, GetType().Name + "-" + new StackTrace().GetFrame(0).GetMethod().ToString(),
                                 ex.Message + Environment.NewLine + ex.StackTrace);
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

        public string[] OtherProcedures;
    }
}