using System;
using System.Text;
using System.Web.UI;
using WindowsCEConsentForms.ConsentFormsService;

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
                    lblError.Text = "Please input signatures.";
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

                DoctorsAndProcedures1.SaveDoctorsAndProcedures(formHandlerServiceClient, patientId);
                DeclarationSignatures.SaveForm(formHandlerServiceClient, patientId);

                if (Request.Form[SignatureType.DoctorSign1.ToString()] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.DoctorSign1.ToString()]);
                    bool result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), consentType.ToString(), SignatureType.DoctorSign1.ToString());
                }

                if (Request.Form[SignatureType.DoctorSign2.ToString()] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.DoctorSign2.ToString()]);
                    var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), consentType.ToString(), SignatureType.DoctorSign2.ToString());
                }

                if (Request.Form[SignatureType.DoctorSign3.ToString()] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.DoctorSign3.ToString()]);
                    var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), consentType.ToString(), SignatureType.DoctorSign3.ToString());
                }

                if (Request.Form[SignatureType.DoctorSign4.ToString()] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.DoctorSign4.ToString()]);
                    var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), consentType.ToString(), SignatureType.DoctorSign4.ToString());
                }

                if (Request.Form[SignatureType.DoctorSign5.ToString()] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.DoctorSign5.ToString()]);
                    var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), consentType.ToString(), SignatureType.DoctorSign5.ToString());
                }

                string ip = Request.ServerVariables["REMOTE_ADDR"];
                string device;
                if (Request.Browser.IsMobileDevice)
                    device = Request.Browser.Browser + " " + Request.Browser.Version;
                else
                    device = Request.Browser.Browser + " " + Request.Browser.Version;

                formHandlerServiceClient.UpdateTrackingInfo(patientId, new TrackingInfo { IP = ip, Device = device }, consentType.ToString());

                Utilities.GeneratePdfAndUploadToSharePointSite(formHandlerServiceClient, consentType, patientId);

                Response.Redirect(Utilities.GetNextFormUrl(consentType, Session));
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}