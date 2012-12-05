using System;
using WindowsCEConsentForms.FormHandlerService;

namespace WindowsCEConsentForms.BloodConsentOrRefusal
{
    public partial class Consent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DeclarationSignatures.BtnCompleted.Click += BtnCompleted_Click;
            DeclarationSignatures.BtnReset.Click += BtnReset_Click;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            DeclarationSignatures.ResetSignatures();
            DeclarationSignatures.ChkPatientisUnableToSign.Checked = false;
            DeclarationSignatures.SetPanels(false);

            RdoStatementOfConsentAccepted.Checked = false;
            RdoStatementOfConsentRefusal.Checked = false;
        }

        protected void BtnCompleted_Click(object sender, EventArgs e)
        {
            try
            {
                const ConsentType consentType = ConsentType.BloodConsentOrRefusal;

                //validation
                var lblError = DeclarationSignatures.LblError;

                lblError.Text = string.Empty;

                DeclarationSignatures.ValidateForm();

                if (!string.IsNullOrEmpty(lblError.Text))
                {
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

                var formHandlerServiceClient = new FormHandlerServiceClient();

                DeclarationSignatures.SaveForm(formHandlerServiceClient, patientId);

                string ip = Request.ServerVariables["REMOTE_ADDR"];
                string device;
                if (Request.Browser.IsMobileDevice)
                    device = Request.Browser.Browser + " " + Request.Browser.Version;
                else
                    device = Request.Browser.Browser + " " + Request.Browser.Version;

                formHandlerServiceClient.UpdateTrackingInfo(patientId, new TrackingInfo { IP = ip, Device = device }, consentType.ToString());

                formHandlerServiceClient.UpdateConsentFormStatementType(patientId, RdoStatementOfConsentAccepted.Checked ? new StatementOfConsent() { AutologousUnits = ChkAutologousUnits.Checked, DirectedUnits = ChkDirectedUnits.Checked } : null, consentType.ToString());

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