using System;
using System.Data;
using System.Text;
using WindowsCEConsentForms.ConsentFormsService;

namespace WindowsCEConsentForms
{
    public partial class Declaration : System.Web.UI.UserControl
    {
        public ConsentType ConsentType;

        public string ConsentFolder;

        public string Heading;

        public string SubHeading;

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
                        LbldoctorName.Text = string.Empty;
                        if (!string.IsNullOrEmpty(patientDetail.PrimaryDoctorId))
                        {
                            var doctorDetail = formHandlerServiceClient.GetPrimaryDoctorDetail(patientDetail.PrimaryDoctorId);
                            if (doctorDetail != null)
                                LbldoctorName.Text += doctorDetail.Fname + " " + doctorDetail.Lname;
                            LblAssociateDoctors.Text = string.Empty;
                            foreach (DataRow row in formHandlerServiceClient.GetAssociatedPhysiciansList(patientDetail.PrimaryDoctorId).Rows)
                            {
                                LbldoctorName.Text += " " + row["Lname"].ToString().Trim() + " " + row["Fname"].ToString().Trim();
                                if (!string.IsNullOrEmpty(LblAssociateDoctors.Text))
                                    LblAssociateDoctors.Text += " , ";
                                LblAssociateDoctors.Text += row["Lname"].ToString().Trim() + " " +
                                                               row["Fname"].ToString().Trim();
                            }
                        }
                        LblProcedurename.Text = patientDetail.ProcedureName;

                        // Loading Signatures based on the selected patient
                        /*ViewState["Signature1"] = formHandlerServiceClient.GetPatientSignature(patientId, "SurgicalConsent", "signature7");
                        ViewState["Signature2"] = formHandlerServiceClient.GetPatientSignature(patientId, "SurgicalConsent", "signature8");
                        ViewState["Signature3"] = formHandlerServiceClient.GetPatientSignature(patientId, "SurgicalConsent", "signature9");
                        ViewState["Signature4"] = formHandlerServiceClient.GetPatientSignature(patientId, "SurgicalConsent", "signature10");
                        ViewState["Signature5"] = formHandlerServiceClient.GetPatientSignature(patientId, "SurgicalConsent", "signature11");
                         */
                    }
                }
                else
                {
                    for (int i = 1; i < 6; i++)
                    {
                        if (Request.Form["HdnImage" + i.ToString()] != null)
                            ViewState["Signature" + i.ToString()] = Request.Form["HdnImage" + i.ToString()];
                    }
                }
            }
            catch (Exception)
            {
                return;
                //Response.Redirect("/PatientConsent.aspx");
            }
        }

        protected void BtnCompleted_Click(object sender, EventArgs e)
        {
            try
            {
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

                if (string.IsNullOrEmpty(Request.Form["HdnImage4"]))
                {
                    LblError.Text += " <br /> Please input witness signature.";
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

                // updating signature2
                if (Request.Form["HdnImage1"] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form["HdnImage1"]);

                    // If patient is unable to sign/person authorized to sign consent / relationship to patient
                    var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), ConsentType.ToString(), "signature7");
                }

                // updating signature3
                if (Request.Form["HdnImage2"] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form["HdnImage2"]); // Patient Signature
                    var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), ConsentType.ToString(), "signature8");
                }

                if (Request.Form["HdnImage3"] != null)
                {
                    // updating signature4
                    var bytes = Encoding.ASCII.GetBytes(Request.Form["HdnImage3"]); // Translated by (name & empl.#)
                    var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), ConsentType.ToString(), "signature9");
                }

                // updating signature5
                if (Request.Form["HdnImage4"] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form["HdnImage4"]);
                    var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), ConsentType.ToString(), "signature10");
                }

                // updating signature6
                if (Request.Form["HdnImage5"] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form["HdnImage5"]);
                    var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), ConsentType.ToString(), "signature11");
                }

                string ip = Request.ServerVariables["REMOTE_ADDR"];
                string device;
                if (Request.Browser.IsMobileDevice)
                    device = Request.Browser.Browser + " " + Request.Browser.Version;
                else
                    device = Request.Browser.Browser + " " + Request.Browser.Version;

                formHandlerServiceClient.UpdateTrackingInfo(patientId, new TrackingInfo { IP = ip, Device = device });

                formHandlerServiceClient.UpdatePatientUnableSignReason(patientId, ChkPatientisUnableToSign.Checked ? TxtPatientNotSignedBecause.Text : string.Empty);

                formHandlerServiceClient.GenerateAndUploadPDFtoSharePoint("http://devsp1.atbapps.com:5555/" + ConsentFolder + "/ConsentPrint.aspx?PatientId=" + patientId, patientId, ConsentType.ToString());

                Response.Redirect(Utilities.GetNextFormUrl(ConsentType, Session));
            }
            catch (Exception)
            {
                return;
            }
        }

        protected void BtnPrevious_Click1(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("/" + ConsentFolder + "/Consent.aspx");
            }
            catch (Exception)
            {
                return;
            }
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
            PnlAdditionalwitness.Visible = flag;
        }
    }
}