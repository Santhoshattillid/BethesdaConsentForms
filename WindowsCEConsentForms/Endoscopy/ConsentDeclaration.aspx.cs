using System;
using System.Web.UI;
using WindowsCEConsentForms.FormHandlerService;

namespace WindowsCEConsentForms.Endoscopy
{
    public partial class ConsentDeclaration1 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DeclarationSignatures.BtnCompleted.Click += BtnCompleted_Click;
            DeclarationSignatures.BtnReset.Click += BtnReset_Click;
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            ConsentSignatures.ResetSignatures();
            DeclarationSignatures.ResetSignatures();
            DeclarationSignatures.ChkPatientisUnableToSign.Checked = false;
            DeclarationSignatures.SetPanels(false);
        }

        protected void BtnCompleted_Click(object sender, EventArgs e)
        {
            try
            {
                const ConsentType consentType = ConsentType.Endoscopy;

                //validation
                var lblError = DeclarationSignatures.LblError;

                lblError.Text = string.Empty;

                DeclarationSignatures.ValidateForm();

                if (string.IsNullOrEmpty(Request.Form[SignatureType.DoctorSign1.ToString()]) ||
                   string.IsNullOrEmpty(Request.Form[SignatureType.DoctorSign2.ToString()]) ||
                   string.IsNullOrEmpty(Request.Form[SignatureType.DoctorSign3.ToString()]) ||
                   string.IsNullOrEmpty(Request.Form[SignatureType.DoctorSign4.ToString()]) ||
                   string.IsNullOrEmpty(Request.Form[SignatureType.DoctorSign5.ToString()]))
                {
                    lblError.Text += "Please input signatures.";
                }

                if (!string.IsNullOrEmpty(lblError.Text))
                    return;

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

                if (DoctorsAndProcedures1.SaveDoctorsAndProcedures(formHandlerServiceClient, patientId))
                {
                    DeclarationSignatures.SaveForm(formHandlerServiceClient, patientId);

                    ConsentSignatures.SaveForm(formHandlerServiceClient, patientId, consentType);

                    string ip = Request.ServerVariables["REMOTE_ADDR"];
                    string device;
                    if (Request.Browser.IsMobileDevice)
                        device = Request.Browser.Browser + " " + Request.Browser.Version;
                    else
                        device = Request.Browser.Browser + " " + Request.Browser.Version;

                    formHandlerServiceClient.UpdateTrackingInfo(patientId, new TrackingInfo { IP = ip, Device = device },
                                                                consentType.ToString());

                    Utilities.GeneratePdfAndUploadToSharePointSite(formHandlerServiceClient, consentType, patientId);

                    Response.Redirect(Utilities.GetNextFormUrl(consentType, Session));
                }
                else
                    lblError.Text += "Please input procedures in all boxes.";
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}