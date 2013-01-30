using System;
using WindowsCEConsentForms.ConsentFormSvc;

namespace WindowsCEConsentForms
{
    public partial class PrintSignatures : System.Web.UI.UserControl
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
                var patientDetails = formHandlerServiceClient.GetPatientDetail(patientId, consentType.ToString());
                var treatment = formHandlerServiceClient.GetTreatment(patientId, consentType);

                if (patientDetails != null)
                {
                    LblPatientName.Text = patientDetails.name;

                    LblPatientUnableToSignBecause.Text = treatment._unableToSignReason;

                    LblPatientSignatureDate.Text = DateTime.Now.ToString("MMM dd yyyy");
                    LblPatientSignatureTime.Text = DateTime.Now.ToLongTimeString();
                    LblAuthorizedSignDate.Text = DateTime.Now.ToString("MMM dd yyyy");
                    LblAuthorizedSignTime.Text = DateTime.Now.ToLongTimeString();
                    LblWitnessSignature1Date.Text = DateTime.Now.ToString("MMM dd yyyy");
                    LblWitnessSignature1Time.Text = DateTime.Now.ToLongTimeString();
                    LblWitnessSignature2Date.Text = DateTime.Now.ToString("MMM dd yyyy");
                    LblWitnessSignature2Time.Text = DateTime.Now.ToLongTimeString();
                    LblTranslatedDate.Text = DateTime.Now.ToString("MMM dd yyyy");
                    LblTranslatedTime.Text = DateTime.Now.ToLongTimeString();

                    if (treatment._isPatientUnableSign)
                    {
                        PnlPatientSignature.Visible = false;
                        PnlPatientUnableToSignBecause.Visible = true;
                        PnlAuthorizedSignature.Visible = true;
                    }
                    else
                    {
                        PnlPatientSignature.Visible = true;
                        PnlPatientUnableToSignBecause.Visible = false;
                        PnlAuthorizedSignature.Visible = false;
                    }

                    ImgPatientSignature.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=" + SignatureType.PatientSign + "&ConsentType=" + consentType.ToString();
                    ImgAuthorizedSignature.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=" + SignatureType.PatientAuthorizeSign + "&ConsentType=" + consentType.ToString();
                    ImgWitnessSignature1.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=" + SignatureType.WitnessSignature1 + "&ConsentType=" + consentType.ToString();
                    ImgWitnessSignature2.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=" + SignatureType.WitnessSignature2 + "&ConsentType=" + consentType.ToString();

                    LblTranslatedBy.Text = treatment._translatedBy;

                    foreach (Signatures signatures in treatment._signatureses)
                    {
                        switch (signatures._signatureType)
                        {
                            case SignatureType.PatientAuthorizeSign:
                                {
                                    LblAuthorizePersonName.Text = signatures._name;
                                    break;
                                }
                            case SignatureType.WitnessSignature1:
                                {
                                    LblWitnessName1.Text = signatures._name;
                                    break;
                                }
                            case SignatureType.WitnessSignature2:
                                {
                                    LblWitnessName2.Text = signatures._name;
                                    break;
                                }
                        }
                    }
                }
            }
        }
    }
}