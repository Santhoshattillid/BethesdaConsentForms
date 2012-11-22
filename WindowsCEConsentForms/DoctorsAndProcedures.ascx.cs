using System;
using System.Collections.Generic;
using System.Data;
using WindowsCEConsentForms.ConsentFormsService;

namespace WindowsCEConsentForms
{
    public partial class DoctorsAndProcedures : System.Web.UI.UserControl
    {
        public ConsentType ConsentType;

        public bool IsStaticTextBoxForPrecedures;

        protected void Page_Load(object sender, EventArgs e)
        {
            var formHandlerServiceClient = new FormHandlerServiceClient();
            if (!IsPostBack)
            {
                if (!IsStaticTextBoxForPrecedures)
                {
                    DdLProcedures.Attributes["multiple"] = "multiple";
                    DdLProcedures.Items.Clear();
                    if (ConsentType == ConsentType.Endoscopy)
                    {
                        foreach (string procedureName in formHandlerServiceClient.GetEndoscopyProcedurenameList())
                            DdLProcedures.Items.Add(procedureName.Trim());
                    }
                    else if (ConsentType == ConsentType.Cardiovascular)
                    {
                        foreach (string procedureName in formHandlerServiceClient.GetCardiovascularProcedurenameList())
                            DdLProcedures.Items.Add(procedureName.Trim());
                    }
                    else
                    {
                        foreach (string procedureName in formHandlerServiceClient.GetProcedurenameList())
                            DdLProcedures.Items.Add(procedureName.Trim());
                    }
                    DdLProcedures.Items.Add("Other");
                }

                var primaryDoctors = new List<PrimaryDoctor>();
                primaryDoctors.Add(new PrimaryDoctor() { Id = 0, Name = "----Select Primary Doctor----" });
                var physicians = formHandlerServiceClient.GetPrimaryPhysiciansList();
                if (physicians != null)
                {
                    foreach (DataRow row in physicians.Rows)
                    {
                        primaryDoctors.Add(new PrimaryDoctor { Name = row["Lname"] + ", " + row["Fname"], Id = int.Parse(row["PhysicianId"].ToString()) });
                    }
                }

                ViewState["PrimaryDoctors"] = primaryDoctors;

                string patientId;
                try
                {
                    patientId = Session["PatientID"].ToString();
                }
                catch (Exception)
                {
                    try
                    {
                        patientId = Request.QueryString["PatientId"];
                    }
                    catch (Exception)
                    {
                        patientId = string.Empty;
                    }
                }
                if (!string.IsNullOrEmpty(patientId))
                {
                    var patientDetail = formHandlerServiceClient.GetPatientDetail(patientId, ConsentType.ToString());
                    if (patientDetail != null)
                    {
                        if (!string.IsNullOrEmpty(patientDetail.ProcedureName))
                        {
                            HdnSelectedProcedures.Value = patientDetail.ProcedureName;
                        }
                    }
                }
                var doctorsProceduresState = new DoctorsProceduresState
                {
                    SelectedDoctorsIndex = new[] { "0" },
                    Procedures = new[] { "" }
                };
                ViewState["DoctorsProceduresState"] = doctorsProceduresState;
            }
            else
            {
                var doctorsProceduresState = new DoctorsProceduresState
                                                 {
                                                     SelectedDoctorsIndex = Request.Form["DdlPrimaryDoctors"].Split(','),
                                                     Procedures = Request.Form["TxtProcedures"].Split(',')
                                                 };
                ViewState["DoctorsProceduresState"] = doctorsProceduresState;
            }
        }

        public List<TreamentDoctorsAndProcedures> GetDoctorsAndProcedures()
        {
            var outPut = new List<TreamentDoctorsAndProcedures>();
            if (IsStaticTextBoxForPrecedures)
            {
                int index = 0;
                string[] primaryDoctors = Request.Form["DdlPrimaryDoctors"].Split(',');
                foreach (string procedure in Request.Form["TxtProcedures"].Split(','))
                {
                    if (primaryDoctors.GetUpperBound(0) < index)
                    {
                        if (!string.IsNullOrEmpty(primaryDoctors[index]) && !string.IsNullOrEmpty(procedure))
                        {
                            outPut.Add(new TreamentDoctorsAndProcedures() { PrimaryDoctorId = primaryDoctors[index], TreatmentProcedures = procedure });

                            //if (string.IsNullOrEmpty(procedure))
                            //    throw new Exception("Please input your signatures in all the fields");
                        }
                        index++;
                    }
                    else
                        break;
                }
                return outPut;
            }

            string selectedProcedurenames = string.Empty;

            // validation for other procedure
            foreach (string procedurename in HdnSelectedProcedures.Value.Split('#'))
            {
                if (!string.IsNullOrEmpty(procedurename))
                {
                    if (procedurename.Trim().ToLower() == "other")
                    {
                        if (string.IsNullOrEmpty(TxtOtherProcedure.Text))
                        {
                            throw new Exception("Please input your signatures in all the fields");
                        }
                        selectedProcedurenames += TxtOtherProcedure.Text;
                    }
                    else
                        selectedProcedurenames += procedurename + "#";
                }
            }

            return outPut;
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

        public string[] Procedures;
    }

    public class TreamentDoctorsAndProcedures
    {
        public string PrimaryDoctorId;
        public string TreatmentProcedures;
    }
}