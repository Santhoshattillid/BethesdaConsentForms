using System;
using System.Collections.Generic;
using WindowsCEConsentForms.ConsentFormSvc;

namespace WindowsCEConsentForms.PICC
{
    public partial class PICCConsentDeclaration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DeclarationSignatures.BtnCompleted.Click += BtnCompleted_Click;
            DeclarationSignatures.BtnReset.Click += BtnReset_Click;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            DeclarationSignatures.ResetSignatures();
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

                string empID = string.Empty;
                if (Session["EmpID"] != null)
                    empID = Session["EmpID"].ToString();

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
                    },
                    _empID = empID
                };

                var formHandlerServiceClient = Utilities.GetConsentFormSvcClient();
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