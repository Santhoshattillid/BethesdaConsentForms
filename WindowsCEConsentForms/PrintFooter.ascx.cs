using System;
using System.Globalization;
using System.Web.UI;
using WindowsCEConsentForms.FormHandlerService;

namespace WindowsCEConsentForms
{
    public partial class PrintFooter : UserControl
    {
        public ConsentType ConsentType;

        protected void Page_Load(object sender, EventArgs e)
        {
            string patientId;
            try
            {
                patientId = Request.QueryString["PatientID"];
            }
            catch (Exception)
            {
                patientId = string.Empty;
            }
            if (!string.IsNullOrEmpty(patientId))
            {
                var formHandlerServiceClient = new FormHandlerServiceClient();
                var patientDetails = formHandlerServiceClient.GetPatientDetail(patientId, ConsentType.ToString());
                if (patientDetails != null)
                {
                    LblDOB.Text = DateTime.Now.ToString("MMM dd yyyy");
                    LblPatientAdminDate.Text = patientDetails.AdmDate.ToString("MMM dd yyyy");
                    LblPatientAdminTime.Text = patientDetails.AdmDate.ToLongTimeString();
                    LblPatientId.Text = patientDetails.MRHash;
                    LblPatientMrHash.Text = patientDetails.MRHash;
                    LblPatientName.Text = patientDetails.name;

                    //LblDate.Text = DateTime.Now.ToString("MMM dd yyyy");
                    LblAge.Text = patientDetails.age.ToString(CultureInfo.InvariantCulture);
                    LblGender.Text = patientDetails.gender;
                    LblAttendingPhysician.Text = patientDetails.AttnDr;
                }
            }
        }
    }
}