using System;
using System.Configuration;
using System.Data;
using System.ServiceModel;
using System.Web;
using System.Web.Configuration;
using WindowsCEConsentForms.FormHandlerService;

namespace WindowsCEConsentForms.BloodConsentOrRefusal
{
    public partial class PICCConsentPrint : System.Web.UI.Page
    {
        public bool IsStatementOfConsent;
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
                ConsentType = ConsentType.BloodConsentOrRefusal;

                var formHandlerServiceClient = Utilities.GetConsentFormSvcClient();

                var patientDetails = formHandlerServiceClient.GetPatientDetail(patientId, ConsentType.ToString());
                var treatment = formHandlerServiceClient.GetTreatment(patientId, ConsentType);
                if (patientDetails != null)
                {
                    var primaryDoctor = formHandlerServiceClient.GetDoctorDetail(Convert.ToInt32(patientDetails.PrimaryDoctorId));
                    if (primaryDoctor != null)
                    {
                        LblAuthoriseDoctors.Text = primaryDoctor.Fname + " " + primaryDoctor.Lname;
                    }
                    foreach (AssociatedDoctorDetails associatedDoctor in formHandlerServiceClient.GetAssociatedDoctors(Convert.ToInt32(patientDetails.PrimaryDoctorId)))
                    {
                        LblAuthoriseDoctors.Text += " , " + associatedDoctor.Lname + " " + associatedDoctor.Fname;
                    }

                    LblPatientName2.Text = patientDetails.name;
                    LblPatientName3.Text = patientDetails.name;
                    LblProcedureName.Text = patientDetails.ProcedureName;
                    if (treatment._IsStatementOfConsentAccepted)
                    {
                        IsStatementOfConsent = true;
                        ChkAutologousUnits.Checked = treatment._IsAutologousUnits;
                        ChkDirectedUnits.Checked = treatment._IsDirectedUnits;
                    }
                    else
                        IsStatementOfConsent = false;
                }
            }
        }
    }
}