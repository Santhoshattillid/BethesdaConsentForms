using System;
using System.Collections.Generic;
using WindowsCEConsentForms.ConsentFormsService;

namespace WindowsCEConsentForms
{
    public partial class DoctorsAndProceduresPrint : System.Web.UI.UserControl
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
            var docAndProcPrints = new List<DocAndProcPrint>();
            if (!string.IsNullOrEmpty(patientId))
            {
                var formHandlerServiceClient = new FormHandlerServiceClient();
                string patientName = Utilities.GetPatientName(patientId, ConsentType.ToString()).name;
                foreach (var docandproc in formHandlerServiceClient.GetDoctorsDetails(patientId, ConsentType.ToString()))
                {
                    docAndProcPrints.Add(new DocAndProcPrint()
                                             {
                                                 Doctor = Utilities.GetPrimaryDoctorName(docandproc._primaryDoctorId) + " , " + Utilities.GetAssociatedDoctors(docandproc._primaryDoctorId),
                                                 PatientName = patientName,
                                                 Procedures = docandproc._precedures.Substring(0, docandproc._precedures.Length - 1).Replace("#", " , ")
                                             }
                        );
                }
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