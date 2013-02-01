using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Web;
using WindowsCEConsentForms.ConsentFormSvc;

namespace WindowsCEConsentForms
{
    /// <summary>
    /// Summary description for GetImage
    /// </summary>
    public class GetImage : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                string patientId;
                try
                {
                    patientId = context.Request.QueryString["PatientID"];
                }
                catch (Exception)
                {
                    patientId = string.Empty;
                }
                if (!string.IsNullOrEmpty(patientId))
                {
                    string signatureId;
                    try
                    {
                        signatureId = context.Request.QueryString["Signature"];
                    }
                    catch (Exception)
                    {
                        signatureId = string.Empty;
                    }
                    if (!string.IsNullOrEmpty(signatureId))
                    {
                        string consentType;
                        try
                        {
                            consentType = context.Request.QueryString["ConsentType"];
                        }
                        catch (Exception)
                        {
                            consentType = string.Empty;
                        }
                        if (string.IsNullOrEmpty(consentType))
                            return;
                        var formHandlerServiceClient = Utilities.GetConsentFormSvcClient();
                        var content = formHandlerServiceClient.GetPatientSignature(patientId, (ConsentType)Enum.Parse(typeof(ConsentType), consentType), (SignatureType)Enum.Parse(typeof(SignatureType), signatureId));
                        var signatureToImage = new SignatureToImage();
                        var bitmap = signatureToImage.SigJsonToImage(content);
                        bitmap.Save(context.Response.OutputStream, ImageFormat.Jpeg);
                    }
                }
            }
            catch (Exception ex)
            {
                var client = Utilities.GetConsentFormSvcClient();
                client.CreateLog(string.Empty, LogType.E, GetType().Name + "-" + new StackTrace().GetFrame(0).GetMethod().ToString(),
                                 ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}