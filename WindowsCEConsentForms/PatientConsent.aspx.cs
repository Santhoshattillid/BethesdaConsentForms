using System;
using System.Data;
using WindowsCEConsentForms.ConsentFormsService;

namespace WindowsCEConsentForms
{
    public partial class ConsentForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    // loading patient ids
                    var formHandlerServiceClient = new FormHandlerServiceClient();
                    DdlPatientIds.Items.Add("---------Select Patient--------");
                    DdlFormList.Items.Add("--Select Consent Form Type--");
                    var patientList = formHandlerServiceClient.GetPatientList();
                    if (patientList != null)
                    {
                        foreach (DataRow row in patientList.Rows)
                        {
                            if (!string.IsNullOrEmpty(row["BirthDate"].ToString()) && !string.IsNullOrEmpty(row["Lname"].ToString()) && !string.IsNullOrEmpty(row["Fname"].ToString()) && !string.IsNullOrEmpty(row["PatientId"].ToString()))
                            {
                                var dt = Convert.ToDateTime(row["BirthDate"].ToString());
                                DdlPatientIds.Items.Add(
                                    new System.Web.UI.WebControls.ListItem(
                                        row["Lname"] + ", " + row["Fname"] + ", " +
                                        dt.ToShortDateString(), row["PatientId"].ToString()));
                            }
                        }
                    }
                    DdlFormList.Items.Add("Name Printed in Consent Form");
                    DdlFormList.Items.Add("Blank Consent Form");
                    DdlFormList.Items.Add("Pre Printed Order Form");
                    DdlPatientIds.SelectedIndex = 0;
                    DdlFormList.SelectedIndex = 0;

                    Session["NewSessionFor" + ConsentType.Surgical.ToString()] = true;
                    Session["NewSessionFor" + ConsentType.BloodConsentOrRefusal.ToString()] = true;
                    Session["NewSessionFor" + ConsentType.CardiacCathLab.ToString()] = true;
                    Session["NewSessionFor" + ConsentType.Endoscopy.ToString()] = true;
                    Session["NewSessionFor" + ConsentType.PlasmanApheresis.ToString()] = true;
                    Session["NewSessionFor" + ConsentType.OutsideOR.ToString()] = true;
                    Session["NewSessionFor" + ConsentType.PICC.ToString()] = true;
                }
                catch (Exception) { }
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
                    var formHandlerServiceClient = new FormHandlerServiceClient();
                    var patientDetail = formHandlerServiceClient.GetPatientDetail(DdlPatientIds.SelectedValue);
                    if (patientDetail != null)
                    {
                        LblId.Text = patientDetail.MRHash; // DdlPatientIds.SelectedValue;
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
            catch (Exception)
            {
                return;
            }
        }

        protected void DdlFormList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ChkSurgicalConcent.Enabled = (DdlFormList.SelectedIndex > 0);
                ChkPICCConsent.Enabled = (DdlFormList.SelectedIndex > 0);
                ChkORConsent.Enabled = (DdlFormList.SelectedIndex > 0);
                ChkBCOrR.Enabled = (DdlFormList.SelectedIndex > 0);

                //ChkSurgicalConcent.Checked = (DdlFormList.SelectedIndex > 0);
                if (DdlFormList.SelectedIndex == 0)
                    LblError.Text = "Please select form type.";
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
                if (!ChkBCOrR.Checked && !ChkCCLC.Checked && !ChkEC.Checked && !ChkSurgicalConcent.Checked && !ChkPICCConsent.Checked && !ChkORConsent.Checked)
                {
                    LblError.Text = "Please Select any one of the above Consent";
                    return;
                }

                //actual storage part starts here

                Session.Add("SurgicalConsent", ChkSurgicalConcent.Checked);
                Session.Add("CardiacCathLabConsent", ChkCCLC.Checked);
                Session.Add("OutsideORConsent", ChkORConsent.Checked);
                Session.Add("EndoscopyConsent", ChkEC.Checked);
                Session.Add("BloodConsentRefusal", ChkBCOrR.Checked);
                Session.Add("PlasmanApheresis", ChkPA.Checked);
                Session.Add("PICCConsent", ChkPICCConsent.Checked);

                if (ChkSurgicalConcent.Checked)
                {
                    Response.Redirect("/Surgical/Consent.aspx");
                    return;
                }
                if (ChkCCLC.Checked)
                {
                    Response.Redirect("/CardiacCathLabConsent.aspx");
                    return;
                }
                if (ChkORConsent.Checked)
                {
                    Response.Redirect("/OutsideOR/Consent.aspx");
                    return;
                }
                if (ChkEC.Checked)
                {
                    Response.Redirect("/EndoscopyConsent.aspx");
                    return;
                }
                if (ChkBCOrR.Checked)
                {
                    Response.Redirect("/BloodConsentOrRefusal/ConsentDeclaration.aspx");
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
    }
}