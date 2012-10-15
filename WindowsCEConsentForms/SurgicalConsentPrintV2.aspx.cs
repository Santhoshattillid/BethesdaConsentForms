using System;
using System.Data;
using WindowsCEConsentForms.ConsentFormsService;

namespace WindowsCEConsentForms
{
    public partial class SurgicalConsentPrintV2 : System.Web.UI.Page
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
                        //LblPrimaryDoctor.Text = primaryDoctor.Fname + " " + primaryDoctor.Lname;
                        LblAuthoriseDoctors.Text = primaryDoctor.Fname + " " + primaryDoctor.Lname;
                    }
                    LblPatientName2.Text = patientDetails.name;
                    LblProcedureName.Text = patientDetails.ProcedureName;
                    foreach (
                        DataRow row in
                            formHandlerServiceClient.GetAssociatedPhysiciansList(patientDetails.PrimaryDoctorId).Rows)
                    {
                        LblAuthoriseDoctors.Text += " , " + row["Lname"].ToString().Trim() + " " +
                                                    row["Fname"].ToString().Trim();
                    }
                    ImgSignature1.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=1";
                    ImgSignature2.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=2";
                    ImgSignature3.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=3";
                    ImgSignature4.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=4";
                    ImgSignature5.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=5";
                    ImgSignature7.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=7";
                    ImgSignature8.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=8";
                    ImgSignature9.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=9";
                    ImgSignature10.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=10";
                    ImgSignature11.ImageUrl = "/GetImage.ashx?PatientId=" + patientId + "&Signature=11";
                }
            }
        }
    }
}