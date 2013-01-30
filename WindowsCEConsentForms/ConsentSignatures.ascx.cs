using System;
using System.Collections.Generic;
using System.Text;
using WindowsCEConsentForms.ConsentFormSvc;

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

        public List<Signatures> GetSignatures()
        {
            var outPut = new List<Signatures>();
            if (Request.Form[SignatureType.DoctorSign1.ToString()] != null)
            {
                var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.DoctorSign1.ToString()]);
                outPut.Add(new Signatures
                               {
                                   _name = string.Empty,
                                   _signatureContent = Encoding.ASCII.GetString(bytes),
                                   _signatureType = SignatureType.DoctorSign1
                               });
            }

            if (Request.Form[SignatureType.DoctorSign2.ToString()] != null)
            {
                var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.DoctorSign2.ToString()]);
                outPut.Add(new Signatures
                {
                    _name = string.Empty,
                    _signatureContent = Encoding.ASCII.GetString(bytes),
                    _signatureType = SignatureType.DoctorSign2
                });
            }

            if (Request.Form[SignatureType.DoctorSign3.ToString()] != null)
            {
                var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.DoctorSign3.ToString()]);
                outPut.Add(new Signatures
                {
                    _name = string.Empty,
                    _signatureContent = Encoding.ASCII.GetString(bytes),
                    _signatureType = SignatureType.DoctorSign3
                });
            }

            if (Request.Form[SignatureType.DoctorSign4.ToString()] != null)
            {
                var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.DoctorSign4.ToString()]);
                outPut.Add(new Signatures
                {
                    _name = string.Empty,
                    _signatureContent = Encoding.ASCII.GetString(bytes),
                    _signatureType = SignatureType.DoctorSign4
                });
            }

            if (Request.Form[SignatureType.DoctorSign5.ToString()] != null)
            {
                var bytes = Encoding.ASCII.GetBytes(Request.Form[SignatureType.DoctorSign5.ToString()]);
                outPut.Add(new Signatures
                {
                    _name = string.Empty,
                    _signatureContent = Encoding.ASCII.GetString(bytes),
                    _signatureType = SignatureType.DoctorSign5
                });
            }

            return outPut;
        }
    }
}