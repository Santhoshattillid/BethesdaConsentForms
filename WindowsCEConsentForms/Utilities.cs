namespace WindowsCEConsentForms
{
    public class Utilities
    {
        public static bool IsDevelopmentMode = false;

        public static string GetNextFormUrl(ConsentType consentType, System.Web.SessionState.HttpSessionState sessionState)
        {
            if (consentType == ConsentType.Surgical)
            {
                if ((bool)sessionState["CardiacCathLabConsent"])
                    return "/CardiacCathLabConsent.aspx";
                if ((bool)sessionState["OutsideORConsent"])
                    return "/OutsideOR/Consent.aspx";
                if ((bool)sessionState["EndoscopyConsent"])
                    return "/EndoscopyConsent.aspx";
                if ((bool)sessionState["BloodConsentRefusal"])
                    return "/BloodConsentOrRefusal.aspx";
                if ((bool)sessionState["PICCConsent"])
                    return "/PICC/ConsentDeclaration.aspx"; //return "/PICC/Consent.aspx";
            }
            else if (consentType == ConsentType.CardiacCathLab)
            {
                if ((bool)sessionState["OutsideORConsent"])
                    return "/OutsideOR/Consent.aspx";
                if ((bool)sessionState["EndoscopyConsent"])
                    return "/EndoscopyConsent.aspx";
                if ((bool)sessionState["BloodConsentRefusal"])
                    return "/BloodConsentOrRefusal.aspx";
                if ((bool)sessionState["PICCConsent"])
                    return "/PICC/ConsentDeclaration.aspx"; //return "/PICC/Consent.aspx";
            }
            else if (consentType == ConsentType.OutsideOR)
            {
                if ((bool)sessionState["EndoscopyConsent"])
                    return "/EndoscopyConsent.aspx";
                if ((bool)sessionState["BloodConsentRefusal"])
                    return "/BloodConsentOrRefusal.aspx";
                if ((bool)sessionState["PICCConsent"])
                    return "/PICC/ConsentDeclaration.aspx"; //return "/PICC/Consent.aspx";
            }
            else if (consentType == ConsentType.Endoscopy)
            {
                if ((bool)sessionState["BloodConsentRefusal"])
                    return "/BloodConsentOrRefusal.aspx";
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
    }

    public enum ConsentType
    {
        Surgical,
        CardiacCathLab,
        OutsideOR,
        Endoscopy,
        BloodConsentOrRefusal,
        PlasmanApheresis,
        PICC
    }
}