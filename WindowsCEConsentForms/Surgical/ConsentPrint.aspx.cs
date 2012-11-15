using System;
using System.Data;
using WindowsCEConsentForms.ConsentFormsService;

namespace WindowsCEConsentForms
{
    public partial class SurgicalConsentPrint : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string PatientId; 
            try
            {
                PatientId = Request.QueryString["PatientID"];
            }
            catch (Exception)
            {
                PatientId = string.Empty;
            }
            if(!string.IsNullOrEmpty(PatientId))
            {
                var formHandlerServiceClient = new FormHandlerServiceClient();
                var patientDetails = formHandlerServiceClient.GetPatientDetail(PatientId);
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

                    ImgSignature1.ImageUrl = "/GetImage.ashx?PatientId=" + PatientId + "&Signature=1";
                    ImgSignature2.ImageUrl = "/GetImage.ashx?PatientId=" + PatientId + "&Signature=2";
                    ImgSignature3.ImageUrl = "/GetImage.ashx?PatientId=" + PatientId + "&Signature=3";
                    ImgSignature4.ImageUrl = "/GetImage.ashx?PatientId=" + PatientId + "&Signature=4";
                    ImgSignature5.ImageUrl = "/GetImage.ashx?PatientId=" + PatientId + "&Signature=5";
                    ImgPatientSignature.ImageUrl = "/GetImage.ashx?PatientId=" + PatientId + "&Signature=7";
                   
                }
            }
        }
    }
}