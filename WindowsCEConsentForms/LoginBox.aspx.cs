using System;
using System.Diagnostics;
using WindowsCEConsentForms.ConsentFormSvc;

namespace WindowsCEConsentForms
{
    public partial class LoginBox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TxtEmployeeID.Text.Trim()))
                {
                    LblError.Text = "Employee ID field should not be empty.";
                }
                else
                {
                    var formHanlderServiceClient = Utilities.GetConsentFormSvcClient();
                    if (formHanlderServiceClient.IsValidEmployee(TxtEmployeeID.Text.Trim()))
                    {
                        Session.Add("EmpID", TxtEmployeeID.Text);
                        HdnField.Value = "True";
                    }
                    else
                    {
                        LblError.Text = "Please input valid employee ID.";
                    }
                }
            }

            catch (Exception ex)
            {
                var client = Utilities.GetConsentFormSvcClient();
                client.CreateLog(Utilities.GetUsername(Session), LogType.E, GetType().Name + "-" + new StackTrace().GetFrame(0).GetMethod().ToString(),
                                 ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }
    }
}