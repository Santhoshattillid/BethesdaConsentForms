using System;
using System.Data;
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

                var formHandlerServiceClient = new ConsentFormSvcClient();
                var patientDetails = formHandlerServiceClient.GetPatientDetail(patientId, ConsentType.ToString());
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
                    if (patientDetails.StatementOfConsent != null)
                    {
                        IsStatementOfConsent = true;
                        ChkAutologousUnits.Checked = patientDetails.StatementOfConsent.AutologousUnits;
                        ChkDirectedUnits.Checked = patientDetails.StatementOfConsent.DirectedUnits;
                    }
                    else
                        IsStatementOfConsent = false;
                }
            }
        }
    }
}