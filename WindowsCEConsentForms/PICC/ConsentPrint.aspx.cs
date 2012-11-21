using System;
using System.Data;
using System.Globalization;
using WindowsCEConsentForms.ConsentFormsService;

namespace WindowsCEConsentForms.PICC
{
    public partial class PICCConsentPrintV1 : System.Web.UI.Page
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
                ConsentType = ConsentType.PICC;

                var formHandlerServiceClient = new FormHandlerServiceClient();
                var patientDetails = formHandlerServiceClient.GetPatientDetail(patientId, ConsentType.ToString());
                if (patientDetails != null)
                {
                    LblDOB.Text = DateTime.Now.ToString("MMM dd yyyy");
                    LblPatientAdminDate.Text = patientDetails.AdmDate.ToString("MMM dd yyyy");
                    LblPatientAdminTime.Text = patientDetails.AdmDate.ToLongTimeString();
                    LblPatientId.Text = patientId;
                    LblPatientMrHash.Text = patientDetails.MRHash;
                    LblPatientName3.Text = patientDetails.name;
                    LblPatientUnableToSignBecause.Text = patientDetails.UnableToSignReason;

                    LblPatientSignatureDateTime.Text = DateTime.Now.ToString("MMM dd yyyy") + " <br /> " + DateTime.Now.ToLongTimeString();
                    LblAuthorizedSignDateTime.Text = DateTime.Now.ToString("MMM dd yyyy") + " <br /> " + DateTime.Now.ToLongTimeString();
                    LblWitnessSignature1DateTime.Text = DateTime.Now.ToString("MMM dd yyyy") + " <br /> " + DateTime.Now.ToLongTimeString();
                    LblWitnessSignature2DateTime.Text = DateTime.Now.ToString("MMM dd yyyy") + " <br /> " + DateTime.Now.ToLongTimeString();
                    LblTranslatedDateTime.Text = DateTime.Now.ToString("MMM dd yyyy") + " <br /> " + DateTime.Now.ToLongTimeString();
                    LblPICCNurseDateTime.Text = DateTime.Now.ToString("MMM dd yyyy") + " <br /> " + DateTime.Now.ToLongTimeString();

                    LblDate.Text = DateTime.Now.ToString("MMM dd yyyy");
                    LblAge.Text = patientDetails.age.ToString(CultureInfo.InvariantCulture);
                    LblGender.Text = patientDetails.gender;

                    if (!string.IsNullOrEmpty(LblPatientUnableToSignBecause.Text.Trim()))
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
                    ImgPICCNurse.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=" + SignatureType.PICCSignature + "&ConsentType=" + ConsentType.ToString();
                }
            }
        }
    }
}