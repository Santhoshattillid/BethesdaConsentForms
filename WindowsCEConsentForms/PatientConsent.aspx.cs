using System;
using System.Data;
using WindowsCEConsentForms.FormHandlerService;

namespace WindowsCEConsentForms
{
    public partial class ConsentForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LblError.Text = string.Empty;
            if (!IsPostBack)
            {
                RdoBHE.Enabled = false;
                RdoBMH.Enabled = false;
            }
        }

        protected void DdlPatientIds_SelectedIndexChanged(object sender, EventArgs e)
        {
            // load all the fields here
            try
            {
                // loading select form type box and patient details
                if (DdlPatientIds.SelectedIndex > 0)
                {
                    var formHandlerServiceClient = new ConsentFormSvcClient();
                    var patientDetail = formHandlerServiceClient.GetPatientDetail(DdlPatientIds.SelectedValue, ConsentType.None.ToString());
                    if (patientDetail != null)
                    {
                        LblId.Text = patientDetail.PatientHash; // DdlPatientIds.SelectedValue;
                        LblName.Text = patientDetail.name;
                        LblAdmDate.Text = patientDetail.AdmDate.ToString("MMM dd yyyy");
                        LblAge.Text = patientDetail.age.ToString();
                        LblAttDr.Text = patientDetail.AttnDr;
                        LblGender.Text = patientDetail.gender;
                        LblSalutation.Text = patientDetail.MRHash;
                        DdlFormList.Enabled = true;
                        try
                        {
                            Session.Add("PatientID", DdlPatientIds.SelectedValue);
                        }
                        catch (Exception)
                        {
                            Session["PatientID"] = DdlPatientIds.SelectedValue;
                        }
                    }
                    else
                    {
                        LblError.Text = "The patient record is not found.";
                        Reset();
                    }
                }
                else
                {
                    Reset();
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            try
            {
                if (DdlPatientIds.Items.Count > 0)
                    DdlPatientIds.SelectedIndex = 0;
                if (DdlFormList.Items.Count > 0)
                    DdlFormList.SelectedIndex = 0;
                ClearEmpFields();
                RdoBMH.Checked = false;
                RdoBHE.Checked = false;
                DdlPatientIds.Items.Clear();
                DdlFormList.Items.Clear();
            }
            catch (Exception)
            {
                return;
            }
        }

        private void ClearEmpFields()
        {
            LblId.Text = string.Empty;
            LblAdmDate.Text = string.Empty;
            LblAge.Text = string.Empty;
            LblAttDr.Text = string.Empty;
            LblError.Text = string.Empty;
            LblGender.Text = string.Empty;
            LblName.Text = string.Empty;
            LblSalutation.Text = string.Empty;
            ChkBCOrR.Checked = false;
            ChkCCLC.Checked = false;
            ChkEC.Checked = false;
            ChkSurgicalConcent.Checked = false;
        }

        protected void DdlFormList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ChkSurgicalConcent.Enabled = (DdlFormList.SelectedIndex > 0);
                ChkPICCConsent.Enabled = (DdlFormList.SelectedIndex > 0);
                ChkORConsent.Enabled = (DdlFormList.SelectedIndex > 0);
                ChkBCOrR.Enabled = (DdlFormList.SelectedIndex > 0);
                ChkEC.Enabled = (DdlFormList.SelectedIndex > 0);
                ChkCCLC.Enabled = (DdlFormList.SelectedIndex > 0);
                ChkPA.Enabled = (DdlFormList.SelectedIndex > 0);

                //ChkSurgicalConcent.Checked = (DdlFormList.SelectedIndex > 0);
                if (DdlFormList.SelectedIndex == 0)
                    LblError.Text = "Please select form type.";

                PnlConsentChkboxes.Visible = DdlFormList.SelectedIndex != 2;
                PnlPrintLinks.Visible = DdlFormList.SelectedIndex == 2;
                BtnSign.Enabled = DdlFormList.SelectedIndex != 2;

                if (DdlFormList.SelectedIndex == 2)
                    LblError.Text = string.Empty;
            }
            catch (Exception)
            {
                return;
            }
        }

        // un used code
        protected void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                LblError.Text = string.Empty;
                if (DdlPatientIds.SelectedIndex == 0)
                {
                    LblError.Text = "Please select patient id and print";
                    return;
                }
                if (DdlFormList.SelectedIndex == 0)
                {
                    LblError.Text = "Please select form type and print";
                    return;
                }
                if (!ChkBCOrR.Checked && !ChkCCLC.Checked && !ChkEC.Checked && !ChkSurgicalConcent.Checked)
                {
                    LblError.Text = "Please select any one of the consent and print";
                    return;
                }
                Response.Redirect("/SurgicalConsentPrint.aspx?PatientId=" + DdlPatientIds.SelectedValue);
            }
            catch (Exception)
            {
            }
        }

        protected void BtnSign_Click(object sender, EventArgs e)
        {
            try
            {
                LblError.Text = string.Empty;

                if (string.IsNullOrEmpty(TxtEmployeeID.Text.Trim()))
                {
                    Reset();
                    LblError.Text = "Employee ID field should not be empty.";
                }

                if (DdlPatientIds.SelectedIndex == 0)
                {
                    LblError.Text = "Please Select Patient Id";
                    return;
                }
                if (DdlFormList.SelectedIndex == 0)
                {
                    LblError.Text = "Please Select Form Type";
                    return;
                }
                if (!ChkBCOrR.Checked && !ChkCCLC.Checked && !ChkEC.Checked && !ChkSurgicalConcent.Checked && !ChkPICCConsent.Checked && !ChkORConsent.Checked && !ChkPA.Checked)
                {
                    LblError.Text = "Please Select any one of the above Consent";
                    return;
                }

                //actual storage part starts here

                Session.Add("SurgicalConsent", ChkSurgicalConcent.Checked);
                Session.Add("Cardiovascular", ChkCCLC.Checked);
                Session.Add("OutsideORConsent", ChkORConsent.Checked);
                Session.Add("EndoscopyConsent", ChkEC.Checked);
                Session.Add("BloodConsentRefusal", ChkBCOrR.Checked);
                Session.Add("PlasmanApheresis", ChkPA.Checked);
                Session.Add("PICCConsent", ChkPICCConsent.Checked);

                if (ChkSurgicalConcent.Checked)
                {
                    Response.Redirect("/Surgical/ConsentDeclaration.aspx");
                    return;
                }
                if (ChkCCLC.Checked)
                {
                    Response.Redirect("/Cardiovascular/ConsentDeclaration.aspx");
                    return;
                }
                if (ChkORConsent.Checked)
                {
                    Response.Redirect("/OutsideOR/ConsentDeclaration.aspx");
                    return;
                }
                if (ChkEC.Checked)
                {
                    Response.Redirect("/Endoscopy/ConsentDeclaration.aspx");
                    return;
                }
                if (ChkBCOrR.Checked)
                {
                    Response.Redirect("/BloodConsentOrRefusal/ConsentDeclaration.aspx");
                }
                if (ChkPA.Checked)
                {
                    Response.Redirect("/PlasmanApheresis/ConsentDeclaration.aspx");
                }
                if (ChkPICCConsent.Checked)
                {
                    Response.Redirect("/PICC/ConsentDeclaration.aspx");
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        protected void RdoBMH_CheckedChanged(object sender, EventArgs e)
        {
            ClearEmpFields();
            LoadPatients("BHW");
            RdoBHE.Checked = !RdoBMH.Checked;
        }

        protected void RdoBHE_CheckedChanged(object sender, EventArgs e)
        {
            ClearEmpFields();
            LoadPatients("BHE");
            RdoBMH.Checked = !RdoBHE.Checked;
        }

        private void LoadPatients(string location)
        {
            // loading patient ids
            DdlPatientIds.Items.Clear();
            var formHandlerServiceClient = new ConsentFormSvcClient();
            DdlPatientIds.Items.Add("---------Select Patient--------");
            var patientList = formHandlerServiceClient.GetPatientfromLocation(location);
            if (patientList != null)
            {
                foreach (DataRow row in patientList.Rows)
                {
                    if (!string.IsNullOrEmpty(row["BirthDate"].ToString()) && !string.IsNullOrEmpty(row["Lname"].ToString()) && !string.IsNullOrEmpty(row["Fname"].ToString()) && !string.IsNullOrEmpty(row["PatientId"].ToString()))
                    {
                        var dt = Convert.ToDateTime(row["BirthDate"].ToString());
                        DdlPatientIds.Items.Add(new System.Web.UI.WebControls.ListItem(row["Lname"] + ", " + row["Fname"] + ", " + dt.ToShortDateString(), row["PatientId"].ToString()));
                    }
                }
            }
            DdlFormList.Items.Clear();
            DdlFormList.Items.Add("--Select Consent Form Type--");
            DdlFormList.Items.Add("Name Printed in Consent Form");
            DdlFormList.Items.Add("Blank Consent Form");
            DdlFormList.SelectedIndex = 0;
            DdlPatientIds.SelectedIndex = 0;
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtEmployeeID.Text.Trim()))
            {
                LblError.Text = "Employee ID field should not be empty.";
            }
            else
            {
                var formHanlderServiceClient = new ConsentFormSvcClient();
                if (formHanlderServiceClient.IsValidEmployee(TxtEmployeeID.Text.Trim()))
                {
                    RdoBHE.Enabled = true;
                    RdoBMH.Enabled = true;
                    LblError2.Text = string.Empty;
                }
                else
                {
                    Reset();
                    RdoBHE.Enabled = false;
                    RdoBMH.Enabled = false;
                    LblError2.Text = "Please input valid employee ID.";
                }
            }
        }
    }
}