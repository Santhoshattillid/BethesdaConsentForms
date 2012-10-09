using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WindowsCEConsentForms
{
    public partial class BloodConsentOrRefusal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnPrevious_Click(object sender, EventArgs e)
        {
            if ((bool)Session["EndoscopyConsent"])
            {
                Response.Redirect("/EndoscopyConsent.aspx");
                return;
            }
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
                Response.Redirect("/BloodConsentOrRefusalDeclaration.aspx");
            }
            catch (Exception ex) { }

        }
    }
}