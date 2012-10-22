using System;
using System.Data;
using System.Drawing.Imaging;
using System.Text;
using WindowsCEConsentForms.ConsentFormsService;

namespace WindowsCEConsentForms
{
    public partial class SurgicalConsentDeclaration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    SetPanels(false);
                    if (Utilities.IsDevelopmentMode)
                    {
                        Session["PatientID"] = 1;
                    }

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
                            patientId = Request.QueryString["PatientId"];
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
                        LblPatientMRId.Text = patientDetail.MRHash;
                        LblTime.Text = DateTime.Now.ToShortTimeString();
                        LbldoctorName.Text = string.Empty;
                        if (!string.IsNullOrEmpty(patientDetail.PrimaryDoctorId))
                        {
                            var doctorDetail = formHandlerServiceClient.GetPrimaryDoctorDetail(patientDetail.PrimaryDoctorId);
                            if (doctorDetail != null)
                                LbldoctorName.Text += doctorDetail.Fname + " " + doctorDetail.Lname;
                            foreach (DataRow row in formHandlerServiceClient.GetAssociatedPhysiciansList(patientDetail.PrimaryDoctorId).Rows)
                            {
                                LbldoctorName.Text += " " + row["Lname"].ToString().Trim() + " " + row["Fname"].ToString().Trim();
                            }
                        }

                        //if (!string.IsNullOrEmpty(patientDetail.AssociatedDoctorId))
                        //{
                        //var doctorDetail = formHandlerServiceClient.GetAssociateDoctorDetail(patientDetail.PrimaryDoctorId);
                        //if (doctorDetail != null)
                        //{
                        //    if (!string.IsNullOrEmpty(LbldoctorName.Text))
                        //        LbldoctorName.Text += "  ,  ";
                        //    LbldoctorName.Text += doctorDetail.Fname + " " + doctorDetail.Lname;
                        //}
                        //}
                        LblProcedurename.Text = patientDetail.ProcedureName;

                        //TxtPatientNotSignedBecause.Text = patientDetail.UnableToSignReason;
                        /*

                        // Loading Signatures based on the selected patient
                        ViewState["Signature1"] = formHandlerServiceClient.GetPatientSignature(patientId, "SurgicalConsent", "signature7");
                        ViewState["Signature2"] = formHandlerServiceClient.GetPatientSignature(patientId, "SurgicalConsent", "signature8");
                        ViewState["Signature3"] = formHandlerServiceClient.GetPatientSignature(patientId, "SurgicalConsent", "signature9");
                        ViewState["Signature4"] = formHandlerServiceClient.GetPatientSignature(patientId, "SurgicalConsent", "signature10");
                        ViewState["Signature5"] = formHandlerServiceClient.GetPatientSignature(patientId, "SurgicalConsent", "signature11");
                         */
                    }
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

                //validation

                LblError.Text = string.Empty;

                if (ChkPatientisUnableToSign.Checked)
                {
                    if (string.IsNullOrEmpty(TxtPatientNotSignedBecause.Text.Trim()))
                    {
                        LblError.Text = "Please input reason for why patient not able sign.";
                    }
                    if (string.IsNullOrEmpty(Request.Form["HdnImage1"]))
                    {
                        LblError.Text += " <br /> Please input patient authorized person signature.";
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(Request.Form["HdnImage2"]))
                    {
                        LblError.Text += " <br /> Please input patient  signature.";
                    }
                }

                if (!string.IsNullOrEmpty(LblError.Text))
                {
                    return;
                }

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
                if (Request.Form["HdnImage1"] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form["HdnImage1"]);

                    // If patient is unable to sing/person authorized to sign consent / relationship to patient
                    var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), "SurgicalConsent", "signature7");
                }

                // updating signature3
                if (Request.Form["HdnImage2"] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form["HdnImage2"]); // Patient Signature
                    var result = formHandlerServiceClient.SavePatientSignature(patientId, ASCIIEncoding.ASCII.GetString(bytes), "SurgicalConsent", "signature8");
                }

                if (Request.Form["HdnImage3"] != null)
                {
                    // updating signature4
                    var bytes = Encoding.ASCII.GetBytes(Request.Form["HdnImage3"]); // Translated by (name & empl.#)
                    var result = formHandlerServiceClient.SavePatientSignature(patientId, ASCIIEncoding.ASCII.GetString(bytes), "SurgicalConsent", "signature9");
                }

                // updating signature5
                if (Request.Form["HdnImage4"] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form["HdnImage4"]);
                    var result = formHandlerServiceClient.SavePatientSignature(patientId, ASCIIEncoding.ASCII.GetString(bytes), "SurgicalConsent", "signature10");
                }

                // updating signature6
                if (Request.Form["HdnImage5"] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form["HdnImage5"]);
                    var result = formHandlerServiceClient.SavePatientSignature(patientId, ASCIIEncoding.ASCII.GetString(bytes), "SurgicalConsent", "signature11");
                }

                /* temp code to generate images and store into local folder for testing
                var signatureToImage = new SignatureToImage();
                for(int i=1;i<6;i++)
                    signatureToImage.SigJsonToImage(Request.Form["HdnImage" + i.ToString()]).Save(@"C:\Users\santhosh\Desktop\" + i.ToString() + ".jpg",ImageFormat.Jpeg);
                */

                string ip = Request.ServerVariables["REMOTE_ADDR"];
                string device;
                if (Request.Browser.IsMobileDevice)
                    device = Request.Browser.Browser + " " + Request.Browser.Version;
                else
                    device = Request.Browser.Browser + " " + Request.Browser.Version;

                formHandlerServiceClient.UpdateTrackingInfo(patientId, new TrackingInfo { IP = ip, Device = device });
                formHandlerServiceClient.UpdatePatientUnableSignReason(patientId, ChkPatientisUnableToSign.Checked ? TxtPatientNotSignedBecause.Text : string.Empty);

                formHandlerServiceClient.GenerateAndUploadPDFtoSharePoint("http://devsp1.atbapps.com:5555/SurgicalConsentPrintV3.aspx?PatientId=" + patientId, patientId, "SurgicalConsentForm1");

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

        protected void ChkPatientisUnableToSign_CheckedChanged(object sender, EventArgs e)
        {
            SetPanels(ChkPatientisUnableToSign.Checked);
        }

        private void SetPanels(bool flag)
        {
            PnlPatientReason1.Visible = flag;
            PnlPatientReason2.Visible = flag;
            PnlPatientSign.Visible = !flag;
        }
    }
}