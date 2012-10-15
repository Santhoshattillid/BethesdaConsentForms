using System;

namespace WindowsCEConsentForms
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Server.Transfer("/PatientConsent.aspx");
        }
    }
}