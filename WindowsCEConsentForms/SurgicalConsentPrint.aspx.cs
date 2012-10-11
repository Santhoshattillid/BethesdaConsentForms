using System;

namespace WindowsCEConsentForms
{
    public partial class SurgicalConsentPrint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string PatientId; 
            try
            {
                PatientId = Request.QueryString["PatientID"];
            }
            catch (Exception)
            {
                PatientId = string.Empty;
            }
            if(!string.IsNullOrEmpty(PatientId))
            {
                
            }
        }
    }
}