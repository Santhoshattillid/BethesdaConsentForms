using System;
using System.Data;
using WindowsCEConsentForms.ConsentFormsService;

namespace WindowsCEConsentForms.Surgical
{
    public partial class SurgicalConsentPrint : System.Web.UI.Page
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
                var patientDetails = formHandlerServiceClient.GetPatientDetail(patientId, ConsentType.Surgical.ToString());
                if (patientDetails != null)
                {
                    LblPatientMRID.Text = patientDetails.MRHash;
                    LblPatientName.Text = patientDetails.name;
                    LblDate.Text = patientDetails.AdmDate.ToString("MM dd yyyy");
                    LblTime.Text = DateTime.Now.ToShortTimeString();
                    LblPatientName2.Text = patientDetails.name;
                    LblProcedureName.Text = patientDetails.ProcedureName;
                    var primaryDoctor = formHandlerServiceClient.GetPrimaryDoctorDetail(patientDetails.PrimaryDoctorId);
                    if (primaryDoctor != null)
                    {
                        LblPrimaryDoctor.Text = primaryDoctor.Fname + " " + primaryDoctor.Lname;
                        LblAuthoriseDoctors.Text = primaryDoctor.Fname + " " + primaryDoctor.Lname;
                    }

                    //var secondaryDoctor = formHandlerServiceClient.GetAssociateDoctorDetail(patientDetails.PrimaryDoctorId);
                    //if (secondaryDoctor != null)
                    //LblAuthoriseDoctors.Text = secondaryDoctor.Fname + " , " + secondaryDoctor.Lname;
                    foreach (DataRow row in formHandlerServiceClient.GetAssociatedPhysiciansList(patientDetails.PrimaryDoctorId).Rows)
                    {
                        LblAuthoriseDoctors.Text += " , " + row["Lname"].ToString().Trim() + " " + row["Fname"].ToString().Trim();
                    }
                    ImgSignature1.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=1&ConsentType=" + ConsentType.Surgical.ToString();
                    ImgSignature2.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=2&ConsentType=" + ConsentType.Surgical.ToString();
                    ImgSignature3.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=3&ConsentType=" + ConsentType.Surgical.ToString();
                    ImgSignature4.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=4&ConsentType=" + ConsentType.Surgical.ToString();
                    ImgSignature5.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=5&ConsentType=" + ConsentType.Surgical.ToString();
                    ImgPatientSignature.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=7&ConsentType=" + ConsentType.Surgical.ToString();
                }
            }
        }
    }
}