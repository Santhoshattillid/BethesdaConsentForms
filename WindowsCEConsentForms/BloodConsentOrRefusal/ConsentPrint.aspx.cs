using System;
using System.Diagnostics;
using WindowsCEConsentForms.ConsentFormSvc;

namespace WindowsCEConsentForms.BloodConsentOrRefusal
{
    public partial class PICCConsentPrint : System.Web.UI.Page
    {
        public bool IsStatementOfConsent;
        public ConsentType consentType;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
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
                if (!string.IsNullOrEmpty(patientId))
                {
                    consentType = ConsentType.BloodConsentOrRefusal;

                    var formHandlerServiceClient = Utilities.GetConsentFormSvcClient();

                    var patientDetails = formHandlerServiceClient.GetPatientDetail(patientId, consentType.ToString(), location);
                    var treatment = formHandlerServiceClient.GetTreatment(patientId, consentType);
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
            catch (Exception ex)
            {
                var client = Utilities.GetConsentFormSvcClient();
                client.CreateLog(Utilities.GetUsername(Session), LogType.E, GetType().Name + "-" + new StackTrace().GetFrame(0).GetMethod().ToString(),
                                 ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }
    }
}