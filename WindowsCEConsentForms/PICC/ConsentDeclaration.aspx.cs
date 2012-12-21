using System;
using System.Collections.Generic;
using WindowsCEConsentForms.FormHandlerService;

namespace WindowsCEConsentForms.PICC
{
    public partial class PICCConsentDeclaration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DeclarationSignatures.BtnCompleted.Click += BtnCompleted_Click;
        }

        protected void BtnCompleted_Click(object sender, EventArgs e)
        {
            try
            {
                //validation

                const ConsentType consentType = ConsentType.PICC;

                DeclarationSignatures.LblError.Text = string.Empty;

                DeclarationSignatures.ValidateForm();

                if (!string.IsNullOrEmpty(DeclarationSignatures.LblError.Text))
                    return;

                // uploading images here
                string patientId = string.Empty;
                try
                {
                    patientId = Session["PatientID"].ToString();
                }
                catch (Exception)
                {
                    Response.Redirect("/PatientConsent.aspx");
                }

                string ip = Request.ServerVariables["REMOTE_ADDR"];
                string device;
                if (Request.Browser.IsMobileDevice)
                    device = Request.Browser.Browser + " " + Request.Browser.Version;
                else
                    device = Request.Browser.Browser + " " + Request.Browser.Version;

                var signatureses = new List<Signatures>();

                signatureses.AddRange(DeclarationSignatures.GetSignatures());

                var treatment = new Treatment
                {
                    _patientId = patientId,
                    _consentType = consentType,
                    _signatureses = signatureses.ToArray(),
                    _isPatientUnableSign = DeclarationSignatures.ChkPatientisUnableToSign.Checked,
                    _unableToSignReason = DeclarationSignatures.TxtPatientNotSignedBecause.Text,
                    _translatedBy = DeclarationSignatures.TxtTranslatedBy.Text,
                    _trackingInformation = new TrackingInformation
                    {
                        _device = device,
                        _iP = ip
                    }
                };

                var formHandlerServiceClient = new ConsentFormSvcClient();
                formHandlerServiceClient.AddTreatment(treatment);
                Utilities.GeneratePdfAndUploadToSharePointSite(formHandlerServiceClient, consentType, patientId);

                Response.Redirect("/PatientConsent.aspx");
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}