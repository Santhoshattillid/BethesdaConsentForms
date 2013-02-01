using System;
using System.Diagnostics;
using WindowsCEConsentForms.ConsentFormSvc;

namespace WindowsCEConsentForms.PICC
{
    public partial class PICCConsentPrintV1 : System.Web.UI.Page
    {
        public ConsentType consentType;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
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
                string location;
                try
                {
                    location = Request.QueryString["Location"];
                }
                catch (Exception)
                {
                    location = string.Empty;
                }
                if (!string.IsNullOrEmpty(patientId) && !string.IsNullOrEmpty(location))
                {
                    consentType = ConsentType.PICC;

                    var formHandlerServiceClient = Utilities.GetConsentFormSvcClient();
                    var patientDetails = formHandlerServiceClient.GetPatientDetail(patientId, consentType.ToString(), location);
                    if (patientDetails != null)
                    {
                        LblPatientName3.Text = patientDetails.name;
                        LblPICCNurseDate.Text = DateTime.Now.ToString("MMM dd yyyy");
                        LblPICCNurseTime.Text = DateTime.Now.ToLongTimeString();
                        ImgPICCNurse.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=" + SignatureType.PICCSignature + "&ConsentType=" + consentType.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                var client = Utilities.GetConsentFormSvcClient();
                client.CreateLog(Utilities.GetUsername(Session), LogType.E, GetType().Name + "-" + new StackTrace().GetFrame(0).GetMethod().ToString(),
                                 ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }
    }
}