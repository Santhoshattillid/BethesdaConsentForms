using System;
using System.Text;
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

                if (DeclarationSignatures.ChkPatientisUnableToSign.Checked || DeclarationSignatures.ChkTelephoneConsent.Checked)
                {
                    if (string.IsNullOrEmpty(DeclarationSignatures.TxtPatientNotSignedBecause.Text.Trim()))
                        DeclarationSignatures.LblError.Text += " <br /> Please input reason for why patient not able sign.";

                    if (string.IsNullOrEmpty(Request.Form[SignatureType.PatientAuthorizeSign.ToString()]))
                        DeclarationSignatures.LblError.Text += " <br /> Please input patient authorized person signature.";
                }
                else
                {
                    if (string.IsNullOrEmpty(Request.Form[SignatureType.PatientSign.ToString()]))
                        DeclarationSignatures.LblError.Text += " <br /> Please input patient  signature.";
                }

                if (string.IsNullOrEmpty(Request.Form[SignatureType.WitnessSignature1.ToString()]))
                    DeclarationSignatures.LblError.Text += " <br /> Please input witness signature.";

                if (DeclarationSignatures.ChkTelephoneConsent.Checked && string.IsNullOrEmpty(Request.Form[SignatureType.WitnessSignature2.ToString()]))
                    DeclarationSignatures.LblError.Text += " <br /> Please input witness 2 signature.";

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

                if (Request.Form[SignatureType.PatientSign.ToString()] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.PatientSign.ToString()]);
                    var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), consentType.ToString(), SignatureType.PatientSign.ToString());
                }

                if (Request.Form[SignatureType.PatientAuthorizeSign.ToString()] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.PatientAuthorizeSign.ToString()]); // Patient Signature
                    var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), consentType.ToString(), SignatureType.PatientAuthorizeSign.ToString());
                }

                // updating signature5
                if (Request.Form[SignatureType.WitnessSignature1.ToString()] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.WitnessSignature1.ToString()]);
                    var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), consentType.ToString(), SignatureType.WitnessSignature1.ToString());
                }

                // updating signature6
                if (Request.Form[SignatureType.WitnessSignature2.ToString()] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.WitnessSignature2.ToString()]);
                    var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), consentType.ToString(), SignatureType.WitnessSignature2.ToString());
                }

                if (Request.Form[SignatureType.PICCSignature.ToString()] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.PICCSignature.ToString()]);
                    var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), consentType.ToString(), SignatureType.PICCSignature.ToString());
                }

                string ip = Request.ServerVariables["REMOTE_ADDR"];
                string device;
                if (Request.Browser.IsMobileDevice)
                    device = Request.Browser.Browser + " " + Request.Browser.Version;
                else
                    device = Request.Browser.Browser + " " + Request.Browser.Version;

                formHandlerServiceClient.UpdateTrackingInfo(patientId, new TrackingInfo { IP = ip, Device = device }, consentType.ToString());
                formHandlerServiceClient.UpdatePatientUnableSignReason(patientId, DeclarationSignatures.ChkPatientisUnableToSign.Checked ? DeclarationSignatures.TxtPatientNotSignedBecause.Text : string.Empty, consentType.ToString());

                formHandlerServiceClient.UpdateTranslatedby(patientId, consentType.ToString(), DeclarationSignatures.TxtTranslatedBy.Text);

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