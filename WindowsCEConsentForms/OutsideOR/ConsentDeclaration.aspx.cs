using System;
using WindowsCEConsentForms.FormHandlerService;

namespace WindowsCEConsentForms.OutsideOR
{
    public partial class Declaration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DeclarationSignatures1.BtnCompleted.Click += BtnCompleted_Click;
            DeclarationSignatures1.BtnReset.Click += BtnReset_Click;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            ConsentSignatures1.ResetSignatures();

            DeclarationSignatures1.ResetSignatures();
            DeclarationSignatures1.ChkPatientisUnableToSign.Checked = false;
            DeclarationSignatures1.SetPanels(false);
        }

        protected void BtnCompleted_Click(object sender, EventArgs e)
        {
            try
            {
                const ConsentType consentType = ConsentType.OutsideOR;

                //validation
                var lblError = DeclarationSignatures1.LblError;

                lblError.Text = string.Empty;

                DeclarationSignatures1.ValidateForm();

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

                DeclarationSignatures1.SaveForm(formHandlerServiceClient, patientId);

                ConsentSignatures1.SaveForm(formHandlerServiceClient, patientId, consentType);

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
    }
}