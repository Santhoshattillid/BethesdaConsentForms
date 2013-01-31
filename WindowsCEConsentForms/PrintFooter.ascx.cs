using System;
using System.Globalization;
using System.Web.UI;
using WindowsCEConsentForms.ConsentFormSvc;

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
            string location;
            try
            {
                location = Request.QueryString["Location"];
            }
            catch (Exception)
            {
                location = string.Empty;
            }
            if (!string.IsNullOrEmpty(patientId) && !string.IsNullOrEmpty(location))
            {
                var formHandlerServiceClient = Utilities.GetConsentFormSvcClient();
                var patientDetails = formHandlerServiceClient.GetPatientDetail(patientId, ConsentType.ToString(), location);
                if (patientDetails != null)
                {
                    LblDOB.Text = DateTime.Now.ToString("MMM dd yyyy");
                    LblPatientAdminDate.Text = patientDetails.AdmDate.ToString("MMM dd yyyy");
                    LblPatientAdminTime.Text = patientDetails.AdmDate.ToLongTimeString();
                    LblPatientMrHash.Text = patientDetails.MRHash;
                    LblPatientName.Text = patientDetails.name;
                    LblAge.Text = patientDetails.age.ToString(CultureInfo.InvariantCulture);
                    LblGender.Text = patientDetails.gender;
                    LblAttendingPhysician.Text = patientDetails.AttnDr;
                    LblPatientId.Text = patientDetails.PatientHash;
                }
            }
        }
    }
}