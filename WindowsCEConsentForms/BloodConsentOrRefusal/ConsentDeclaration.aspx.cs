using System;
using System.Collections.Generic;
using WindowsCEConsentForms.ConsentFormSvc;

namespace WindowsCEConsentForms.BloodConsentOrRefusal
{
    public partial class Consent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DeclarationSignatures1.BtnCompleted.Click += BtnCompleted_Click;
            DeclarationSignatures1.BtnReset.Click += BtnReset_Click;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            DeclarationSignatures1.ResetSignatures();

            RdoStatementOfConsentAccepted.Checked = false;
            RdoStatementOfConsentRefusal.Checked = false;
            ChkAutologousUnits.Checked = false;
            ChkDirectedUnits.Checked = false;
        }

        protected void BtnCompleted_Click(object sender, EventArgs e)
        {
            try
            {
                const ConsentType consentType = ConsentType.BloodConsentOrRefusal;

                //validation
                var lblError = DeclarationSignatures1.LblError;

                lblError.Text = string.Empty;

                DeclarationSignatures1.ValidateForm();

                if (!string.IsNullOrEmpty(lblError.Text))
                {
                    return;
                }

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

                signatureses.AddRange(DeclarationSignatures1.GetSignatures());

                string empID = string.Empty;
                if (Session["EmpID"] != null)
                    empID = Session["EmpID"].ToString();

                var treatment = new Treatment
                {
                    _patientId = patientId,
                    _consentType = consentType,
                    _signatureses = signatureses.ToArray(),
                    _isPatientUnableSign = DeclarationSignatures1.ChkPatientisUnableToSign.Checked,
                    _unableToSignReason = DeclarationSignatures1.TxtPatientNotSignedBecause.Text,
                    _translatedBy = DeclarationSignatures1.TxtTranslatedBy.Text,
                    _trackingInformation = new TrackingInformation
                    {
                        _device = device,
                        _iP = ip
                    },
                    _empID = empID
                };

                var consentFormSvcClient = Utilities.GetConsentFormSvcClient();
                consentFormSvcClient.AddTreatment(treatment);
                Utilities.GeneratePdfAndUploadToSharePointSite(consentFormSvcClient, consentType, patientId);

                Response.Redirect(Utilities.GetNextFormUrl(consentType, Session));
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}