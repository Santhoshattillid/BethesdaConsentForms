using System;
using System.Configuration;

namespace WindowsCEConsentForms
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string checkIfExist = ConfigurationManager.AppSettings["DBSetupStatus"];
            Server.Transfer(checkIfExist == "1" ? "/PatientConsent.aspx" : "/Administration/Setup.aspx");
        }
    }
}