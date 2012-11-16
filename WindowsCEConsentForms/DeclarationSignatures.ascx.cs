using System;

namespace WindowsCEConsentForms
{
    public partial class DeclarationSignatures : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState[SignatureType.PatientAuthorizeSign.ToString()] = string.Empty;
                ViewState[SignatureType.PatientSign.ToString()] = string.Empty;
                ViewState[SignatureType.TranslatedBySign.ToString()] = string.Empty;
                ViewState[SignatureType.WitnessSignature1.ToString()] = string.Empty;
                ViewState[SignatureType.WitnessSignature2.ToString()] = string.Empty;
            }
            else
            {
                if (Request.Form[SignatureType.PatientAuthorizeSign.ToString()] != null)
                    ViewState[SignatureType.PatientAuthorizeSign.ToString()] = Request.Form[SignatureType.PatientAuthorizeSign.ToString()];
                if (Request.Form[SignatureType.PatientSign.ToString()] != null)
                    ViewState[SignatureType.PatientSign.ToString()] = Request.Form[SignatureType.PatientSign.ToString()];
                if (Request.Form[SignatureType.TranslatedBySign.ToString()] != null)
                    ViewState[SignatureType.TranslatedBySign.ToString()] = Request.Form[SignatureType.TranslatedBySign.ToString()];
                if (Request.Form[SignatureType.WitnessSignature1.ToString()] != null)
                    ViewState[SignatureType.WitnessSignature1.ToString()] = Request.Form[SignatureType.WitnessSignature1.ToString()];
                if (Request.Form[SignatureType.WitnessSignature2.ToString()] != null)
                    ViewState[SignatureType.WitnessSignature2.ToString()] = Request.Form[SignatureType.WitnessSignature2.ToString()];
            }
            SetPanels(false);
        }

        protected void ChkPatientisUnableToSign_CheckedChanged(object sender, EventArgs e)
        {
            SetPanels(ChkPatientisUnableToSign.Checked);
        }

        private void SetPanels(bool flag)
        {
            PnlPatientReason1.Visible = flag;
            PnlPatientReason2.Visible = flag;
            PnlPatientSign.Visible = !flag;
            PnlAdditionalwitness.Visible = flag;
        }
    }
}