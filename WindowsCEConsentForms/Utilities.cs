using System;
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