using System;
using WindowsCEConsentForms.ConsentFormSvc;

namespace WindowsCEConsentForms.PlasmanApheresis
{
    public partial class ConsentPrint : System.Web.UI.Page
    {
        public ConsentType consentType;

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
                consentType = ConsentType.PlasmanApheresis;
                var patientDetails = formHandlerServiceClient.GetPatientDetail(patientId, consentType.ToString());
                if (patientDetails != null)
                {
                    ImgSignature1.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=" + SignatureType.DoctorSign1.ToString() + @"&ConsentType=" + consentType.ToString();
                    ImgSignature2.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=" + SignatureType.DoctorSign2.ToString() + @"&ConsentType=" + consentType.ToString();
                    ImgSignature3.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=" + SignatureType.DoctorSign3.ToString() + @"&ConsentType=" + consentType.ToString();
                    ImgSignature4.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=" + SignatureType.DoctorSign4.ToString() + @"&ConsentType=" + consentType.ToString();
                }
            }
        }
    }
}