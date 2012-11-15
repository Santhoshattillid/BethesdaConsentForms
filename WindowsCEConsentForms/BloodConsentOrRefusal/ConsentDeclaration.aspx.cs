using System;

namespace WindowsCEConsentForms.BloodConsentOrRefusal
{
    public partial class Consent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetPanels(false);
            for (int i = 0; i < 7; i++)
                ViewState["Signature" + i] = string.Empty;
        }

        protected void BtnCompleted_Click(object sender, EventArgs e)
        {
            Response.Redirect("/PatientConsent.aspx");
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