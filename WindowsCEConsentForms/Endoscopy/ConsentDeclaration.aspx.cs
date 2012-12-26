using System;
using System.Collections.Generic;
using System.Text;
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
            DoctorsAndProcedures1.Reset();
            ConsentSignatures.ResetSignatures();
            DeclarationSignatures.ResetSignatures();
        }

        protected void BtnCompleted_Click(object sender, EventArgs e)
        {
            try
            {
                const ConsentType consentType = ConsentType.Endoscopy;

                //validation
                var lblError = DeclarationSignatures.LblError;

                lblError.Text = string.Empty;

                var doctorsAndProcedures = DoctorsAndProcedures1.GetDoctorsAndProcedures().ToArray();

                if (doctorsAndProcedures.Length == 0)
                    lblError.Text += "<br /> Please select physicians and procedures.";

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

                string ip = Request.ServerVariables["REMOTE_ADDR"];
                string device;
                if (Request.Browser.IsMobileDevice)
                    device = Request.Browser.Browser + " " + Request.Browser.Version;
                else
                    device = Request.Browser.Browser + " " + Request.Browser.Version;

                var signatureses = new List<Signatures>();

                if (Request.Form[SignatureType.DoctorSign1.ToString()] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.DoctorSign1.ToString()]);
                    signatureses.Add(new Signatures
                    {
                        _name = string.Empty,
                        _signatureContent = Encoding.ASCII.GetString(bytes),
                        _signatureType = SignatureType.DoctorSign1
                    });
                }

                if (Request.Form[SignatureType.DoctorSign2.ToString()] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.DoctorSign2.ToString()]);
                    signatureses.Add(new Signatures
                    {
                        _name = string.Empty,
                        _signatureContent = Encoding.ASCII.GetString(bytes),
                        _signatureType = SignatureType.DoctorSign2
                    });
                }

                if (Request.Form[SignatureType.DoctorSign3.ToString()] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.DoctorSign3.ToString()]);
                    signatureses.Add(new Signatures
                    {
                        _name = string.Empty,
                        _signatureContent = Encoding.ASCII.GetString(bytes),
                        _signatureType = SignatureType.DoctorSign3
                    });
                }

                if (Request.Form[SignatureType.DoctorSign4.ToString()] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.DoctorSign4.ToString()]);
                    signatureses.Add(new Signatures
                    {
                        _name = string.Empty,
                        _signatureContent = Encoding.ASCII.GetString(bytes),
                        _signatureType = SignatureType.DoctorSign4
                    });
                }

                if (Request.Form[SignatureType.DoctorSign5.ToString()] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.DoctorSign5.ToString()]);
                    signatureses.Add(new Signatures
                    {
                        _name = string.Empty,
                        _signatureContent = Encoding.ASCII.GetString(bytes),
                        _signatureType = SignatureType.DoctorSign5
                    });
                }

                signatureses.AddRange(DeclarationSignatures.GetSignatures());

                var treatment = new Treatment
                {
                    _patientId = patientId,
                    _consentType = consentType,
                    _signatureses = signatureses.ToArray(),
                    _isPatientUnableSign = DeclarationSignatures.ChkPatientisUnableToSign.Checked,
                    _unableToSignReason = DeclarationSignatures.TxtPatientNotSignedBecause.Text,
                    _translatedBy = DeclarationSignatures.TxtTranslatedBy.Text,
                    _trackingInformation = new TrackingInformation
                    {
                        _device = device,
                        _iP = ip
                    },
                    _doctorAndPrcedures = doctorsAndProcedures
                };

                if (treatment._doctorAndPrcedures.GetUpperBound(0) < 0)
                {
                    lblError.Text += "Please input procedures.";
                    return;
                }

                var formHandlerServiceClient = new ConsentFormSvcClient();
                formHandlerServiceClient.AddTreatment(treatment);
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