using System;

namespace WindowsCEConsentForms
{
    public partial class CardiacCathLabConsentDeclaration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnCompleted_Click(object sender, EventArgs e)
        {
            try
            {
                if ((bool)Session["EndoscopyConsent"])
                {
                    Response.Redirect("/EndoscopyConsent.aspx");
                    return;
                }
                if ((bool)Session["BloodConsentRefusal"])
                {
                    Response.Redirect("/BloodConsentOrRefusal.aspx");
                    return;
                }
            }
            catch (Exception ex) { }
        }

        protected void BtnPrevious_Click1(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("/CardiacCathLabConsent.aspx");
            }
            catch (Exception ex) { }
        }
    }
}