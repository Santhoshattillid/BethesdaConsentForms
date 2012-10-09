using System;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using WindowsCEConsentForms.ConsentFormsService;

namespace WindowsCEConsentForms
{
    public partial class SurgicalConsent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
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
                    var patientDetail = formHandlerServiceClient.GetPatientDetail(patientId);
                    if (patientDetail != null)
                    {
                        LblPatientName.Text = patientDetail.name;
                        LblDate.Text = patientDetail.AdmDate.ToString("MMM dd yyyy");
                        LblPatientId.Text = patientId;
                        LblTime.Text = DateTime.Now.ToShortTimeString();
                        LbldoctorName.Text = patientDetail.AttnDr;

                        /*

                        // Loading Signatures based on the selected patient
                        HdnImage1.Value = formHandlerServiceClient.GetPatientSignature(patientId, "SurgicalConsent",
                                                                                       "signature1");
                        HdnImage2.Value = formHandlerServiceClient.GetPatientSignature(patientId, "SurgicalConsent",
                                                                                       "signature2");
                        HdnImage3.Value = formHandlerServiceClient.GetPatientSignature(patientId, "SurgicalConsent",
                                                                                       "signature3");
                        HdnImage4.Value = formHandlerServiceClient.GetPatientSignature(patientId, "SurgicalConsent",
                                                                                       "signature4");
                        HdnImage5.Value = formHandlerServiceClient.GetPatientSignature(patientId, "SurgicalConsent",
                                                                                       "signature5");
                         */
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/PatientConsent.aspx");
            }
        }

        protected void BtnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("/PatientConsent.aspx");
            }
            catch (Exception ex)
            {
            }
        }

        protected void BtnNext_Click(object sender, EventArgs e)
        {
            // need to save signatures here
            try
            {
                //                if (string.IsNullOrEmpty(HdnImage1.Value) || string.IsNullOrEmpty(HdnImage2.Value) ||                     string.IsNullOrEmpty(HdnImage3.Value) || string.IsNullOrEmpty(HdnImage4.Value) ||                     string.IsNullOrEmpty(HdnImage5.Value))
                if (true)
                {
                    LblError.Text = "Please input your signatures in all the fields";
                    return;
                }

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

                /*

                // updating signature1
                var bytes = Encoding.ASCII.GetBytes(HdnImage1.Value);
                bool result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), "SurgicalConsent", "signature1");

                // updating signature2
                bytes = Encoding.ASCII.GetBytes(HdnImage2.Value);
                result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), "SurgicalConsent", "signature2");

                // updating signature3
                bytes = Encoding.ASCII.GetBytes(HdnImage3.Value);
                result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), "SurgicalConsent", "signature3");

                // updating signature4
                bytes = Encoding.ASCII.GetBytes(HdnImage4.Value);
                result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), "SurgicalConsent", "signature4");

                // updating signature4
                bytes = Encoding.ASCII.GetBytes(HdnImage5.Value);
                result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), "SurgicalConsent", "signature5");
                */

                //var document = new Document();
                try
                {
                    //string tempPath = Path.GetTempPath() + "\\" + patientId + "Consent2.pdf";

                    //string tempPath = GetTempFilename() + "\\Consent2.pdf";
                    //if (File.Exists(tempPath))
                    //File.Delete(tempPath);

                    //PdfWriter.GetInstance(document, new FileStream(tempPath, FileMode.OpenOrCreate));
                    //document.Open();

                    //var bytes = Encoding.ASCII.GetBytes(HdnImage1.Value);
                    //var bytes = Encoding.ASCII.GetBytes(Uri.EscapeUriString(HdnImage1.Value));

                    //var bytes = ASCIIEncoding.ASCII.GetBytes(HdnImage1.Value);
                    //var bytes = ASCIIEncoding.ASCII.GetBytes(Uri.EscapeUriString(HdnImage1.Value));

                    //var bytes = Convert.FromBase64String(Uri.EscapeUriString(HdnImage1.Value));
                    //var bytes = Convert.FromBase64String(HdnImage1.Value);
                    //var ms = new MemoryStream(bytes);

                    //Image img = new ImgWMF(bytes);

                    //document.Add(img);

                    //System.Drawing.Image image1 = System.Drawing.Image.FromStream(ms);

                    //string tempImagePath = GetTempFilename();
                    //image1.Save(tempImagePath);
                    //document.Add(Image.GetInstance(tempImagePath));

                    /*
                    bytes = Encoding.ASCII.GetBytes(HdnImage2.Value);
                    image1 = Image.GetInstance(bytes);
                    document.Add(image1);

                    bytes = Encoding.ASCII.GetBytes(HdnImage3.Value);
                    image1 = Image.GetInstance(bytes);
                    document.Add(image1);

                    bytes = Encoding.ASCII.GetBytes(HdnImage4.Value);
                    image1 = Image.GetInstance(bytes);
                    document.Add(image1);

                    bytes = Encoding.ASCII.GetBytes(HdnImage5.Value);
                    image1 = Image.GetInstance(bytes);
                    document.Add(image1); */

                    //document.Close();

                    Response.Redirect("/SurgicalConsentDeclaration.aspx");
                }
                catch (Exception ex)
                {
                }
            }
            catch (Exception ex)
            {
            }
        }

        public string GetTempFilename()
        {
            string filePath = Path.Combine(Path.GetTempPath(), new Random().Next(1, 10000).ToString());
            while (File.Exists(filePath))
            {
                filePath = Path.Combine(Path.GetTempPath(), new Random().Next(1, 10000).ToString());
            }
            return filePath;
        }
    }
}