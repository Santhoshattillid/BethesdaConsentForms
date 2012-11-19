using System;
using System.Data;
using System.Text;
using WindowsCEConsentForms.ConsentFormsService;

namespace WindowsCEConsentForms.PICC
{
    public partial class PICCConsentDeclaration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SetPanels(false);
            if (!IsPostBack)
                ResetSignatures();
            else
            {
                if (Request.Form[SignatureType.PatientAuthorizeSign.ToString()] != null)
                    ViewState[SignatureType.PatientAuthorizeSign.ToString()] = Request.Form[SignatureType.PatientAuthorizeSign.ToString()];
                if (Request.Form[SignatureType.PatientSign.ToString()] != null)
                    ViewState[SignatureType.PatientSign.ToString()] = Request.Form[SignatureType.PatientSign.ToString()];
                if (Request.Form[SignatureType.TranslatedBySign.ToString()] != null)
                    ViewState[SignatureType.TranslatedBySign.ToString()] = Request.Form[SignatureType.TranslatedBySign.ToString()];
                if (Request.Form[SignatureType.WitnessSignature1.ToString()] != null)
                    ViewState[SignatureType.WitnessSignature1.ToString()] = Request.Form[SignatureType.WitnessSignature1.ToString()];
                if (Request.Form[SignatureType.WitnessSignature2.ToString()] != null)
                    ViewState[SignatureType.WitnessSignature2.ToString()] = Request.Form[SignatureType.WitnessSignature2.ToString()];
                if (Request.Form[SignatureType.PICCSignature.ToString()] != null)
                    ViewState[SignatureType.PICCSignature.ToString()] = Request.Form[SignatureType.PICCSignature.ToString()];
            }
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            DoctorsAndProcedures1.DdLProcedures.SelectedIndex = 0;
            DoctorsAndProcedures1.LblAssociatedDoctors.Text = string.Empty;
            DoctorsAndProcedures1.DdlPrimaryDoctors.SelectedIndex = 0;
            DoctorsAndProcedures1.HdnSelectedProcedures.Value = string.Empty;

            ResetSignatures();
            ChkPatientisUnableToSign.Checked = false;
            SetPanels(false);
        }

        protected void BtnCompleted_Click(object sender, EventArgs e)
        {
            try
            {
                //validation

                const ConsentType consentType = ConsentType.PICC;

                LblError.Text = string.Empty;

                if (DoctorsAndProcedures1.DdlPrimaryDoctors.SelectedIndex == 0)
                {
                    LblError.Text += "Please select primary and associated doctor";
                }

                if (string.IsNullOrEmpty(DoctorsAndProcedures1.HdnSelectedProcedures.Value))
                {
                    LblError.Text += " <br /> Please select the procedures and then go next.";
                }

                if (ChkPatientisUnableToSign.Checked)
                {
                    if (string.IsNullOrEmpty(TxtPatientNotSignedBecause.Text.Trim()))
                    {
                        LblError.Text += " <br /> Please input reason for why patient not able sign.";
                    }
                    if (string.IsNullOrEmpty(Request.Form[SignatureType.PatientAuthorizeSign.ToString()]))
                    {
                        LblError.Text += " <br /> Please input patient authorized person signature.";
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(Request.Form[SignatureType.PatientSign.ToString()]))
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

                string selectedProcedurenames = string.Empty;

                // validation for other procedure
                foreach (string procedurename in DoctorsAndProcedures1.HdnSelectedProcedures.Value.Split('#'))
                {
                    if (!string.IsNullOrEmpty(procedurename))
                    {
                        if (procedurename.Trim().ToLower() == "other")
                        {
                            if (string.IsNullOrEmpty(DoctorsAndProcedures1.TxtOtherProcedure.Text))
                            {
                                LblError.Text = "Please input your signatures in all the fields";
                                return;
                            }
                            selectedProcedurenames += DoctorsAndProcedures1.TxtOtherProcedure.Text;
                        }
                        else
                            selectedProcedurenames += procedurename + "#";
                    }
                }

                var formHandlerServiceClient = new FormHandlerServiceClient();

                formHandlerServiceClient.UpdateDoctorAssociation(patientId, DoctorsAndProcedures1.DdlPrimaryDoctors.SelectedValue, DoctorsAndProcedures1.LblAssociatedDoctors.Text, consentType.ToString());

                formHandlerServiceClient.UpdatePatientProcedures(patientId, selectedProcedurenames, consentType.ToString());

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

                if (Request.Form[SignatureType.TranslatedBySign.ToString()] != null)
                {
                    // updating signature4
                    var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.TranslatedBySign.ToString()]); // Translated by (name & empl.#)
                    var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), consentType.ToString(), SignatureType.TranslatedBySign.ToString());
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

                if (Request.Form[SignatureType.PICCSignature.ToString()] != null)
                {
                    var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.PICCSignature.ToString()]);
                    var result = formHandlerServiceClient.SavePatientSignature(patientId, Encoding.ASCII.GetString(bytes), consentType.ToString(), SignatureType.PICCSignature.ToString());
                }

                string ip = Request.ServerVariables["REMOTE_ADDR"];
                string device;
                if (Request.Browser.IsMobileDevice)
                    device = Request.Browser.Browser + " " + Request.Browser.Version;
                else
                    device = Request.Browser.Browser + " " + Request.Browser.Version;

                formHandlerServiceClient.UpdateTrackingInfo(patientId, new TrackingInfo { IP = ip, Device = device });
                formHandlerServiceClient.UpdatePatientUnableSignReason(patientId, ChkPatientisUnableToSign.Checked ? TxtPatientNotSignedBecause.Text : string.Empty);

                Utilities.GeneratePdfAndUploadToSharePointSite(formHandlerServiceClient, consentType, patientId);

                Response.Redirect("/PatientConsent.aspx");
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

        public void ResetSignatures()
        {
            ViewState[SignatureType.PatientAuthorizeSign.ToString()] = string.Empty;
            ViewState[SignatureType.PatientSign.ToString()] = string.Empty;
            ViewState[SignatureType.TranslatedBySign.ToString()] = string.Empty;
            ViewState[SignatureType.WitnessSignature1.ToString()] = string.Empty;
            ViewState[SignatureType.WitnessSignature2.ToString()] = string.Empty;
            ViewState[SignatureType.PICCSignature.ToString()] = string.Empty;
        }
    }
}