using System;
using System.Collections.Generic;
using System.Text;
using WindowsCEConsentForms.ConsentFormsService;

namespace WindowsCEConsentForms.Surgical
{
    public partial class SurgicalConsentDeclaration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DeclarationSignatures.BtnCompleted.Click += BtnCompleted_Click;
            DeclarationSignatures.BtnReset.Click += BtnReset_Click;

            //var formHandlerServiceClient = new FormHandlerServiceClient();
            //if (!IsPostBack)
            //{
            //DdlPrimaryDoctors.Items.Add("----Select Primary Doctor----");
            //var physicians = formHandlerServiceClient.GetPrimaryPhysiciansList();
            //if (physicians != null)
            //{
            //    foreach (DataRow row in physicians.Rows)
            //    {
            //        DdlPrimaryDoctors.Items.Add(new ListItem(row["Lname"] + ", " + row["Fname"],
            //                                                 row["PhysicianId"].ToString()));
            //    }
            //}

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
            //if (!string.IsNullOrEmpty(patientId))
            //{
            //    var patientDetail = formHandlerServiceClient.GetPatientDetail(patientId, ConsentType.Surgical.ToString());
            //    if (patientDetail != null)
            //    {
            //            if (!string.IsNullOrEmpty(patientDetail.PrimaryDoctorId))
            //            {
            //                //DdlPrimaryDoctors.Items.FindByValue(patientDetail.PrimaryDoctorId).Selected = true;
            //                //LoadAssociatedDoctors(patientDetail.PrimaryDoctorId);
            //            }
            //    }
            //    //else
            //    //    DdlPrimaryDoctors.SelectedIndex = 0;
            //}
            //}
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            //LblAssociatedDoctors.Text = string.Empty;
            //DdlPrimaryDoctors.SelectedIndex = 0;
            //TxtProcedure.Text = string.Empty;

            DeclarationSignatures.ResetSignatures();
            DeclarationSignatures.ChkPatientisUnableToSign.Checked = false;
            DeclarationSignatures.SetPanels(false);

            ConsentSignatures.ResetSignatures();
        }

        protected void BtnCompleted_Click(object sender, EventArgs e)
        {
            try
            {
                const ConsentType consentType = ConsentType.Surgical;

                //validation
                var lblError = DeclarationSignatures.LblError;

                DeclarationSignatures.ValidateForm();

                if (string.IsNullOrEmpty(Request.Form[SignatureType.DoctorSign1.ToString()]) ||
                   string.IsNullOrEmpty(Request.Form[SignatureType.DoctorSign2.ToString()]) ||
                   string.IsNullOrEmpty(Request.Form[SignatureType.DoctorSign3.ToString()]) ||
                   string.IsNullOrEmpty(Request.Form[SignatureType.DoctorSign4.ToString()]) ||
                   string.IsNullOrEmpty(Request.Form[SignatureType.DoctorSign5.ToString()]))
                {
                    lblError.Text += "Please input signatures.";
                }

                if (!string.IsNullOrEmpty(lblError.Text))
                    return;

                string patientId = string.Empty;
                try
                {
                    patientId = Session["PatientID"].ToString();
                }
                catch (Exception)
                {
                    Response.Redirect("/PatientConsent.aspx");
                }

                var formHandlerServiceClient = new FormHandlerServiceClient();

                DoctorsAndProcedures1.SaveDoctorsAndProcedures(formHandlerServiceClient, patientId);

                DeclarationSignatures.SaveForm(formHandlerServiceClient, patientId);

                if (Request.Form[SignatureType.DoctorSign1.ToString()] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.DoctorSign1.ToString()]);
                    bool result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), consentType.ToString(), SignatureType.DoctorSign1.ToString());
                }

                if (Request.Form[SignatureType.DoctorSign2.ToString()] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.DoctorSign2.ToString()]);
                    var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), consentType.ToString(), SignatureType.DoctorSign2.ToString());
                }

                if (Request.Form[SignatureType.DoctorSign3.ToString()] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.DoctorSign3.ToString()]);
                    var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), consentType.ToString(), SignatureType.DoctorSign3.ToString());
                }

                if (Request.Form[SignatureType.DoctorSign4.ToString()] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.DoctorSign4.ToString()]);
                    var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), consentType.ToString(), SignatureType.DoctorSign4.ToString());
                }

                if (Request.Form[SignatureType.DoctorSign5.ToString()] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.DoctorSign5.ToString()]);
                    var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), consentType.ToString(), SignatureType.DoctorSign5.ToString());
                }

                string ip = Request.ServerVariables["REMOTE_ADDR"];
                string device;
                if (Request.Browser.IsMobileDevice)
                    device = Request.Browser.Browser + " " + Request.Browser.Version;
                else
                    device = Request.Browser.Browser + " " + Request.Browser.Version;

                formHandlerServiceClient.UpdateTrackingInfo(patientId, new TrackingInfo { IP = ip, Device = device }, consentType.ToString());

                Utilities.GeneratePdfAndUploadToSharePointSite(formHandlerServiceClient, consentType, patientId);

                Response.Redirect(Utilities.GetNextFormUrl(consentType, Session));
            }
            catch (Exception)
            {
                return;
            }
        }

        //private void LoadAssociatedDoctors(string primaryDoctorId)
        //{
        //    //DdlAssociatedDoctors.Items.Clear();
        //    var formHandlerServiceClient = new FormHandlerServiceClient();
        //    var associatedDoctors = formHandlerServiceClient.GetAssociatedPhysiciansList(primaryDoctorId);

        //    //DdlAssociatedDoctors.Items.Add("----Select Associated Doctor----");
        //    LblAssociatedDoctors.Text = string.Empty;
        //    if (associatedDoctors != null)
        //    {
        //        foreach (DataRow row in associatedDoctors.Rows)
        //        {
        //            //DdlAssociatedDoctors.Items.Add(new System.Web.UI.WebControls.ListItem(row["Lname"].ToString().Trim() + ", " + row["Fname"].ToString().Trim(), row["Id"].ToString().Trim()));
        //            if (!string.IsNullOrEmpty(LblAssociatedDoctors.Text))
        //                LblAssociatedDoctors.Text += " , ";
        //            LblAssociatedDoctors.Text += row["Lname"].ToString().Trim() + " " + row["Fname"].ToString().Trim();
        //        }
        //    }
        //}
    }
}