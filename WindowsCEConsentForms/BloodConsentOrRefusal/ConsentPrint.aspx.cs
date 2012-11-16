using System;
using WindowsCEConsentForms.ConsentFormsService;

namespace WindowsCEConsentForms.BloodConsentOrRefusal
{
    public partial class PICCConsentPrint : System.Web.UI.Page
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
                    ImgPatientSignature.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=8&ConsentType=" + ConsentType.BloodConsentOrRefusal.ToString();
                    ImgWitnessSignature.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=10&ConsentType=" + ConsentType.BloodConsentOrRefusal.ToString();
                    LblSignature1DateTime.Text = DateTime.Now.ToString("MMM dd yyyy hh:mm:ss");
                    LblWitnessDateTime.Text = DateTime.Now.ToString("MMM dd yyyy hh:mm:ss");
                }
            }
        }
    }
}