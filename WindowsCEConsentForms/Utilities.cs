using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.ServiceModel;
using System.Web;
using System.Web.Configuration;
using System.Web.SessionState;
using WindowsCEConsentForms.ConsentFormSvc;

namespace WindowsCEConsentForms
{
    public class Utilities
    {
        public static bool IsDevelopmentMode = false;

        public static string GetNextFormUrl(ConsentType consentType, HttpSessionState sessionState)
        {
            if (consentType == ConsentType.Surgical)
            {
                if ((bool)sessionState["Cardiovascular"])
                    return "/Cardiovascular/ConsentDeclaration.aspx";
                if ((bool)sessionState["OutsideORConsent"])
                    return "/OutsideOR/ConsentDeclaration.aspx";
                if ((bool)sessionState["EndoscopyConsent"])
                    return "/Endoscopy/ConsentDeclaration.aspx";
                if ((bool)sessionState["BloodConsentRefusal"])
                    return "/BloodConsentOrRefusal/ConsentDeclaration.aspx";
                if ((bool)sessionState["PICCConsent"])
                    return "/PICC/ConsentDeclaration.aspx"; //return "/PICC/Consent.aspx";
            }
            else if (consentType == ConsentType.Cardiovascular)
            {
                if ((bool)sessionState["OutsideORConsent"])
                    return "/OutsideOR/ConsentDeclaration.aspx";
                if ((bool)sessionState["EndoscopyConsent"])
                    return "/Endoscopy/ConsentDeclaration.aspx";
                if ((bool)sessionState["BloodConsentRefusal"])
                    return "/BloodConsentOrRefusal/ConsentDeclaration.aspx";
                if ((bool)sessionState["PICCConsent"])
                    return "/PICC/ConsentDeclaration.aspx"; //return "/PICC/Consent.aspx";
            }
            else if (consentType == ConsentType.OutsideOR)
            {
                if ((bool)sessionState["EndoscopyConsent"])
                    return "/Endoscopy/ConsentDeclaration.aspx";
                if ((bool)sessionState["BloodConsentRefusal"])
                    return "/BloodConsentOrRefusal/ConsentDeclaration.aspx";
                if ((bool)sessionState["PICCConsent"])
                    return "/PICC/ConsentDeclaration.aspx"; //return "/PICC/Consent.aspx";
            }
            else if (consentType == ConsentType.Endoscopy)
            {
                if ((bool)sessionState["BloodConsentRefusal"])
                    return "/BloodConsentOrRefusal/ConsentDeclaration.aspx";
                if ((bool)sessionState["PICCConsent"])
                    return "/PICC/ConsentDeclaration.aspx"; //return "/PICC/Consent.aspx";
            }
            else if (consentType == ConsentType.BloodConsentOrRefusal)
            {
                if ((bool)sessionState["PICCConsent"])
                    return "/PICC/ConsentDeclaration.aspx"; //return "/PICC/Consent.aspx";
            }
            return "/PatientConsent.aspx";
        }

        public static void GeneratePdfAndUploadToSharePointSite(ConsentFormSvcClient formHandlerServiceClient, ConsentType consentType, string patientId, HttpRequest request, string location)
        {
            if (!IsDevelopmentMode)

                //formHandlerServiceClient.GenerateAndUploadPdFtoSharePoint("http://" + request.Url.Host + ":" + request.Url.Port + "/" + consentType + @"/ConsentPrint.aspx?PatientId=" + patientId + "&Location=" + location, patientId, consentType, location);
                formHandlerServiceClient.GenerateAndUploadPdFtoSharePoint("http://localhost" + request.Url.Port + @"/" + consentType + @"/ConsentPrint.aspx?PatientId=" + patientId + "&Location=" + location, patientId, consentType, location);
        }

        public static string GetAssociatedDoctors(int primaryPhysicianId)
        {
            string outPut = string.Empty;
            try
            {
                if (primaryPhysicianId != 0)
                {
                    var formHandlerServiceClient = Utilities.GetConsentFormSvcClient();
                    var associatedDoctors = formHandlerServiceClient.GetAssociatedDoctors(primaryPhysicianId);
                    if (associatedDoctors != null)
                    {
                        foreach (AssociatedDoctorDetails associatedDoctor in associatedDoctors)
                        {
                            if (!string.IsNullOrEmpty(outPut))
                                outPut += " , ";
                            outPut += associatedDoctor.Lname + " " + associatedDoctor.Fname;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var client = GetConsentFormSvcClient();
                client.CreateLog(string.Empty, LogType.E, "GetAssociatedDoctors" + "-" + new StackTrace().GetFrame(0).GetMethod(),
                                 ex.Message + Environment.NewLine + ex.StackTrace);
            } return outPut;
        }

        public static string GetPrimaryDoctorName(int primaryPhysicianId)
        {
            var formHandlerServiceClient = Utilities.GetConsentFormSvcClient();
            var primaryDoctor = formHandlerServiceClient.GetDoctorDetail(primaryPhysicianId);
            return primaryDoctor.Lname + " " + primaryDoctor.Fname;
        }

        public static PatientDetail GetPatientName(string patientId, string consentType, string location)
        {
            var formHandlerServiceClient = Utilities.GetConsentFormSvcClient();
            return formHandlerServiceClient.GetPatientDetail(patientId, consentType, location);
        }

        public static string GetConsentHeader(ConsentType consentType)
        {
            switch (consentType)
            {
                case ConsentType.Surgical:
                    return "CONSENT TO DIAGNOSTIC PROCEDURE OR OPERATION";
                case ConsentType.Cardiovascular:
                    return "CARDIOVASCULAR LABORATORY CONSENT";
                case ConsentType.OutsideOR:
                    return "CONSENT FOR PROCEDURES OUTSIDE OF THE OPERATING ROOM";
                case ConsentType.Endoscopy:
                    return "CONSENT FOR ENDOSCOPY";
                case ConsentType.BloodConsentOrRefusal:
                    return "CONSENT FOR TRANSFUSION OF BLOOD OR BLOOD PRODUCTS";
                case ConsentType.PlasmanApheresis:
                    return "CONSENT FOR THERAPEUTIC APHERESIS";
                case ConsentType.PICC:
                    return "AUTHORIZATION FOR PERIPHERALLY INSERTED CENTRAL CATHETER (PICC)";
                default:
                    return string.Empty;
            }
        }

        public static ConsentFormSvcClient GetConsentFormSvcClient()
        {
            Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            var endpoint = new EndpointAddress(new Uri(config.AppSettings.Settings["ServiceURL"].Value));
            var basicHttpBinding = new BasicHttpBinding { MaxReceivedMessageSize = 2147483647, MaxBufferSize = 2147483647 };
            return new ConsentFormSvcClient(basicHttpBinding, endpoint);
        }

        public static string GetUsername(HttpSessionState session)
        {
            if (session["EmpID"] != null)
                return session["EmpID"].ToString();
            return string.Empty;
        }
    }

    public enum StatementType
    {
        Accepted,
        Refused
    }
}