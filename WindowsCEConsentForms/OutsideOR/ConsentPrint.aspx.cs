using System;
using WindowsCEConsentForms.ConsentFormSvc;

namespace WindowsCEConsentForms.OutsideOR
{
    public partial class OutsideORConsentPrintV1 : System.Web.UI.Page
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
                var formHandlerServiceClient = Utilities.GetConsentFormSvcClient();
                var patientDetails = formHandlerServiceClient.GetPatientDetail(patientId, ConsentType.OutsideOR.ToString());
                if (patientDetails != null)
                {
                    ImgSignature1.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=1&ConsentType=" + ConsentType.OutsideOR.ToString();
                    ImgSignature2.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=2&ConsentType=" + ConsentType.OutsideOR.ToString();
                    ImgSignature3.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=3&ConsentType=" + ConsentType.OutsideOR.ToString();
                    ImgSignature4.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=4&ConsentType=" + ConsentType.OutsideOR.ToString();
                    ImgSignature5.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=5&ConsentType=" + ConsentType.OutsideOR.ToString();
                }
            }
        }
    }
}