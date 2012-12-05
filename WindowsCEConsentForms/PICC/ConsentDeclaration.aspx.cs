using System;
using WindowsCEConsentForms.FormHandlerService;

namespace WindowsCEConsentForms.PICC
{
    public partial class PICCConsentDeclaration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DeclarationSignatures.BtnCompleted.Click += BtnCompleted_Click;
        }

        protected void BtnCompleted_Click(object sender, EventArgs e)
        {
            try
            {
                //validation

                const ConsentType consentType = ConsentType.PICC;

                DeclarationSignatures.LblError.Text = string.Empty;

                DeclarationSignatures.ValidateForm();

                if (!string.IsNullOrEmpty(DeclarationSignatures.LblError.Text))
                    return;

                // uploading images here
                string patientId = string.Empty;
                try
                {
                    patientId = Session["PatientID"].ToString();
                }
                catch (Exception)
                {
                    Response.Redirect("/PatientConsent.aspx");
                }

                // validation for other procedure

                var formHandlerServiceClient = new FormHandlerServiceClient();

                DeclarationSignatures.SaveForm(formHandlerServiceClient, patientId);

                string ip = Request.ServerVariables["REMOTE_ADDR"];
                string device;
                if (Request.Browser.IsMobileDevice)
                    device = Request.Browser.Browser + " " + Request.Browser.Version;
                else
                    device = Request.Browser.Browser + " " + Request.Browser.Version;

                formHandlerServiceClient.UpdateTrackingInfo(patientId, new TrackingInfo { IP = ip, Device = device }, consentType.ToString());
                Utilities.GeneratePdfAndUploadToSharePointSite(formHandlerServiceClient, consentType, patientId);

                Response.Redirect("/PatientConsent.aspx");
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}