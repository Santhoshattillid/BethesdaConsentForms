using System;
using System.Data;
using System.Globalization;
using WindowsCEConsentForms.ConsentFormsService;

namespace WindowsCEConsentForms.Cardiovascular
{
    public partial class ConsentPrint : System.Web.UI.Page
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
                var formHandlerServiceClient = new FormHandlerServiceClient();
                ConsentType = ConsentType.Cardiovascular;
                var patientDetails = formHandlerServiceClient.GetPatientDetail(patientId, ConsentType.ToString());
                if (patientDetails != null)
                {
                    LblDOB.Text = DateTime.Now.ToString("MMM dd yyyy");
                    LblPatientAdminDate.Text = patientDetails.AdmDate.ToString("MMM dd yyyy");
                    LblPatientAdminTime.Text = patientDetails.AdmDate.ToLongTimeString();
                    LblPatientId.Text = patientId;
                    LblPatientMrHash.Text = patientDetails.MRHash;
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

                    LblDate.Text = DateTime.Now.ToString("MMM dd yyyy");
                    LblAge.Text = patientDetails.age.ToString(CultureInfo.InvariantCulture);
                    LblGender.Text = patientDetails.gender;

                    ImgSignature1.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=" + SignatureType.DoctorSign1.ToString() + @"&ConsentType=" + ConsentType.ToString();
                    ImgSignature2.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=" + SignatureType.DoctorSign2.ToString() + @"&ConsentType=" + ConsentType.ToString();
                    ImgSignature3.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=" + SignatureType.DoctorSign3.ToString() + "&ConsentType=" + ConsentType.ToString();
                    ImgSignature4.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=" + SignatureType.DoctorSign4.ToString() + "&ConsentType=" + ConsentType.ToString();
                    ImgSignature5.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=" + SignatureType.DoctorSign5.ToString() + "&ConsentType=" + ConsentType.ToString();

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
                }
            }
        }
    }
}