using System;
using WindowsCEConsentForms.ConsentFormsService;
using System.Data;

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
                            var dt = Convert.ToDateTime(row["BirthDate"].ToString());
                            DdlPatientIds.Items.Add(new System.Web.UI.WebControls.ListItem(row["Lname"].ToString() + ", " + row["Fname"].ToString() + ", " + dt.ToShortDateString(),row["PatientId"].ToString()));
                        }
                    }
                    DdlFormList.Items.Add("Name Printed in Consent Form");
                    DdlFormList.Items.Add("Blank Consent Form");
                    DdlFormList.Items.Add("Pre Printed Order Form");
                    DdlPatientIds.SelectedIndex = 0;
                    DdlFormList.SelectedIndex = 0;

                    Session["NewSession"] = true;
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
                if (!ChkBCOrR.Checked && !ChkCCLC.Checked && !ChkEC.Checked && !ChkSurgicalConcent.Checked)
                {
                    LblError.Text = "Please Select any one of the above Consent";
                    return;
                }

                //actual storage part starts here

                Session.Add("BloodConsentRefusal", ChkBCOrR.Checked);
                Session.Add("SurgicalConsent", ChkSurgicalConcent.Checked);
                Session.Add("EndoscopyConsent", ChkEC.Checked);
                Session.Add("CardiacCathLabConsent", ChkCCLC.Checked);

                if (ChkSurgicalConcent.Checked)
                {
                    Response.Redirect("/SurgicalConsent.aspx");
                    return;
                }
                if (ChkCCLC.Checked)
                {
                    Response.Redirect("/CardiacCathLabConsent.aspx");
                    return;
                }
                if (ChkEC.Checked)
                {
                    Response.Redirect("/EndoscopyConsent.aspx");
                    return;
                }
                if (ChkBCOrR.Checked)
                {
                    Response.Redirect("/BloodConsentOrRefusal.aspx");
                }
            }
            catch (Exception ex) { }
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
                //ChkSurgicalConcent.Checked = (DdlFormList.SelectedIndex > 0);
                if (DdlFormList.SelectedIndex == 0)
                    LblError.Text = "Please select form type.";
            }
            catch (Exception ex)
            {
            }
        }

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
    }
}