using System;
using System.Data;
using System.Text;
using System.Web.UI.WebControls;
using WindowsCEConsentForms.ConsentFormsService;

namespace WindowsCEConsentForms.PICC
{
    public partial class PICCConsent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DdLProcedures.Attributes["multiple"] = "multiple";
                bool isItNewSession;
                try
                {
                    isItNewSession = (bool)Session["NewSessionPICCConsent"];
                }
                catch (Exception)
                {
                    isItNewSession = true;
                }

                for (int i = 0; i < 7; i++)
                    ViewState["Signature" + i] = string.Empty;

                var formHandlerServiceClient = new FormHandlerServiceClient();
                if (!IsPostBack)
                {
                    DdLProcedures.Items.Clear();

                    //DdLProcedures.Items.Add("--------Selected Procedures--------");
                    foreach (string procedureName in formHandlerServiceClient.GetProcedurenameList())
                        DdLProcedures.Items.Add(procedureName.Trim());
                    DdLProcedures.Items.Add("Other");
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

                        // Response.Redirect("/PatientConsent.aspx");
                    }
                }
                if (!IsPostBack)
                {
                    DdlPrimaryDoctors.Items.Add("----Select Primary Doctor----");
                    var physicians = formHandlerServiceClient.GetPrimaryPhysiciansList();
                    if (physicians != null)
                    {
                        foreach (DataRow row in physicians.Rows)
                        {
                            DdlPrimaryDoctors.Items.Add(new ListItem(row["Lname"] + ", " + row["Fname"], row["PhysicianId"].ToString()));
                        }
                    }
                    if (!string.IsNullOrEmpty(patientId))
                    {
                        var patientDetail = formHandlerServiceClient.GetPatientDetail(patientId, ConsentType.PICC.ToString());
                        if (patientDetail != null)
                        {
                            LblPatientName.Text = patientDetail.name;
                            LblDate.Text = patientDetail.AdmDate.ToString("MMM dd yyyy");
                            LblPatientMRId.Text = patientDetail.MRHash;
                            LblTime.Text = DateTime.Now.ToShortTimeString();
                            if (!isItNewSession)
                            {
                                LoadAssociatedDoctors(patientDetail.PrimaryDoctorId);
                                if (!string.IsNullOrEmpty(patientDetail.PrimaryDoctorId))
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
                if (!isItNewSession)
                {
                    // Loading Signatures based on the selected patient
                    ViewState["Signature1"] = formHandlerServiceClient.GetPatientSignature(patientId, ConsentType.PICC.ToString(), "signature1");
                    ViewState["Signature2"] = formHandlerServiceClient.GetPatientSignature(patientId, ConsentType.PICC.ToString(), "signature2");
                    ViewState["Signature3"] = formHandlerServiceClient.GetPatientSignature(patientId, ConsentType.PICC.ToString(), "signature3");
                    ViewState["Signature4"] = formHandlerServiceClient.GetPatientSignature(patientId, ConsentType.PICC.ToString(), "signature4");
                    ViewState["Signature5"] = formHandlerServiceClient.GetPatientSignature(patientId, ConsentType.PICC.ToString(), "signature5");
                }
            }
            catch (Exception)
            {
                Response.Redirect("/PatientConsent.aspx");
            }
        }

        protected void DdlPrimaryDoctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            // load all the fields here
            try
            {
                // loading select form type box and patient details
                if (DdlPrimaryDoctors.SelectedIndex > 0)
                {
                    LoadAssociatedDoctors(DdlPrimaryDoctors.SelectedValue);

                    //DdlAssociatedDoctors.SelectedIndex = 0;
                }
                else
                {
                    LblError.Text = "Please select primary doctor";

                    //DdlAssociatedDoctors.Items.Clear();
                }
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
            else
            {
                LblError.Text = "Associted doctors list not available.";
            }
        }

        protected void BtnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("/PatientConsent.aspx");
            }
            catch (Exception)
            {
                return;
            }
        }

        protected void BtnNext_Click(object sender, EventArgs e)
        {
            // need to save signatures here
            try
            {
                if (DdlPrimaryDoctors.SelectedIndex == 0) // || DdlAssociatedDoctors.SelectedIndex == 0)
                {
                    LblError.Text = "Please select primary and associated doctor";
                    return;
                }

                if (string.IsNullOrEmpty(HdnSelectedProcedures.Value))
                {
                    LblError.Text = "Please select the procedures and then go next.";
                    return;
                }

                if (string.IsNullOrEmpty(Request.Form["HdnImage1"]) || string.IsNullOrEmpty(Request.Form["HdnImage2"]) || string.IsNullOrEmpty(Request.Form["HdnImage3"]) || string.IsNullOrEmpty(Request.Form["HdnImage4"]) || string.IsNullOrEmpty(Request.Form["HdnImage5"]))

                //if (true)
                {
                    LblError.Text = "Please input your signatures in all the fields";
                    return;
                }

                string patientId = string.Empty;
                try
                {
                    patientId = Session["PatientID"].ToString();
                }
                catch (Exception)
                {
                    Response.Redirect("/PatientConsent.aspx");
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
                                LblError.Text = "Please input your signatures in all the fields";
                                return;
                            }
                            selectedProcedurenames += TxtOtherProcedure.Text;
                        }
                        else
                            selectedProcedurenames += procedurename + "#";
                    }
                }

                var formHandlerServiceClient = new FormHandlerServiceClient();

                formHandlerServiceClient.UpdateDoctorAssociation(patientId, DdlPrimaryDoctors.SelectedValue, LblAssociatedDoctors.Text, ConsentType.PICC.ToString());

                formHandlerServiceClient.UpdatePatientProcedures(patientId, selectedProcedurenames, ConsentType.PICC.ToString());

                // updating signature1
                var bytes = Encoding.ASCII.GetBytes(Request.Form["HdnImage1"]);
                bool result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), ConsentType.PICC.ToString(), "signature1");

                // updating signature2
                bytes = Encoding.ASCII.GetBytes(Request.Form["HdnImage2"]);
                result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), ConsentType.PICC.ToString(), "signature2");

                // updating signature3
                bytes = Encoding.ASCII.GetBytes(Request.Form["HdnImage3"]);
                result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), ConsentType.PICC.ToString(), "signature3");

                // updating signature4
                bytes = Encoding.ASCII.GetBytes(Request.Form["HdnImage4"]);
                result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), ConsentType.PICC.ToString(), "signature4");

                // updating signature4
                bytes = Encoding.ASCII.GetBytes(Request.Form["HdnImage5"]);
                result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), ConsentType.PICC.ToString(), "signature5");

                Session["NewSessionPICCConsent"] = false;

                Response.Redirect("/PICC/ConsentDeclaration.aspx");
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}