using System;

namespace WindowsCEConsentForms
{
    public partial class ConsentSignatures : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

        public void ResetSignatures()
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