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
                var procedures = new List<string>();
                if (!IsStaticTextBoxForPrecedures)
                {
                    //DdLProcedures.Attributes["multiple"] = "multiple";
                    //DdLProcedures.Items.Clear();
                    if (ConsentType == ConsentType.Endoscopy)
                    {
                        foreach (string procedureName in formHandlerServiceClient.GetEndoscopyProcedurenameList())
                            procedures.Add(procedureName);
                    }
                    else if (ConsentType == ConsentType.Cardiovascular)
                    {
                        foreach (string procedureName in formHandlerServiceClient.GetCardiovascularProcedurenameList())
                            procedures.Add(procedureName);
                    }
                    else
                    {
                        foreach (string procedureName in formHandlerServiceClient.GetProcedurenameList())
                            procedures.Add(procedureName);
                    }
                    procedures.Add("Other");

                    //DdLProcedures.Items.Add("Other");
                }

                ViewState["ListOfProcedures"] = procedures;

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

                //string patientId;
                //try
                //{
                //    patientId = Session["PatientID"].ToString();
                //}
                //catch (Exception)
                //{
                //    try
                //    {
                //        patientId = Request.QueryString["PatientId"];
                //    }
                //    catch (Exception)
                //    {
                //        patientId = string.Empty;
                //    }
                //}
                var doctorsProceduresState = new DoctorsProceduresState
                {
                    SelectedDoctorsIndex = new[] { "0" },
                    SelectedProcedures = new[] { "" }
                };

                //if (!string.IsNullOrEmpty(patientId))
                //{
                //var patientDetail = formHandlerServiceClient.GetPatientDetail(patientId, ConsentType.ToString());
                //LblPatientName.Text = patientDetail.name;
                //}
                ViewState["DoctorsProceduresState"] = doctorsProceduresState;
            }
            else
            {
                var doctorsProceduresState = new DoctorsProceduresState
                                                 {
                                                     SelectedDoctorsIndex = Request.Form["DdlPrimaryDoctors"].Split(','),
                                                 };
                if (IsStaticTextBoxForPrecedures)
                    doctorsProceduresState.SelectedProcedures = Request.Form["TxtProcedures"].Split(',');
                else
                    doctorsProceduresState.SelectedProcedures = Request.Form["HdnSelectedProcedures"].Split(',');
                ViewState["DoctorsProceduresState"] = doctorsProceduresState;
            }
        }

        public void SaveDoctorsAndProcedures(FormHandlerServiceClient formHandlerServiceClient, string patientId)
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
                            outPut.Add(new DoctorAndProcedure() { _primaryDoctorId = primaryDoctors[index], _precedures = procedure });
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
            formHandlerServiceClient.SaveDoctorsDetails(patientId, ConsentType.ToString(), outPut.ToArray());
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