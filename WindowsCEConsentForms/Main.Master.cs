using System;

namespace WindowsCEConsentForms
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            Page.EnableViewState = true;
        }
    }
}