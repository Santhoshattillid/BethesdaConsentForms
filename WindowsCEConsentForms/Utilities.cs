using System.Data;
using WindowsCEConsentForms.ConsentFormsService;

namespace WindowsCEConsentForms
{
    public class Utilities
    {
        public static bool IsDevelopmentMode;

        public static string GetNextFormUrl(ConsentType consentType, System.Web.SessionState.HttpSessionState sessionState)
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

        public static void GeneratePdfAndUploadToSharePointSite(FormHandlerServiceClient formHandlerServiceClient, ConsentType consentType, string patientId)
        {
            formHandlerServiceClient.GenerateAndUploadPDFtoSharePoint("http://devsp1.atbapps.com:5555/" + consentType + @"/ConsentPrint.aspx?PatientId=" + patientId, patientId, consentType.ToString());
        }

        public static string GetAssociatedDoctors(string primaryPhysicianId)
        {
            string outPut = string.Empty;
            var formHandlerServiceClient = new FormHandlerServiceClient();
            var associatedDoctors = formHandlerServiceClient.GetAssociatedPhysiciansList(primaryPhysicianId);
            if (associatedDoctors != null)
            {
                foreach (DataRow row in associatedDoctors.Rows)
                {
                    if (!string.IsNullOrEmpty(outPut))
                        outPut += " , ";
                    outPut += row["Lname"].ToString().Trim() + " " + row["Fname"].ToString().Trim();
                }
            }
            return outPut;
        }

        public static string GetPrimaryDoctorName(string primaryPhysicianId)
        {
            var formHandlerServiceClient = new FormHandlerServiceClient();
            var primaryDoctor = formHandlerServiceClient.GetPrimaryDoctorDetail(primaryPhysicianId);
            return primaryDoctor.Lname + " " + primaryDoctor.Fname;
        }

        public static PatientDetail GetPatientName(string patientId, string consentType)
        {
            var formHandlerServiceClient = new FormHandlerServiceClient();
            return formHandlerServiceClient.GetPatientDetail(patientId, consentType);
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
    }

    public enum ConsentType
    {
        Surgical,
        Cardiovascular,
        OutsideOR,
        Endoscopy,
        BloodConsentOrRefusal,
        PlasmanApheresis,
        PICC,
        None
    }

    public enum SignatureType
    {
        DoctorSign1,
        DoctorSign2,
        DoctorSign3,
        DoctorSign4,
        DoctorSign5,
        DoctorSign6,
        DoctorSign7,
        PatientSign,
        PatientAuthorizeSign,
        WitnessSignature1,
        WitnessSignature2,
        PICCSignature
    }

    public enum StatementType
    {
        Accepted,
        Refused
    }
}