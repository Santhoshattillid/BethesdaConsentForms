using System;
using System.Drawing.Imaging;
using System.Web;
using WindowsCEConsentForms.FormHandlerService;

namespace WindowsCEConsentForms
{
    /// <summary>
    /// Summary description for GetImage
    /// </summary>
    public class GetImage : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
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
                    var formHandlerServiceClient = new FormHandlerServiceClient();
                    var content = formHandlerServiceClient.GetPatientSignature(patientId, consentType, signatureId);
                    var signatureToImage = new SignatureToImage();
                    var bitmap = signatureToImage.SigJsonToImage(content);
                    bitmap.Save(context.Response.OutputStream, ImageFormat.Jpeg);
                }
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