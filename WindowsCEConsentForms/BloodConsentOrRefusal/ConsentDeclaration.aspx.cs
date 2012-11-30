using System;
using System.Text;
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
                var chkPatientisUnableToSign = DeclarationSignatures.ChkPatientisUnableToSign;
                var txtPatientNotSignedBecause = DeclarationSignatures.TxtPatientNotSignedBecause;
                var chkTelephoneConsent = DeclarationSignatures.ChkTelephoneConsent;

                lblError.Text = string.Empty;

                if (chkPatientisUnableToSign.Checked || chkTelephoneConsent.Checked)
                {
                    if (string.IsNullOrEmpty(txtPatientNotSignedBecause.Text.Trim()))
                        lblError.Text += " <br /> Please input reason for why patient not able sign.";

                    if (string.IsNullOrEmpty(Request.Form[SignatureType.PatientAuthorizeSign.ToString()]))
                        lblError.Text += " <br /> Please input patient authorized person signature.";
                }
                else
                {
                    if (string.IsNullOrEmpty(Request.Form[SignatureType.PatientSign.ToString()]))
                        lblError.Text += " <br /> Please input patient  signature.";
                }

                if (string.IsNullOrEmpty(Request.Form[SignatureType.WitnessSignature1.ToString()]))
                    lblError.Text += " <br /> Please input witness signature.";

                if (DeclarationSignatures.ChkTelephoneConsent.Checked && string.IsNullOrEmpty(Request.Form[SignatureType.WitnessSignature2.ToString()]))
                    lblError.Text += " <br /> Please input witness 2 signature.";

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

                //formHandlerServiceClient.SaveDoctorsDetails(patientId, consentType.ToString(), DoctorsAndProcedures1.GetDoctorsAndProcedures().ToArray());

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

                string ip = Request.ServerVariables["REMOTE_ADDR"];
                string device;
                if (Request.Browser.IsMobileDevice)
                    device = Request.Browser.Browser + " " + Request.Browser.Version;
                else
                    device = Request.Browser.Browser + " " + Request.Browser.Version;

                formHandlerServiceClient.UpdateTranslatedby(patientId, consentType.ToString(), DeclarationSignatures.TxtTranslatedBy.Text);

                formHandlerServiceClient.UpdateTrackingInfo(patientId, new TrackingInfo { IP = ip, Device = device }, consentType.ToString());

                formHandlerServiceClient.UpdatePatientUnableSignReason(patientId, chkPatientisUnableToSign.Checked ? txtPatientNotSignedBecause.Text : string.Empty, consentType.ToString());

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