using System;
using System.Data;
using WindowsCEConsentForms.ConsentFormsService;

namespace WindowsCEConsentForms
{
    public partial class OutsideORConsentPrintV1 : System.Web.UI.Page
    {
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
                var patientDetails = formHandlerServiceClient.GetPatientDetail(patientId);
                if (patientDetails != null)
                {
                    var primaryDoctor = formHandlerServiceClient.GetPrimaryDoctorDetail(patientDetails.PrimaryDoctorId);
                    if (primaryDoctor != null)
                    {
                        LblAssociatedDoctor.Text = primaryDoctor.Fname + " " + primaryDoctor.Lname;
                        LblAuthoriseDoctors.Text = primaryDoctor.Fname + " " + primaryDoctor.Lname;
                    }
                    foreach (DataRow row in formHandlerServiceClient.GetAssociatedPhysiciansList(patientDetails.PrimaryDoctorId).Rows)
                    {
                        LblAuthoriseDoctors.Text += " , " + row["Lname"].ToString().Trim() + " " +
                                                    row["Fname"].ToString().Trim();
                    }

                    LblDOB.Text = DateTime.Now.ToString("MMM dd yyyy");
                    LblPatientAdminDate.Text = patientDetails.AdmDate.ToString("MMM dd yyyy");
                    LblPatientAdminTime.Text = patientDetails.AdmDate.ToLongTimeString();
                    LblPatientId.Text = patientId;
                    LblPatientMrHash.Text = patientDetails.MRHash;
                    LblPatientName.Text = patientDetails.name;
                    LblPatientName2.Text = patientDetails.name;
                    LblPatientUnableToSignBecause.Text = patientDetails.UnableToSignReason;
                    LblProcedureName.Text = patientDetails.ProcedureName;

                    LblSignatureDateTime.Text = DateTime.Now.ToString("MMM dd yyyy") + " <br /> " + DateTime.Now.ToLongTimeString();
                    LblTranslatedDateTime.Text = DateTime.Now.ToString("MMM dd yyyy") + " <br /> " + DateTime.Now.ToLongTimeString();
                    LblAuthorizedSignDateTime.Text = DateTime.Now.ToString("MMM dd yyyy") + " <br /> " + DateTime.Now.ToLongTimeString();
                    LblAssociatedDoctorTimeStamp.Text = DateTime.Now.ToString("MMM dd yyyy") + " <br /> " + DateTime.Now.ToLongTimeString();

                    LblDate.Text = DateTime.Now.ToString("MMM dd yyyy");
                    LblAge.Text = patientDetails.age.ToString();
                    LblGender.Text = patientDetails.gender;

                    ImgSignature1.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=1&ConsentType=OutsideORConsent";
                    ImgSignature2.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=2&ConsentType=OutsideORConsent";
                    ImgSignature3.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=3&ConsentType=OutsideORConsent";
                    ImgSignature4.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=4&ConsentType=OutsideORConsent";
                    ImgSignature5.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=5&ConsentType=OutsideORConsent";

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

                    ImgSignature6.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=7&ConsentType=OutsideORConsent";
                    ImgSignature7.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=8&ConsentType=OutsideORConsent";
                    ImgSignature8.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=9&ConsentType=OutsideORConsent";
                    ImgSignature9.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=10&ConsentType=OutsideORConsent";
                }
            }
        }
    }
}