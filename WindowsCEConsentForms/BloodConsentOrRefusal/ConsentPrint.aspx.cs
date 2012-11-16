using System;
using WindowsCEConsentForms.ConsentFormsService;

namespace WindowsCEConsentForms.PICC
{
    public partial class PICCConsentPrintV1 : System.Web.UI.Page
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
                    LblPatientName.Text = patientDetails.name;
                    ImgPatientSignature.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=8&ConsentType=" + ConsentType.PICC.ToString();
                    ImgWitnessSignature.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=10&ConsentType=" + ConsentType.PICC.ToString();
                    ImgPICCNurse.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=9&ConsentType=" + ConsentType.PICC.ToString();
                    LblSignature1DateTime.Text = DateTime.Now.ToString("MMM dd yyyy hh:mm:ss");
                    LblWitnessDateTime.Text = DateTime.Now.ToString("MMM dd yyyy hh:mm:ss");
                    LblImgPICCNurseDateTime.Text = DateTime.Now.ToString("MMM dd yyyy hh:mm:ss");
                }
            }
        }
    }
}