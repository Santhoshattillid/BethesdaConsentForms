using System;
using System.Data;
using WindowsCEConsentForms.FormHandlerService;

namespace WindowsCEConsentForms.BloodConsentOrRefusal
{
    public partial class PICCConsentPrint : System.Web.UI.Page
    {
        public bool IsStatementOfConsent;
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
                ConsentType = ConsentType.BloodConsentOrRefusal;

                var formHandlerServiceClient = new FormHandlerServiceClient();
                var patientDetails = formHandlerServiceClient.GetPatientDetail(patientId, ConsentType.ToString());
                if (patientDetails != null)
                {
                    var primaryDoctor = formHandlerServiceClient.GetPrimaryDoctorDetail(patientDetails.PrimaryDoctorId);
                    if (primaryDoctor != null)
                    {
                        LblAuthoriseDoctors.Text = primaryDoctor.Fname + " " + primaryDoctor.Lname;
                    }
                    foreach (DataRow row in formHandlerServiceClient.GetAssociatedPhysiciansList(patientDetails.PrimaryDoctorId).Rows)
                    {
                        LblAuthoriseDoctors.Text += " , " + row["Lname"].ToString().Trim() + " " + row["Fname"].ToString().Trim();
                    }

                    LblPatientName2.Text = patientDetails.name;
                    LblPatientName3.Text = patientDetails.name;
                    LblPatientUnableToSignBecause.Text = patientDetails.UnableToSignReason;
                    LblProcedureName.Text = patientDetails.ProcedureName;

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

                    LblTranslatedBy.Text = patientDetails.Translatedby;
                    ImgPatientSignature.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=" + SignatureType.PatientSign + "&ConsentType=" + ConsentType.ToString();
                    ImgAuthorizedSignature.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=" + SignatureType.PatientAuthorizeSign + "&ConsentType=" + ConsentType.ToString();
                    ImgWitnessSignature1.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=" + SignatureType.WitnessSignature1 + "&ConsentType=" + ConsentType.ToString();
                    ImgWitnessSignature2.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=" + SignatureType.WitnessSignature2 + "&ConsentType=" + ConsentType.ToString();

                    if (patientDetails.StatementOfConsent != null)
                    {
                        IsStatementOfConsent = true;
                        ChkAutologousUnits.Checked = patientDetails.StatementOfConsent.AutologousUnits;
                        ChkDirectedUnits.Checked = patientDetails.StatementOfConsent.DirectedUnits;
                    }
                    else
                        IsStatementOfConsent = false;
                }
            }
        }
    }
}