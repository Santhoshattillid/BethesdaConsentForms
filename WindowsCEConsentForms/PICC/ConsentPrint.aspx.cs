using System;
using WindowsCEConsentForms.FormHandlerService;

namespace WindowsCEConsentForms.PICC
{
    public partial class PICCConsentPrintV1 : System.Web.UI.Page
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
                ConsentType = ConsentType.PICC;

                var formHandlerServiceClient = new ConsentFormSvcClient();
                var patientDetails = formHandlerServiceClient.GetPatientDetail(patientId, ConsentType.ToString());
                if (patientDetails != null)
                {
                    LblPatientName3.Text = patientDetails.name;
                    LblPICCNurseDate.Text = DateTime.Now.ToString("MMM dd yyyy");
                    LblPICCNurseTime.Text = DateTime.Now.ToLongTimeString();
                    ImgPICCNurse.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=" + SignatureType.PICCSignature + "&ConsentType=" + ConsentType.ToString();
                }
            }
        }
    }
}