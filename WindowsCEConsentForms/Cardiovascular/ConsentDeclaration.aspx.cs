using System;

namespace WindowsCEConsentForms.Cardiovascular
{
    public partial class ConsentDeclaration1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 7; i++)
                ViewState["Signature" + i] = string.Empty;
        }
    }
}