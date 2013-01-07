using System;
using System.Collections.Generic;
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
            SetPanels(ChkPatientisUnableToSign.Checked);
        }

        protected void ChkPatientisUnableToSign_CheckedChanged(object sender, EventArgs e)
        {
            SetPanels(ChkPatientisUnableToSign.Checked);
        }

        private void SetPanels(bool flag)
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
            SetPanels(false);
            TxtAuthorizedPersonName.Text = string.Empty;
            TxtPICCNurseName.Text = string.Empty;
            TxtPatientNotSignedBecause.Text = string.Empty;
            TxtSecondWitnessName.Text = string.Empty;
            TxtTranslatedBy.Text = string.Empty;
            TxtWitnessSignature1Name.Text = string.Empty;
            ChkPatientisUnableToSign.Checked = false;
            ChkPatientisUnableToSign.Enabled = true;
            ChkTelephoneConsent.Checked = false;
            LblError.Text = string.Empty;
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

                if (string.IsNullOrEmpty(TxtAuthorizedPersonName.Text.Trim()))
                    outPut += " <br /> Please input patient authorized person name.";
            }
            else
            {
                if (string.IsNullOrEmpty(Request.Form[SignatureType.PatientSign.ToString()]))
                    outPut += " <br /> Please input patient  signature.";
            }

            if (string.IsNullOrEmpty(Request.Form[SignatureType.WitnessSignature1.ToString()]))
                outPut += " <br /> Please input witness signature.";

            if (string.IsNullOrEmpty(TxtWitnessSignature1Name.Text.Trim()))
                outPut += " <br /> Please input witness name.";

            if (ChkTelephoneConsent.Checked && string.IsNullOrEmpty(Request.Form[SignatureType.WitnessSignature2.ToString()]))
            {
                outPut += " <br /> Please input witness 2 signature.";
                if (string.IsNullOrEmpty(TxtSecondWitnessName.Text.Trim()))
                    outPut += " <br /> Please input second witness name.";
            }

            if (ConsentType == ConsentType.PICC)
            {
                if (string.IsNullOrEmpty(Request.Form[SignatureType.PICCSignature.ToString()]))
                    outPut += " <br /> Please input PICC Nurse signature.";

                if (string.IsNullOrEmpty(TxtPICCNurseName.Text.Trim()))
                    outPut += " <br /> Please input PICC  nurse name.";
            }

            if (string.IsNullOrEmpty(TxtTranslatedBy.Text.Trim()))
                outPut += " <br /> Please input interpreted by name.";

            LblError.Text += outPut;
        }

        public List<Signatures> GetSignatures()
        {
            var outPut = new List<Signatures>();
            if (Request.Form[SignatureType.PatientSign.ToString()] != null)
            {
                var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.PatientSign.ToString()]);
                outPut.Add(new Signatures
                               {
                                   _name = string.Empty,
                                   _signatureContent = Encoding.ASCII.GetString(bytes),
                                   _signatureType = SignatureType.PatientSign
                               });
            }

            if (Request.Form[SignatureType.PatientAuthorizeSign.ToString()] != null)
            {
                var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.PatientAuthorizeSign.ToString()]); // Patient Signature
                outPut.Add(new Signatures
                {
                    _name = TxtAuthorizedPersonName.Text,
                    _signatureContent = Encoding.ASCII.GetString(bytes),
                    _signatureType = SignatureType.PatientAuthorizeSign
                });
            }

            // updating signature5
            if (Request.Form[SignatureType.WitnessSignature1.ToString()] != null)
            {
                var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.WitnessSignature1.ToString()]);
                outPut.Add(new Signatures
                {
                    _name = TxtWitnessSignature1Name.Text,
                    _signatureContent = Encoding.ASCII.GetString(bytes),
                    _signatureType = SignatureType.WitnessSignature1
                });
            }

            // updating signature6
            if (Request.Form[SignatureType.WitnessSignature2.ToString()] != null)
            {
                var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.WitnessSignature2.ToString()]);
                outPut.Add(new Signatures
                {
                    _name = TxtSecondWitnessName.Text,
                    _signatureContent = Encoding.ASCII.GetString(bytes),
                    _signatureType = SignatureType.WitnessSignature2
                });
            }

            if (Request.Form[SignatureType.PICCSignature.ToString()] != null)
            {
                var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.PICCSignature.ToString()]);
                outPut.Add(new Signatures
                {
                    _name = TxtPICCNurseName.Text,
                    _signatureContent = Encoding.ASCII.GetString(bytes),
                    _signatureType = SignatureType.PICCSignature
                });
            }

            return outPut;
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