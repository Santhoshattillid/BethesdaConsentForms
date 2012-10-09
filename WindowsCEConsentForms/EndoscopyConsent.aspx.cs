using System;

namespace WindowsCEConsentForms
{
    public partial class EndoscopyConsent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnPrevious_Click(object sender, EventArgs e)
        {
            if ((bool)Session["CardiacCathLabConsent"])
            {
                Response.Redirect("/CardiacCathLabConsent.aspx");
                return;
            }
            if ((bool)Session["SurgicalConsent"])
            {
                Response.Redirect("/SurgicalConsent.aspx");
                return;
            }
            try
            {
                Response.Redirect("/PatientConsent.aspx");
            }
            catch (Exception ex) { }
        }

        protected void BtnNext_Click(object sender, EventArgs e)
        {
            // need to save signatures here
            try
            {
                Response.Redirect("/EndoscopyConsentDeclaration.aspx");
            }
            catch (Exception ex) { }

        }
    }
}