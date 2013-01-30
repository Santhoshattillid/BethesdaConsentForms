using System;

namespace WindowsCEConsentForms.Administration
{
    public partial class Synchronization : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var formHandlerServiceClient = Utilities.GetConsentFormSvcClient();
                formHandlerServiceClient.SynchronizeBethesdaData();
            }
            catch (Exception)
            {
            }
        }
    }
}