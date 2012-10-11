using System;
using System.Text;
using WindowsCEConsentForms.ConsentFormsService;
using System.Drawing.Imaging;

namespace WindowsCEConsentForms
{
    public partial class SurgicalConsentDeclaration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < 7; i++)
                    ViewState["Signature" + i] = string.Empty;
                string patientId = string.Empty;
                try
                {
                    patientId = Session["PatientID"].ToString();
                }
                catch (Exception)
                {
                    try
                    {
                        patientId = Request.QueryString["PatientId"].ToString();
                    }
                    catch (Exception)
                    {
                        // Response.Redirect("/PatientConsent.aspx");
                    }
                }
                var formHandlerServiceClient = new FormHandlerServiceClient();
                var patientDetail = formHandlerServiceClient.GetPatientDetail(patientId);
                if (patientDetail != null)
                {
                    LblPatientName.Text = patientDetail.name;
                    LblDate.Text = patientDetail.AdmDate.ToString("MMM dd yyyy");
                    LblPatientId.Text = patientId;
                    LblTime.Text = DateTime.Now.ToShortTimeString();
                    LbldoctorName.Text = patientDetail.AttnDr;
                    LbldoctorName.Text = string.Empty;
                    if (!string.IsNullOrEmpty(patientDetail.PrimaryDoctorId))
                    {
                        var doctorDetail = formHandlerServiceClient.GetPrimaryDoctorDetail(patientDetail.PrimaryDoctorId);
                        if(doctorDetail != null)
                            LbldoctorName.Text += doctorDetail.Fname + " " + doctorDetail.Lname;
                    }
                    if (!string.IsNullOrEmpty(patientDetail.AssociatedDoctorId))
                    {
                        var doctorDetail = formHandlerServiceClient.GetAssociateDoctorDetail(patientDetail.AssociatedDoctorId);
                        if (doctorDetail != null)
                        {
                            if(!string.IsNullOrEmpty(LbldoctorName.Text))
                                LbldoctorName.Text += "  ,  ";
                            LbldoctorName.Text += doctorDetail.Fname + " " + doctorDetail.Lname;
                        }
                    }
                    /*
                    // Loading Signatures based on the selected patient
                    HdnImage1.Value = formHandlerServiceClient.GetPatientSignature(patientId, "SurgicalConsent",
                                                                                   "signature6");
                    HdnImage2.Value = formHandlerServiceClient.GetPatientSignature(patientId, "SurgicalConsent",
                                                                                   "signature7");
                    HdnImage3.Value = formHandlerServiceClient.GetPatientSignature(patientId, "SurgicalConsent",
                                                                                   "signature8");
                    HdnImage4.Value = formHandlerServiceClient.GetPatientSignature(patientId, "SurgicalConsent",
                                                                                   "signature9");
                    HdnImage5.Value = formHandlerServiceClient.GetPatientSignature(patientId, "SurgicalConsent",
                                                                                   "signature10");
                    HdnImage6.Value = formHandlerServiceClient.GetPatientSignature(patientId, "SurgicalConsent",
                                                                                   "signature11"); */

                    // Loading Signatures based on the selected patient
                    ViewState["Signature1"] = formHandlerServiceClient.GetPatientSignature(patientId, "SurgicalConsent", "signature7");
                    ViewState["Signature2"] = formHandlerServiceClient.GetPatientSignature(patientId, "SurgicalConsent", "signature8");
                    ViewState["Signature3"] = formHandlerServiceClient.GetPatientSignature(patientId, "SurgicalConsent", "signature9");
                    ViewState["Signature4"] = formHandlerServiceClient.GetPatientSignature(patientId, "SurgicalConsent", "signature10");
                    ViewState["Signature5"] = formHandlerServiceClient.GetPatientSignature(patientId, "SurgicalConsent", "signature11");
                }
            }
            catch (Exception ex)
            {
                //Response.Redirect("/PatientConsent.aspx");
            }
        }

        protected void BtnCompleted_Click(object sender, EventArgs e)
        {
            try
            {
                // need to save signatures here
                //if (string.IsNullOrEmpty(HdnImage2.Value) || string.IsNullOrEmpty(HdnImage3.Value) || string.IsNullOrEmpty(HdnImage4.Value) || string.IsNullOrEmpty(HdnImage5.Value) || string.IsNullOrEmpty(HdnImage6.Value))
                //{
                //    LblError.Text = "Please input signatures in all the fields";
                //    return;
                //}

                // uploading images here
                string patientId = string.Empty;
                try
                {
                    patientId = Session["PatientID"].ToString();
                }
                catch (Exception)
                {
                    Response.Redirect("/PatientConsent.aspx");
                }
                var formHandlerServiceClient = new FormHandlerServiceClient();

                // updating signature1
                //var bytes = Encoding.ASCII.GetBytes(HdnImage1.Value);
                //bool result = formHandlerServiceClient.SavePatientSignature(patientId, ASCIIEncoding.ASCII.GetString(bytes), "SurgicalConsent", "signature6");

                // updating signature2
                var bytes = Encoding.ASCII.GetBytes(Request.Form["HdnImage1"]);
                var result = formHandlerServiceClient.SavePatientSignature(patientId, ASCIIEncoding.ASCII.GetString(bytes), "SurgicalConsent", "signature7");

                // updating signature3
                bytes = Encoding.ASCII.GetBytes(Request.Form["HdnImage2"]);
                result = formHandlerServiceClient.SavePatientSignature(patientId, ASCIIEncoding.ASCII.GetString(bytes), "SurgicalConsent", "signature8");

                // updating signature4
                bytes = Encoding.ASCII.GetBytes(Request.Form["HdnImage3"]);
                result = formHandlerServiceClient.SavePatientSignature(patientId, ASCIIEncoding.ASCII.GetString(bytes), "SurgicalConsent", "signature9");

                // updating signature5
                bytes = Encoding.ASCII.GetBytes(Request.Form["HdnImage4"]);
                result = formHandlerServiceClient.SavePatientSignature(patientId, ASCIIEncoding.ASCII.GetString(bytes), "SurgicalConsent", "signature10");

                // updating signature6
                bytes = Encoding.ASCII.GetBytes(Request.Form["HdnImage5"]);
                result = formHandlerServiceClient.SavePatientSignature(patientId, ASCIIEncoding.ASCII.GetString(bytes), "SurgicalConsent", "signature11");

                // temp code to generate images and store into local folder for testing

                var signatureToImage = new SignatureToImage();
                for(int i=1;i<6;i++)
                    signatureToImage.SigJsonToImage(Request.Form["HdnImage" + i.ToString()]).Save(@"C:\Users\santhosh\Desktop\" + i.ToString() + ".jpg",ImageFormat.Jpeg);


                string ip = Request.ServerVariables["REMOTE_ADDR"];
                string device;
                if (Request.Browser.IsMobileDevice)
                    device = Request.Browser.Browser + " " + Request.Browser.Version;
                else
                    device = Request.Browser.Browser + " " + Request.Browser.Version;

                formHandlerServiceClient.UpdateTrackingInfo(patientId, new TrackingInfo { IP = ip, Device = device });

                formHandlerServiceClient.GenerateAndUploadPDFtoSharePoint("http://devsp1.atbapps.com:5555/SurgicalConsent.aspx?PatientId=" + patientId, patientId, "SurgicalConsentForm1");
                formHandlerServiceClient.GenerateAndUploadPDFtoSharePoint("http://devsp1.atbapps.com:5555/SurgicalConsentDeclaration.aspx?PatientId=" + patientId, patientId, "SurgicalConsentForm2");

                if ((bool)Session["CardiacCathLabConsent"])
                {
                    Response.Redirect("/CardiacCathLabConsent.aspx");
                    return;
                }
                if ((bool)Session["EndoscopyConsent"])
                {
                    Response.Redirect("/EndoscopyConsent.aspx");
                    return;
                }
                if ((bool)Session["BloodConsentRefusal"])
                {
                    Response.Redirect("/BloodConsentOrRefusal.aspx");
                }

                Response.Redirect("/PatientConsent.aspx");
            }
            catch (Exception ex)
            {
            }
        }

        protected void BtnPrevious_Click1(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("/SurgicalConsent.aspx");
            }
            catch (Exception ex) { }
        }
    }
}