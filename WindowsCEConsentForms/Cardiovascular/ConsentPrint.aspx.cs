using System;
using WindowsCEConsentForms.FormHandlerService;

namespace WindowsCEConsentForms.Cardiovascular
{
    public partial class ConsentPrint : System.Web.UI.Page
    {
        public ConsentType ConsentType;

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
                ConsentType = ConsentType.Cardiovascular;
                var patientDetails = formHandlerServiceClient.GetPatientDetail(patientId, ConsentType.ToString());
                if (patientDetails != null)
                {
                    ImgSignature1.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=" + SignatureType.DoctorSign1.ToString() + @"&ConsentType=" + ConsentType.ToString();
                    ImgSignature2.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=" + SignatureType.DoctorSign2.ToString() + @"&ConsentType=" + ConsentType.ToString();
                    ImgSignature3.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=" + SignatureType.DoctorSign3.ToString() + "&ConsentType=" + ConsentType.ToString();
                    ImgSignature4.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=" + SignatureType.DoctorSign4.ToString() + "&ConsentType=" + ConsentType.ToString();
                    ImgSignature5.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=" + SignatureType.DoctorSign5.ToString() + "&ConsentType=" + ConsentType.ToString();
                }
            }
        }
    }
}