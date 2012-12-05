using System;
using System.Text;
using WindowsCEConsentForms.FormHandlerService;

namespace WindowsCEConsentForms
{
    public partial class DeclarationSignatures : System.Web.UI.UserControl
    {
        public ConsentType ConsentType;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ResetSignatures();
            else
            {
                if (Request.Form[SignatureType.PatientAuthorizeSign.ToString()] != null)
                    ViewState[SignatureType.PatientAuthorizeSign.ToString()] =
                        Request.Form[SignatureType.PatientAuthorizeSign.ToString()];
                if (Request.Form[SignatureType.PatientSign.ToString()] != null)
                    ViewState[SignatureType.PatientSign.ToString()] = Request.Form[SignatureType.PatientSign.ToString()];
                if (Request.Form[SignatureType.WitnessSignature1.ToString()] != null)
                    ViewState[SignatureType.WitnessSignature1.ToString()] =
                        Request.Form[SignatureType.WitnessSignature1.ToString()];
                if (Request.Form[SignatureType.WitnessSignature2.ToString()] != null)
                    ViewState[SignatureType.WitnessSignature2.ToString()] =
                        Request.Form[SignatureType.WitnessSignature2.ToString()];
                if (Request.Form[SignatureType.PICCSignature.ToString()] != null)
                    ViewState[SignatureType.PICCSignature.ToString()] =
                        Request.Form[SignatureType.PICCSignature.ToString()];
            }
            SetPanels(false);
        }

        protected void ChkPatientisUnableToSign_CheckedChanged(object sender, EventArgs e)
        {
            SetPanels(ChkPatientisUnableToSign.Checked);
        }

        public void SetPanels(bool flag)
        {
            PnlPatientReason1.Visible = flag;
            PnlPatientReason2.Visible = flag;
            PnlPatientReason3.Visible = flag;
            PnlPatientSign.Visible = !flag;
            PnlAdditionalwitness.Visible = flag;
            PnlAdditionalwitness2.Visible = flag;
        }

        public void ResetSignatures()
        {
            ViewState[SignatureType.PatientAuthorizeSign.ToString()] = string.Empty;
            ViewState[SignatureType.PatientSign.ToString()] = string.Empty;
            ViewState[SignatureType.WitnessSignature1.ToString()] = string.Empty;
            ViewState[SignatureType.WitnessSignature2.ToString()] = string.Empty;
            ViewState[SignatureType.PICCSignature.ToString()] = string.Empty;
        }

        protected void ChkTelephoneConsent_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkTelephoneConsent.Checked)
            {
                ChkPatientisUnableToSign.Checked = true;
                SetPanels(true);
            }
            ChkPatientisUnableToSign.Enabled = !ChkTelephoneConsent.Checked;
        }

        public void ValidateForm()
        {
            string outPut = string.Empty;
            if (ChkPatientisUnableToSign.Checked || ChkTelephoneConsent.Checked)
            {
                if (string.IsNullOrEmpty(TxtPatientNotSignedBecause.Text.Trim()))
                    outPut += " <br /> Please input reason for why patient not able sign.";

                if (string.IsNullOrEmpty(Request.Form[SignatureType.PatientAuthorizeSign.ToString()]))
                    outPut += " <br /> Please input patient authorized person signature.";
            }
            else
            {
                if (string.IsNullOrEmpty(Request.Form[SignatureType.PatientSign.ToString()]))
                    outPut += " <br /> Please input patient  signature.";
            }

            if (string.IsNullOrEmpty(Request.Form[SignatureType.WitnessSignature1.ToString()]))
                outPut += " <br /> Please input witness signature.";

            if (ChkTelephoneConsent.Checked &&
                string.IsNullOrEmpty(Request.Form[SignatureType.WitnessSignature2.ToString()]))
                outPut += " <br /> Please input witness 2 signature.";
            LblError.Text = outPut;
        }

        public void SaveForm(FormHandlerServiceClient formHandlerServiceClient, string patientId)
        {
            if (Request.Form[SignatureType.PatientSign.ToString()] != null)
            {
                var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.PatientSign.ToString()]);
                var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), ConsentType, SignatureType.PatientSign, string.Empty);
            }

            if (Request.Form[SignatureType.PatientAuthorizeSign.ToString()] != null)
            {
                var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.PatientAuthorizeSign.ToString()]); // Patient Signature
                var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), ConsentType, SignatureType.PatientAuthorizeSign, TxtAuthorizedPersonName.Text.Trim());
            }

            // updating signature5
            if (Request.Form[SignatureType.WitnessSignature1.ToString()] != null)
            {
                var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.WitnessSignature1.ToString()]);
                var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), ConsentType, SignatureType.WitnessSignature1, TxtWitnessSignature1Name.Text.Trim());
            }

            // updating signature6
            if (Request.Form[SignatureType.WitnessSignature2.ToString()] != null)
            {
                var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.WitnessSignature2.ToString()]);
                var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), ConsentType, SignatureType.WitnessSignature2, TxtSecondWitnessName.Text.Trim());
            }

            if (Request.Form[SignatureType.PICCSignature.ToString()] != null)
            {
                var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.PICCSignature.ToString()]);
                var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), ConsentType, SignatureType.PICCSignature, TxtPICCNurseName.Text.Trim());
            }

            formHandlerServiceClient.UpdatePatientUnableSignReason(patientId, ChkPatientisUnableToSign.Checked ? TxtPatientNotSignedBecause.Text : string.Empty, ConsentType.ToString());

            formHandlerServiceClient.UpdateTranslatedby(patientId, ConsentType.ToString(), TxtTranslatedBy.Text);
        }

        protected void btnHmme_Click(object sender, EventArgs e)
        {
            Response.Redirect("/PatientConsent.aspx");
        }

        protected void btnSkip_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utilities.GetNextFormUrl(ConsentType, Session));
        }
    }
}