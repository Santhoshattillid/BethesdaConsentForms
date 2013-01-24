using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BethesdaConsentFormWCFSvc
{
    public class Treatment
    {
        public Treatment()
        {
            _doctorAndPrcedures = new List<DoctorAndProcedure>();
            _signatureses = new List<Signatures>();
            _trackingInformation = new TrackingInformation();
        }

        public string _patientId;

        public ConsentType _consentType;

        public string _procedures;
        public int _consentID;

        public bool _isPatientUnableSign;

        public bool _IsStatementOfConsentAccepted;
        public bool _IsAutologousUnits;
        public bool _IsDirectedUnits;

        public Physican _physican;

        public string _unableToSignReason;

        public TrackingInformation _trackingInformation;

        public string _translatedBy;

        public List<DoctorAndProcedure> _doctorAndPrcedures;

        public List<Signatures> _signatureses;

        public string _empID;
    }

    public class DoctorDetails
    {
        public string Fname;
        public string Lname;
        public int ID;
    }

    public class AssociatedDoctorDetails
    {
        public string Fname;
        public string Lname;
    }

    public class Physican
    {
        public bool Associated;
        public bool PrimaryDoctor;
        public int ConsentTypeID;
        public string FName;
        public string LName;
        public int PCID;
    }

    public class StatementOfConsent
    {
        public bool DirectedUnits;
        public bool AutologousUnits;
    }

    public class PatientDetail
    {
        public string name;
        public int age;
        public string gender;
        public string MRHash;
        public string AttnDr;
        public DateTime AdmDate;
        public string PrimaryDoctorId;
        public string AssociatedDoctorId;
        public DateTime DOB;
        public string ProcedureName;
        public string UnableToSignReason;
        public string Translatedby;
        public string PatientHash;
        public StatementOfConsent StatementOfConsent;
    }

    public class DoctorAndProcedure
    {
        public string _primaryDoctorId;
        public string _precedures; // this will stored procedures with # seperated
    }

    public class Signatures
    {
        public SignatureType _signatureType;
        public string _signatureContent;
        public string _name;
    }

    public class TrackingInformation
    {
        public string _device;
        public string _iP;
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
}