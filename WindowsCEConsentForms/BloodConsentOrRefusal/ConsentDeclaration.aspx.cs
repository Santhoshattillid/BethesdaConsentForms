using System;
using System.Text;
using WindowsCEConsentForms.ConsentFormsService;

namespace WindowsCEConsentForms.BloodConsentOrRefusal
{
    public partial class Consent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.EnableViewState = true;
            SetPanels(false);
            for (int i = 0; i < 7; i++)
                ViewState["Signature" + i] = string.Empty;
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
                    var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), ConsentType.BloodConsentOrRefusal.ToString(), "signature7");
                }

                // updating signature3
                if (Request.Form["HdnImage2"] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form["HdnImage2"]); // Patient Signature
                    var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), ConsentType.BloodConsentOrRefusal.ToString(), "signature8");
                }

                if (Request.Form["HdnImage3"] != null)
                {
                    // updating signature4
                    var bytes = Encoding.ASCII.GetBytes(Request.Form["HdnImage3"]); // Translated by (name & empl.#)
                    var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), ConsentType.BloodConsentOrRefusal.ToString(), "signature9");
                }

                // updating signature5
                if (Request.Form["HdnImage4"] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form["HdnImage4"]);
                    var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), ConsentType.BloodConsentOrRefusal.ToString(), "signature10");
                }

                // updating signature6
                if (Request.Form["HdnImage5"] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form["HdnImage5"]);
                    var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), ConsentType.BloodConsentOrRefusal.ToString(), "signature11");
                }

                string ip = Request.ServerVariables["REMOTE_ADDR"];
                string device;
                if (Request.Browser.IsMobileDevice)
                    device = Request.Browser.Browser + " " + Request.Browser.Version;
                else
                    device = Request.Browser.Browser + " " + Request.Browser.Version;

                formHandlerServiceClient.UpdateTrackingInfo(patientId, new TrackingInfo { IP = ip, Device = device });

                formHandlerServiceClient.UpdatePatientUnableSignReason(patientId, ChkPatientisUnableToSign.Checked ? TxtPatientNotSignedBecause.Text : string.Empty);

                formHandlerServiceClient.GenerateAndUploadPDFtoSharePoint("http://devsp1.atbapps.com:5555/BloodConsentOrRefusal/ConsentPrint.aspx?PatientId=" + patientId, patientId, ConsentType.BloodConsentOrRefusal.ToString());

                Response.Redirect(Utilities.GetNextFormUrl(ConsentType.BloodConsentOrRefusal, Session));
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