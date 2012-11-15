using System;
using WindowsCEConsentForms.ConsentFormsService;

namespace WindowsCEConsentForms
{
    public partial class PrintHeader : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string patientId;
            try
            {
                patientId = Request.QueryString["PatientID"];
            }
            catch (Exception)
            {
                patientId = string.Empty;
            }
            if (!string.IsNullOrEmpty(patientId))
            {
                var formHandlerServiceClient = new FormHandlerServiceClient();
                var patientDetails = formHandlerServiceClient.GetPatientDetail(patientId);
                if (patientDetails != null)
                {
                    LblPatientMRID.Text = patientDetails.MRHash;
                    LblPatientName.Text = patientDetails.name;
                    LblDate.Text = patientDetails.AdmDate.ToString("MM dd yyyy");
                    LblTime.Text = DateTime.Now.ToShortTimeString();
                }
            }
        }
    }
}