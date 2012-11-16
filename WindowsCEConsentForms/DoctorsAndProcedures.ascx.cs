using System;
using System.Data;
using System.Web.UI.WebControls;
using WindowsCEConsentForms.ConsentFormsService;

namespace WindowsCEConsentForms
{
    public partial class DoctorsAndProcedures : System.Web.UI.UserControl
    {
        public ConsentType ConsentType;

        protected void Page_Load(object sender, EventArgs e)
        {
            var formHandlerServiceClient = new FormHandlerServiceClient();
            if (!IsPostBack)
            {
                DdLProcedures.Attributes["multiple"] = "multiple";
                DdLProcedures.Items.Clear();

                if (ConsentType == ConsentType.Endoscopy)
                {
                    foreach (string procedureName in formHandlerServiceClient.GetEndoscopyProcedurenameList())
                        DdLProcedures.Items.Add(procedureName.Trim());
                }
                else
                {
                    foreach (string procedureName in formHandlerServiceClient.GetProcedurenameList())
                        DdLProcedures.Items.Add(procedureName.Trim());
                }
                DdLProcedures.Items.Add("Other");

                DdlPrimaryDoctors.Items.Add("----Select Primary Doctor----");
                var physicians = formHandlerServiceClient.GetPrimaryPhysiciansList();
                if (physicians != null)
                {
                    foreach (DataRow row in physicians.Rows)
                    {
                        DdlPrimaryDoctors.Items.Add(new ListItem(row["Lname"] + ", " + row["Fname"],
                                                                 row["PhysicianId"].ToString()));
                    }
                }

                bool isItNewSession;
                try
                {
                    isItNewSession = (bool)Session["NewSessionFor" + ConsentType.ToString()];
                }
                catch (Exception)
                {
                    isItNewSession = true;
                }

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
                    var patientDetail = formHandlerServiceClient.GetPatientDetail(patientId);
                    if (patientDetail != null)
                    {
                        if (!isItNewSession)
                        {
                            if (!string.IsNullOrEmpty(patientDetail.PrimaryDoctorId))
                            {
                                DdlPrimaryDoctors.Items.FindByValue(patientDetail.PrimaryDoctorId).Selected = true;
                                LoadAssociatedDoctors(patientDetail.PrimaryDoctorId);
                            }
                            if (!string.IsNullOrEmpty(patientDetail.ProcedureName))
                            {
                                HdnSelectedProcedures.Value = patientDetail.ProcedureName;
                            }
                        }
                    }
                    else
                        DdlPrimaryDoctors.SelectedIndex = 0;
                }
            }
        }

        protected void DdlPrimaryDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            // load all the fields here
            try
            {
                // loading select form type box and patient details
                if (DdlPrimaryDoctors.SelectedIndex > 0)
                    LoadAssociatedDoctors(DdlPrimaryDoctors.SelectedValue);
            }
            catch (Exception)
            {
                return;
            }
        }

        private void LoadAssociatedDoctors(string primaryDoctorId)
        {
            //DdlAssociatedDoctors.Items.Clear();
            var formHandlerServiceClient = new FormHandlerServiceClient();
            var associatedDoctors = formHandlerServiceClient.GetAssociatedPhysiciansList(primaryDoctorId);

            //DdlAssociatedDoctors.Items.Add("----Select Associated Doctor----");
            LblAssociatedDoctors.Text = string.Empty;
            if (associatedDoctors != null)
            {
                foreach (DataRow row in associatedDoctors.Rows)
                {
                    //DdlAssociatedDoctors.Items.Add(new System.Web.UI.WebControls.ListItem(row["Lname"].ToString().Trim() + ", " + row["Fname"].ToString().Trim(), row["Id"].ToString().Trim()));
                    if (!string.IsNullOrEmpty(LblAssociatedDoctors.Text))
                        LblAssociatedDoctors.Text += " , ";
                    LblAssociatedDoctors.Text += row["Lname"].ToString().Trim() + " " + row["Fname"].ToString().Trim();
                }
            }
        }
    }
}