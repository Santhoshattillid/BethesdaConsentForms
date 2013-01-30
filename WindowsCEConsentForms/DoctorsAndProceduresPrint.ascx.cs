using System;
using System.Collections.Generic;
using System.Linq;
using WindowsCEConsentForms.ConsentFormSvc;

namespace WindowsCEConsentForms
{
    public partial class DoctorsAndProceduresPrint : System.Web.UI.UserControl
    {
        public ConsentType consentType;

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
            var docAndProcPrints = new List<DocAndProcPrint>();
            if (!string.IsNullOrEmpty(patientId))
            {
                var formHandlerServiceClient = Utilities.GetConsentFormSvcClient();
                var treatment = formHandlerServiceClient.GetTreatment(patientId, consentType);
                string patientName = Utilities.GetPatientName(patientId, consentType.ToString()).name;
                docAndProcPrints.AddRange(treatment._doctorAndPrcedures.Select(docandproc => new DocAndProcPrint
                                       {
                                           Doctor = Utilities.GetPrimaryDoctorName(Convert.ToInt32(docandproc._primaryDoctorId)) + " , " + Utilities.GetAssociatedDoctors(Convert.ToInt32(docandproc._primaryDoctorId)),
                                           PatientName = patientName,
                                           Procedures = docandproc._precedures.Substring(0, docandproc._precedures.Length - 1).Replace("#", " , ")
                                       }));
                LblPatientName.Text = patientName;
            }
            ViewState["DocAndProcDetails"] = docAndProcPrints;
        }
    }

    [Serializable]
    public class DocAndProcPrint
    {
        public string Doctor;
        public string PatientName;
        public string Procedures;
    }
}