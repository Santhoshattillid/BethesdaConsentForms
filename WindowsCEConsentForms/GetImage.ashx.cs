using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using WindowsCEConsentForms.ConsentFormsService;

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
                string signatureID;
                try
                {
                    signatureID = context.Request.QueryString["Signature"];
                }
                catch (Exception)
                {
                    signatureID = string.Empty;
                }
                if (!string.IsNullOrEmpty(signatureID))
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
                        consentType = "SurgicalConsent";
                    var formHandlerServiceClient = new FormHandlerServiceClient();
                    var content = formHandlerServiceClient.GetPatientSignature(patientId, consentType, "signature" + signatureID);
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