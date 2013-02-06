using System;

namespace WindowsCEConsentForms
{
    public partial class SessionVerifier : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["EmpID"] != null && !string.IsNullOrEmpty(Session["EmpID"].ToString()))
                Response.Write("True");
            else
                Response.Write("False");
            Response.End();
        }
    }
}