using System;
using System.Diagnostics;
using WindowsCEConsentForms.ConsentFormSvc;

namespace WindowsCEConsentForms
{
    public partial class ConsentPrint : System.Web.UI.UserControl
    {
        public ConsentType consentType;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                PrintFooter1.ConsentType = consentType;
                DoctorsAndProceduresPrint1.consentType = consentType;
                PrintSignatures1.consentType = consentType;

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
                    var formHandlerServiceClient = Utilities.GetConsentFormSvcClient();
                    var patientDetails = formHandlerServiceClient.GetPatientDetail(patientId, consentType.ToString(), location);
                    if (patientDetails != null)
                    {
                        LblPatientName3.Text = patientDetails.name;

                        ImgSignature1.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=" + SignatureType.DoctorSign1.ToString() + @"&ConsentType=" + consentType.ToString();
                        ImgSignature2.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=" + SignatureType.DoctorSign2.ToString() + @"&ConsentType=" + consentType.ToString();
                        ImgSignature3.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=" + SignatureType.DoctorSign3.ToString() + @"&ConsentType=" + consentType.ToString();
                        ImgSignature4.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=" + SignatureType.DoctorSign4.ToString() + @"&ConsentType=" + consentType.ToString();
                        ImgSignature5.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=" + SignatureType.DoctorSign5.ToString() + @"&ConsentType=" + consentType.ToString();
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