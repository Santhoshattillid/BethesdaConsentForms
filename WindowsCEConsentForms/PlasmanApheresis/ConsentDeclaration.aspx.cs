using System;
using System.Text;
using WindowsCEConsentForms.ConsentFormsService;

namespace WindowsCEConsentForms.PlasmanApheresis
{
    public partial class ConsentDeclaration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string patientId;
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
                    patientId = string.Empty;
                }
            }

            if (!string.IsNullOrEmpty(patientId))
            {
                var formHandlerServiceClient = new FormHandlerServiceClient();
                var patientDetail = formHandlerServiceClient.GetPatientDetail(patientId, ConsentType.PlasmanApheresis.ToString());
                if (patientDetail != null)
                {
                    LblPatientName.Text = patientDetail.name;

                    //if (DoctorsAndProcedures1.DdlPrimaryDoctors.SelectedItem != null)
                    //{
                    //    LblPhysicianName.Text = DoctorsAndProcedures1.DdlPrimaryDoctors.SelectedItem.Text;
                    //    LblPhyisicianList.Text = DoctorsAndProcedures1.DdlPrimaryDoctors.SelectedItem.Text;
                    //}
                }
            }

            DeclarationSignatures.BtnCompleted.Click += BtnCompleted_Click;
            DeclarationSignatures.BtnReset.Click += BtnReset_Click;

            if (!IsPostBack)
                ResetSignatures();
            else
            {
                if (Request.Form[SignatureType.DoctorSign1.ToString()] != null)
                    ViewState[SignatureType.DoctorSign1.ToString()] = Request.Form[SignatureType.DoctorSign1.ToString()];
                if (Request.Form[SignatureType.DoctorSign2.ToString()] != null)
                    ViewState[SignatureType.DoctorSign2.ToString()] = Request.Form[SignatureType.DoctorSign2.ToString()];
                if (Request.Form[SignatureType.DoctorSign3.ToString()] != null)
                    ViewState[SignatureType.DoctorSign3.ToString()] = Request.Form[SignatureType.DoctorSign3.ToString()];
                if (Request.Form[SignatureType.DoctorSign4.ToString()] != null)
                    ViewState[SignatureType.DoctorSign4.ToString()] = Request.Form[SignatureType.DoctorSign4.ToString()];
                if (Request.Form[SignatureType.DoctorSign5.ToString()] != null)
                    ViewState[SignatureType.DoctorSign5.ToString()] = Request.Form[SignatureType.DoctorSign5.ToString()];
                if (Request.Form[SignatureType.DoctorSign6.ToString()] != null)
                    ViewState[SignatureType.DoctorSign6.ToString()] = Request.Form[SignatureType.DoctorSign6.ToString()];
                if (Request.Form[SignatureType.DoctorSign7.ToString()] != null)
                    ViewState[SignatureType.DoctorSign7.ToString()] = Request.Form[SignatureType.DoctorSign7.ToString()];
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            ResetSignatures();

            DeclarationSignatures.ResetSignatures();
            DeclarationSignatures.ChkPatientisUnableToSign.Checked = false;
            DeclarationSignatures.SetPanels(false);
        }

        protected void BtnCompleted_Click(object sender, EventArgs e)
        {
            try
            {
                const ConsentType consentType = ConsentType.PlasmanApheresis;

                //validation
                var lblError = DeclarationSignatures.LblError;
                var chkPatientisUnableToSign = DeclarationSignatures.ChkPatientisUnableToSign;
                var txtPatientNotSignedBecause = DeclarationSignatures.TxtPatientNotSignedBecause;

                lblError.Text = string.Empty;

                if (string.IsNullOrEmpty(Request.Form[SignatureType.DoctorSign1.ToString()]) ||
                   string.IsNullOrEmpty(Request.Form[SignatureType.DoctorSign2.ToString()]) ||
                   string.IsNullOrEmpty(Request.Form[SignatureType.DoctorSign3.ToString()]) ||
                   string.IsNullOrEmpty(Request.Form[SignatureType.DoctorSign4.ToString()]))
                {
                    lblError.Text = "Please input signatures.";
                }

                if (chkPatientisUnableToSign.Checked)
                {
                    if (string.IsNullOrEmpty(txtPatientNotSignedBecause.Text.Trim()))
                        lblError.Text += " <br /> Please input reason for why patient not able sign.";
                    if (string.IsNullOrEmpty(Request.Form[SignatureType.PatientAuthorizeSign.ToString()]))
                        lblError.Text += " <br /> Please input patient authorized person signature.";
                }
                else
                {
                    if (string.IsNullOrEmpty(Request.Form[SignatureType.PatientSign.ToString()]))
                        lblError.Text += " <br /> Please input patient  signature.";
                }

                if (string.IsNullOrEmpty(Request.Form[SignatureType.WitnessSignature1.ToString()]))
                    lblError.Text += " <br /> Please input witness signature.";

                if (DeclarationSignatures.ChkTelephoneConsent.Checked && string.IsNullOrEmpty(Request.Form[SignatureType.WitnessSignature1.ToString()]))
                    lblError.Text += " <br /> Please input witness 2 signature.";

                if (!string.IsNullOrEmpty(lblError.Text))
                {
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

                formHandlerServiceClient.SaveDoctorsDetails(patientId, consentType.ToString(), DoctorsAndProcedures1.GetDoctorsAndProcedures().ToArray());

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

                if (Request.Form[SignatureType.PatientSign.ToString()] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.PatientSign.ToString()]);
                    var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), consentType.ToString(), SignatureType.PatientSign.ToString());
                }

                if (Request.Form[SignatureType.PatientAuthorizeSign.ToString()] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.PatientAuthorizeSign.ToString()]); // Patient Signature
                    var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), consentType.ToString(), SignatureType.PatientAuthorizeSign.ToString());
                }

                // updating signature5
                if (Request.Form[SignatureType.WitnessSignature1.ToString()] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.WitnessSignature1.ToString()]);
                    var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), consentType.ToString(), SignatureType.WitnessSignature1.ToString());
                }

                // updating signature6
                if (Request.Form[SignatureType.WitnessSignature2.ToString()] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.WitnessSignature2.ToString()]);
                    var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), consentType.ToString(), SignatureType.WitnessSignature2.ToString());
                }

                string ip = Request.ServerVariables["REMOTE_ADDR"];
                string device;
                if (Request.Browser.IsMobileDevice)
                    device = Request.Browser.Browser + " " + Request.Browser.Version;
                else
                    device = Request.Browser.Browser + " " + Request.Browser.Version;

                formHandlerServiceClient.UpdateTrackingInfo(patientId, new TrackingInfo { IP = ip, Device = device }, consentType.ToString());

                formHandlerServiceClient.UpdatePatientUnableSignReason(patientId, chkPatientisUnableToSign.Checked ? txtPatientNotSignedBecause.Text : string.Empty, consentType.ToString());

                formHandlerServiceClient.UpdateTranslatedby(patientId, consentType.ToString(), DeclarationSignatures.TxtTranslatedBy.Text);

                Utilities.GeneratePdfAndUploadToSharePointSite(formHandlerServiceClient, consentType, patientId);

                Response.Redirect(Utilities.GetNextFormUrl(consentType, Session));
            }
            catch (Exception)
            {
                return;
            }
        }

        private void ResetSignatures()
        {
            ViewState[SignatureType.DoctorSign1.ToString()] = string.Empty;
            ViewState[SignatureType.DoctorSign2.ToString()] = string.Empty;
            ViewState[SignatureType.DoctorSign3.ToString()] = string.Empty;
            ViewState[SignatureType.DoctorSign4.ToString()] = string.Empty;
            ViewState[SignatureType.DoctorSign5.ToString()] = string.Empty;
            ViewState[SignatureType.DoctorSign6.ToString()] = string.Empty;
            ViewState[SignatureType.DoctorSign7.ToString()] = string.Empty;
        }
    }
}