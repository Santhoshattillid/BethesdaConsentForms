using System;
using WindowsCEConsentForms.FormHandlerService;

namespace WindowsCEConsentForms
{
    public partial class PatientDetails : System.Web.UI.UserControl
    {
        public ConsentType ConsentType;

        protected void Page_Load(object sender, EventArgs e)
        {
            string patientId;
            try
            {
                patientId = Session["PatientID"].ToString();
            }
            catch (Exception)
            {
                try
                {
                    patientId = Request.QueryString["PatientId"];
                }
                catch (Exception)
                {
                    patientId = string.Empty;
                }
            }
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(patientId))
                {
                    var formHandlerServiceClient = Utilities.GetConsentFormSvcClient();
                    var patientDetail = formHandlerServiceClient.GetPatientDetail(patientId, ConsentType.ToString());
                    if (patientDetail != null)
                    {
                        LblPatientName.Text = patientDetail.name;
                        LblDate.Text = patientDetail.AdmDate.ToString("MMM dd yyyy");
                        LblPatientMRId.Text = patientDetail.MRHash;
                        LblTime.Text = DateTime.Now.ToShortTimeString();
                    }
                }
            }
        }
    }
}