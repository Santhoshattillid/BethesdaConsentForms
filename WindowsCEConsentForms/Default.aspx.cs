using System;
using System.Configuration;

namespace WindowsCEConsentForms
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string checkIfExist = ConfigurationManager.AppSettings["DBSetupStatus"];
            if (checkIfExist == "0")
                Server.Transfer("/PatientConsent.aspx");
            else
                Server.Transfer("/Administration/Setup.aspx");
        }
    }
}