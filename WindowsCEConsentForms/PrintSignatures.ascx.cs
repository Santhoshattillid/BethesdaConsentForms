using System;
using WindowsCEConsentForms.FormHandlerService;

namespace WindowsCEConsentForms
{
    public partial class PrintSignatures : System.Web.UI.UserControl
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
                var formHandlerServiceClient = new ConsentFormSvcClient();
                var patientDetails = formHandlerServiceClient.GetPatientDetail(patientId, ConsentType.ToString());
                var treatment = formHandlerServiceClient.GetTreatment(patientId, ConsentType);

                if (patientDetails != null)
                {
                    LblPatientName.Text = patientDetails.name;

                    LblPatientUnableToSignBecause.Text = patientDetails.UnableToSignReason;

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

                    ImgPatientSignature.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=" + SignatureType.PatientSign + "&ConsentType=" + ConsentType.ToString();
                    ImgAuthorizedSignature.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=" + SignatureType.PatientAuthorizeSign + "&ConsentType=" + ConsentType.ToString();
                    ImgWitnessSignature1.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=" + SignatureType.WitnessSignature1 + "&ConsentType=" + ConsentType.ToString();
                    ImgWitnessSignature2.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=" + SignatureType.WitnessSignature2 + "&ConsentType=" + ConsentType.ToString();

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