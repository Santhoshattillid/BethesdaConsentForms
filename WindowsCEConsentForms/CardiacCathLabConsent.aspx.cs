using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WindowsCEConsentForms
{
    public partial class CardiacCathLabConsent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnPrevious_Click(object sender, EventArgs e)
        {
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
                Response.Redirect("/SurgicalConsentDeclaration.aspx");
            }
            catch (Exception ex) { }

        }
    }
}