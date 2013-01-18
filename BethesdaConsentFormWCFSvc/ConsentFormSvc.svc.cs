using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Configuration;
using BethesdaConsentFormWCFSvc.DocumentConverterService;

namespace BethesdaConsentFormWCFSvc
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceContract] //This Attribute used to define the interface
    public class ConsentFormSvc
    {
        [OperationContract]
        public void SetDbConnection(string connectionString)
        {
            System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            config.AppSettings.Settings.Remove("DBConnection");
            config.AppSettings.Settings.Add("DBConnection", connectionString);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        [OperationContract]
        public void SetBethesdaDbConnection(string connectionString)
        {
            System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            config.AppSettings.Settings.Remove("BethesdaDBConnection");
            config.AppSettings.Settings.Add("BethesdaDBConnection", connectionString);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
        }

        [OperationContract] //This Attribute used to define the method inside of interface
        public void AddTreatment(Treatment treatment)
        {
            try
            {
                System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
                var conStr = config.AppSettings.Settings["DBConnection"].Value;
                using (var sqlConnection = new SqlConnection(conStr))
                {
                    sqlConnection.Open();
                    SqlTransaction transaction = sqlConnection.BeginTransaction();
                    try
                    {
                        if (treatment._doctorAndPrcedures == null)
                            treatment._doctorAndPrcedures = new List<DoctorAndProcedure>();

                        if (treatment._signatureses == null)
                            treatment._signatureses = new List<Signatures>();

                        int consentType = GetConsentTypeId(sqlConnection, transaction, treatment._consentType.ToString());
                        int trackingID = GetTrackingId(sqlConnection, transaction, treatment._trackingInformation._device, treatment._trackingInformation._iP);
                        int doctorsAndProceduresID = GetDoctorsAndProcedures(sqlConnection, transaction, consentType, treatment._doctorAndPrcedures);
                        int signaturesID = GetSignatures(sqlConnection, transaction, treatment._signatureses);

                        var addTreatmentCommand = new SqlCommand("AddTreatment", sqlConnection, transaction) { CommandType = CommandType.StoredProcedure };
                        addTreatmentCommand.Parameters.Add(new SqlParameter("@PatientID", SqlDbType.Int)).Value = treatment._patientId;
                        addTreatmentCommand.Parameters.Add(new SqlParameter("@ConsentTypeID", SqlDbType.Int)).Value = consentType;
                        addTreatmentCommand.Parameters.Add(new SqlParameter("@isPatientUnableSign", SqlDbType.Int)).Value = (treatment._isPatientUnableSign ? 1 : 0);
                        addTreatmentCommand.Parameters.Add(new SqlParameter("@isStatementOfConsentAccepted", SqlDbType.Int)).Value = (treatment._IsStatementOfConsentAccepted ? 1 : 0);
                        addTreatmentCommand.Parameters.Add(new SqlParameter("@isAutologousUnits", SqlDbType.Int)).Value = (treatment._IsAutologousUnits ? 1 : 0);
                        addTreatmentCommand.Parameters.Add(new SqlParameter("@isDirectedUnits", SqlDbType.Int)).Value = (treatment._IsDirectedUnits ? 1 : 0);
                        addTreatmentCommand.Parameters.Add(new SqlParameter("@unableToSignReason", SqlDbType.VarChar)).Value = (string.IsNullOrEmpty(treatment._unableToSignReason) ? string.Empty : treatment._unableToSignReason);
                        addTreatmentCommand.Parameters.Add(new SqlParameter("@trackingID", SqlDbType.Int)).Value = trackingID;
                        addTreatmentCommand.Parameters.Add(new SqlParameter("@signaturesID", SqlDbType.Int)).Value = signaturesID;
                        addTreatmentCommand.Parameters.Add(new SqlParameter("@doctorsAndProceduresID", SqlDbType.Int)).Value = doctorsAndProceduresID;
                        addTreatmentCommand.Parameters.Add(new SqlParameter("@translatedBy", SqlDbType.VarChar)).Value = (string.IsNullOrEmpty(treatment._translatedBy) ? string.Empty : treatment._translatedBy);
                        addTreatmentCommand.ExecuteNonQuery();
                        /*
                        string query = @"insert into Treatment(PatentId,ConsentType,IsPatientunabletosign,IsStatementOfConsentAccepted,
                                                                IsAutologousUnits,IsDirectedUnits,Unabletosignreason,TrackingID,
                                                                Signatures,DoctorandProcedure,TransaltedBy,Date)
                                            values(" + treatment._patientId + "," + consentType + "," + (treatment._isPatientUnableSign == true ? 1 : 0) + ",'"
                                                     + (treatment._IsStatementOfConsentAccepted == true ? 1 : 0) + "','" + (treatment._IsAutologousUnits == true ? 1 : 0) + "','"
                                                     + (treatment._IsDirectedUnits == true ? 1 : 0) + "','"
                                                     + (string.IsNullOrEmpty(treatment._unableToSignReason) ? string.Empty : treatment._unableToSignReason) + "',"
                                                     + trackingID + "," + signaturesID + "," + doctorsAndProceduresID + ",'"
                                                     + (string.IsNullOrEmpty(treatment._translatedBy) ? string.Empty : treatment._translatedBy) + "','" + DateTime.Now + "')";

                        SqlCommand cmdTreatment = new SqlCommand(query, sqlConnection, transaction);
                        cmdTreatment.ExecuteNonQuery(); */
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [OperationContract]
        public Treatment GetTreatment(string patientId, ConsentType consentType)
        {
            // open connection to sql server
            var treatment = new Treatment();
            try
            {
                System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
                var conStr = config.AppSettings.Settings["DBConnection"].Value;
                using (var sqlConnection = new SqlConnection(conStr))
                {
                    sqlConnection.Open();
                    var daTreatment = new SqlDataAdapter(@"GetTreatment", sqlConnection) { SelectCommand = { CommandType = CommandType.StoredProcedure } };
                    daTreatment.SelectCommand.Parameters.Add("@consentType", SqlDbType.VarChar).Value = consentType.ToString();
                    var dsTreatment = new DataSet();
                    daTreatment.Fill(dsTreatment);
                    if (dsTreatment.Tables[0].Rows.Count > 0)
                    {
                        treatment._patientId = patientId;
                        treatment._consentType = consentType;
                        treatment._isPatientUnableSign = (dsTreatment.Tables[0].Rows[0]["IsPatientunabletosign"].ToString() == "1");
                        treatment._unableToSignReason = dsTreatment.Tables[0].Rows[0]["Unabletosignreason"].ToString();
                        treatment._translatedBy = dsTreatment.Tables[0].Rows[0]["TransaltedBy"].ToString();
                        treatment._trackingInformation = GetTrackingInformation(sqlConnection, dsTreatment.Tables[0].Rows[0]["TrackingID"].ToString());
                        treatment._doctorAndPrcedures = GetDoctorsProceduresInformation(sqlConnection, dsTreatment.Tables[0].Rows[0]["DoctorandProcedure"].ToString());
                        treatment._signatureses = GetSignaturesInformation(sqlConnection, dsTreatment.Tables[0].Rows[0]["Signatures"].ToString());
                    }
                }
                return treatment;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [OperationContract]
        public string GetPatientSignature(string patientId, ConsentType consentType, SignatureType signatureType)
        {
            System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            var conStr = config.AppSettings.Settings["DBConnection"].Value;
            using (var sqlConnection = new SqlConnection(conStr))
            {
                sqlConnection.Open();
                var cmdSignature = new SqlCommand(@"GetPatientSignature", sqlConnection) { CommandType = CommandType.StoredProcedure };
                cmdSignature.Parameters.Add("@patientID", SqlDbType.Int).Value = patientId;
                cmdSignature.Parameters.Add("@signatureType", SqlDbType.VarChar).Value = signatureType.ToString();
                cmdSignature.Parameters.Add("@consentType", SqlDbType.VarChar).Value = consentType.ToString();
                using (var sqlDataAdapter = new SqlDataAdapter(cmdSignature))
                {
                    var sig = new DataSet();
                    sqlDataAdapter.Fill(sig);
                    if (sig.Tables.Count > 0 && sig.Tables[0].Rows.Count > 0 && sig.Tables[0].Rows[0][0] != null)
                        return sig.Tables[0].Rows[0][0].ToString();
                }
            }
            return string.Empty;
        }

        [OperationContract]
        public void DeleteTables()
        {
            try
            {
                System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
                var conStr = config.AppSettings.Settings["DBConnection"].Value;
                using (var sqlConnection = new SqlConnection(conStr))
                {
                    sqlConnection.Open();
                    var daTreatment = new SqlCommand("TRUNCATE TABLE Treatment", sqlConnection);
                    daTreatment.ExecuteNonQuery();
                    var treatmentsignature = new SqlCommand("TRUNCATE TABLE Treatment_Signature", sqlConnection);
                    treatmentsignature.ExecuteNonQuery();
                    var trackinginfo = new SqlCommand("TRUNCATE TABLE TrackingInformation", sqlConnection);
                    trackinginfo.ExecuteNonQuery();
                    var cfprocedures = new SqlCommand("TRUNCATE TABLE CFProcedures", sqlConnection);
                    cfprocedures.ExecuteNonQuery();
                    var doctorsProcedures = new SqlCommand("TRUNCATE TABLE Doctor_Procedures", sqlConnection);
                    doctorsProcedures.ExecuteNonQuery();
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [OperationContract]
        public PatientDetail GetPatientDetail(string patientNumber, string consentFormType)
        {
            PatientDetail patientDetail = null;
            System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            var conStr = config.AppSettings.Settings["DBConnection"].Value;
            using (var sqlConnection = new SqlConnection(conStr))
            {
                using (var sqlDataAdapter = new SqlDataAdapter("select * from Patient where PatientId=" + patientNumber, sqlConnection))
                {
                    var dataset = new DataSet();
                    sqlDataAdapter.Fill(dataset);
                    if (dataset.Tables.Count > 0)
                    {
                        if (dataset.Tables[0].Rows.Count > 0)
                        {
                            DataRow record = dataset.Tables[0].Rows[0];
                            patientDetail = new PatientDetail
                                                {
                                                    name = record["FullName"].ToString(),
                                                    age = Convert.ToInt16(record["Age"]),
                                                    gender = record["Gender"].ToString(),
                                                    MRHash = record["MR#"].ToString(),
                                                    AttnDr = "Mr. Mathew Thomas",
                                                    AdmDate = DateTime.Now.AddDays(-2),
                                                    DOB = Convert.ToDateTime(record["BirthDate"]),
                                                    PatientHash = record["Patient#"].ToString()
                                                };
                            try
                            {
                                patientDetail.PrimaryDoctorId = record["PrimaryDoctor"].ToString();
                            }
                            catch (Exception)
                            {
                                patientDetail.PrimaryDoctorId = string.Empty;
                            }
                            try
                            {
                                patientDetail.AssociatedDoctorId = record["AssociatedDoctor"].ToString();
                            }
                            catch (Exception)
                            {
                                patientDetail.AssociatedDoctorId = string.Empty;
                            }
                        }
                    }
                }
            }
            return patientDetail;
        }

        [OperationContract]
        public DataTable GetPatientfromLocation(string location)
        {
            System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            var conStr = config.AppSettings.Settings["DBConnection"].Value;
            using (var sqlConnection = new SqlConnection(conStr))
            {
                using (var sqlDataAdapter = new SqlDataAdapter("GetPatientfromLocation", sqlConnection))
                {
                    sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@LOCATION", SqlDbType.NVarChar)).Value = location;
                    var dataset = new DataSet();
                    sqlDataAdapter.Fill(dataset);
                    if (dataset.Tables.Count > 0)
                        return dataset.Tables[0];
                }
            }
            return null;
        }

        //private const string SiteUrl = "http://devsp1:20399";
        //private const string DocumentLibary = "PatientConsentForms";

        [OperationContract]
        public void GenerateAndUploadPdFtoSharePoint(string relativeUrl, string patientId, ConsentType consentFormType)
        {
            DocumentConverterServiceClient client = null;
            try
            {
                string sourceFileName = null;
                byte[] sourceFile = null;
                client = OpenService("http://localhost:41734/Muhimbi.DocumentConverter.WebService/");
                var openOptions = new OpenOptions
                                      {
                                          UserName = "",
                                          Password = "",
                                          OriginalFileName = relativeUrl,
                                          FileExtension = "html"
                                      };

                //** Specify optional authentication settings for the web page

                // ** Specify the URL to convert

                //** Generate a temp file name that is later used to write the PDF to
                sourceFileName = Path.GetTempFileName();
                File.Delete(sourceFileName);

                // ** Enable JavaScript on the page to convert.
                openOptions.AllowMacros = MacroSecurityOption.All;

                // ** Set the various conversion settings
                var conversionSettings = new ConversionSettings
                                             {
                                                 Fidelity = ConversionFidelities.Full,
                                                 PDFProfile = PDFProfile.PDF_1_5,
                                                 Quality = ConversionQuality.OptimizeForOnScreen
                                             };

                // ** Carry out the actual conversion
                byte[] convertedFile = client.Convert(sourceFile, openOptions, conversionSettings);

                var patientDetails = GetPatientDetail(patientId, consentFormType.ToString());

                string fileName = consentFormType + patientDetails.MRHash + patientDetails.name + DateTime.Now.ToString("MMddyyyyHHmmss") + ".pdf";

                switch (consentFormType)
                {
                    case ConsentType.Surgical:
                        {
                            fileName = "SUR_CONSENT_" + patientDetails.MRHash + DateTime.Now.ToString("MMddyyyyHHmmss") + ".pdf";
                            break;
                        }
                    case ConsentType.BloodConsentOrRefusal:
                        {
                            fileName = "BLOOD_FEFUSAL_CONSENT_" + patientDetails.MRHash + DateTime.Now.ToString("MMddyyyyHHmmss") + ".pdf";
                            break;
                        }
                    case ConsentType.Cardiovascular:
                        {
                            fileName = "CARDIAC_CATH_CONSENT_" + patientDetails.MRHash + DateTime.Now.ToString("MMddyyyyHHmmss") + ".pdf";
                            break;
                        }
                    case ConsentType.Endoscopy:
                        {
                            fileName = "ENDO_CONSENT_" + patientDetails.MRHash + DateTime.Now.ToString("MMddyyyyHHmmss") + ".pdf";
                            break;
                        }
                    case ConsentType.OutsideOR:
                        {
                            fileName = "OUTSDE_OR_" + patientDetails.MRHash + DateTime.Now.ToString("MMddyyyyHHmmss") + ".pdf";
                            break;
                        }
                    case ConsentType.PICC:
                        {
                            fileName = "PICC_CONSENT_" + patientDetails.MRHash + DateTime.Now.ToString("MMddyyyyHHmmss") + ".pdf";
                            break;
                        }
                    case ConsentType.PlasmanApheresis:
                        {
                            fileName = "PLASMA_APHERESIS_CONSENT_" + patientDetails.MRHash + DateTime.Now.ToString("MMddyyyyHHmmss") + ".pdf";
                            break;
                        }
                }

                fileName = Path.Combine(GetPdFFolderPath(consentFormType), fileName);

                File.WriteAllBytes(fileName, convertedFile);

                /*

                //try
                //{
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (var site = new SPSite(SiteUrl))
                    {
                        using (var web = site.OpenWeb())
                        {
                            web.AllowUnsafeUpdates = true;

                            var list = web.Lists.TryGetList(DocumentLibary);
                            if (list != null)
                            {
                                var libFolder = list.RootFolder;

                                var patientDetails = GetPatientDetail(PatientId, ConsentFormType.ToString());

                                if (patientDetails != null)
                                {
                                    string fileName = ConsentFormType + patientDetails.MRHash + patientDetails.name + DateTime.Now.ToString("MMddyyyyHHmmss") + ".pdf";
                                    switch (ConsentFormType)
                                    {
                                        case ConsentType.Surgical:
                                            {
                                                fileName = "SUR_CONSENT_" + patientDetails.MRHash + DateTime.Now.ToString("MMddyyyyHHmmss") + ".pdf";
                                                break;
                                            }
                                        case ConsentType.BloodConsentOrRefusal:
                                            {
                                                fileName = "BLOOD_FEFUSAL_CONSENT_" + patientDetails.MRHash + DateTime.Now.ToString("MMddyyyyHHmmss") + ".pdf";
                                                break;
                                            }
                                        case ConsentType.Cardiovascular:
                                            {
                                                fileName = "CARDIAC_CATH_CONSENT_" + patientDetails.MRHash + DateTime.Now.ToString("MMddyyyyHHmmss") + ".pdf";
                                                break;
                                            }
                                        case ConsentType.Endoscopy:
                                            {
                                                fileName = "ENDO_CONSENT_" + patientDetails.MRHash + DateTime.Now.ToString("MMddyyyyHHmmss") + ".pdf";
                                                break;
                                            }
                                        case ConsentType.OutsideOR:
                                            {
                                                fileName = "OUTSDE_OR_" + patientDetails.MRHash + DateTime.Now.ToString("MMddyyyyHHmmss") + ".pdf";
                                                break;
                                            }
                                        case ConsentType.PICC:
                                            {
                                                fileName = "PICC_CONSENT_" + patientDetails.MRHash + DateTime.Now.ToString("MMddyyyyHHmmss") + ".pdf";
                                                break;
                                            }
                                        case ConsentType.PlasmanApheresis:
                                            {
                                                fileName = "PLASMA_APHERESIS_CONSENT_" + patientDetails.MRHash + DateTime.Now.ToString("MMddyyyyHHmmss") + ".pdf";
                                                break;
                                            }
                                    }

                                    if (libFolder.RequiresCheckout) { try { SPFile fileOld = libFolder.Files[fileName]; fileOld.CheckOut(); } catch { } }
                                    var spFileProperty = new Hashtable();
                                    spFileProperty.Add("MR#", patientDetails.MRHash);
                                    spFileProperty.Add("Patient#", PatientId);
                                    spFileProperty.Add("Patient Name", patientDetails.name);
                                    spFileProperty.Add("DOB#", Microsoft.SharePoint.Utilities.SPUtility.CreateISO8601DateTimeFromSystemDateTime(patientDetails.DOB));
                                    spFileProperty.Add("Procedure Type", patientDetails.ProcedureName);
                                    spFileProperty.Add("Patient Information", patientDetails.name + " " + DateTime.Now.ToShortDateString());

                                    SPFile spfile = libFolder.Files.Add(fileName, convertedFile, spFileProperty, true);

                                    list.Update();

                                    if (libFolder.RequiresCheckout)
                                    {
                                        spfile.CheckIn("Upload Comment", SPCheckinType.MajorCheckIn);
                                        spfile.Publish("Publish Comment");
                                    }
                                }
                            }

                            web.AllowUnsafeUpdates = false;
                        }
                    }
                });
                 */
            }
            finally
            {
                CloseService(client);
            }
        }

        [OperationContract]
        public DataTable GetProcedures(ConsentType consentType)
        {
            System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            var conStr = config.AppSettings.Settings["DBConnection"].Value;
            using (var sqlConnection = new SqlConnection(conStr))
            {
                sqlConnection.Open();
                using (var sqlDataAdapter = new SqlDataAdapter("GetProcedures", sqlConnection))
                {
                    sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sqlDataAdapter.SelectCommand.Parameters.Add("@consentType", SqlDbType.VarChar).Value = consentType.ToString();
                    var dataset = new DataSet();
                    sqlDataAdapter.Fill(dataset);
                    return dataset.Tables[0];
                }
            }
        }

        [OperationContract]
        public DataTable GetConsentTypes()
        {
            System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            var conStr = config.AppSettings.Settings["DBConnection"].Value;
            using (var sqlConnection = new SqlConnection(conStr))
            {
                sqlConnection.Open();
                using (var sqlDataAdapter = new SqlDataAdapter("GetConsentTypes", sqlConnection))
                {
                    sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    var dataset = new DataSet();
                    sqlDataAdapter.Fill(dataset);
                    return dataset.Tables[0];
                }
            }
        }

        [OperationContract]
        public void AddProcedures(string procedureName, int consentTypeID)
        {
            System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            var conStr = config.AppSettings.Settings["DBConnection"].Value;
            using (var sqlConnection = new SqlConnection(conStr))
            {
                sqlConnection.Open();
                SqlTransaction transaction = sqlConnection.BeginTransaction();
                try
                {
                    var cmdTreatment = new SqlCommand("AddProcedures", sqlConnection, transaction) { CommandType = CommandType.StoredProcedure };
                    cmdTreatment.Parameters.Add("@consentTypeID", SqlDbType.Int).Value = consentTypeID;
                    cmdTreatment.Parameters.Add("@procedureName", SqlDbType.VarChar).Value = procedureName;
                    cmdTreatment.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        [OperationContract]
        public void UpdateProcedureName(string procedureName, int procedureID)
        {
            System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            var conStr = config.AppSettings.Settings["DBConnection"].Value;
            using (var sqlConnection = new SqlConnection(conStr))
            {
                sqlConnection.Open();
                var command = new SqlCommand("UpdateProcedureName", sqlConnection) { CommandType = CommandType.StoredProcedure };
                command.Parameters.Add("@procedureID", SqlDbType.Int).Value = procedureID;
                command.Parameters.Add("@procedureName", SqlDbType.VarChar).Value = procedureName;
                command.ExecuteNonQuery();
            }
        }

        [OperationContract]
        public void DeleteProcedure(int id)
        {
            System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            var conStr = config.AppSettings.Settings["DBConnection"].Value;
            using (var sqlConnection = new SqlConnection(conStr))
            {
                sqlConnection.Open();
                var command = new SqlCommand("DeleteProcedure", sqlConnection) { CommandType = CommandType.StoredProcedure };
                command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = id;
                command.ExecuteNonQuery();
            }
        }

        [OperationContract]
        public List<string> ListProcedures(string name)
        {
            var outPut = new List<string>();
            System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            var conStr = config.AppSettings.Settings["DBConnection"].Value;
            using (var sqlConnection = new SqlConnection(conStr))
            {
                sqlConnection.Open();
                using (var sqlDataAdapter = new SqlDataAdapter("ListProcedures", sqlConnection))
                {
                    sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar)).Value = name;
                    var dataset = new DataSet();
                    sqlDataAdapter.Fill(dataset);
                    if (dataset.Tables.Count > 0)
                    {
                        outPut.AddRange(from DataRow row in dataset.Tables[0].Rows select row[0].ToString());
                    }
                }
            }
            return outPut;
        }

        [OperationContract]
        public List<DoctorDetails> GetDoctorDetails(ConsentType consentType)
        {
            var output = new List<DoctorDetails>();
            System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            var conStr = config.AppSettings.Settings["DBConnection"].Value;
            using (var sqlConnection = new SqlConnection(conStr))
            {
                using (var sqlDataAdapter = new SqlDataAdapter("GetDoctorDetails", sqlConnection))
                {
                    sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar)).Value = consentType;
                    var dataset = new DataSet();
                    sqlDataAdapter.Fill(dataset);
                    if (dataset.Tables.Count > 0)
                    {
                        output.AddRange(from DataRow row in dataset.Tables[0].Rows
                                        select new DoctorDetails
                                                   {
                                                       ID = Convert.ToInt32(row["ID"].ToString()),
                                                       Fname = row["FName"].ToString(),
                                                       Lname = row["LName"].ToString()
                                                   });
                    }
                }
            }
            return output;
        }

        [OperationContract]
        public DoctorDetails GetDoctorDetail(int id)
        {
            var output = new DoctorDetails();
            System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            var conStr = config.AppSettings.Settings["DBConnection"].Value;
            using (var sqlConnection = new SqlConnection(conStr))
            {
                sqlConnection.Open();
                using (var sqlDataAdapter = new SqlDataAdapter("GetDoctorDetail", sqlConnection))
                {
                    sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = id;
                    var dataset = new DataSet();
                    sqlDataAdapter.Fill(dataset);
                    if (dataset.Tables.Count > 0)
                    {
                        if (dataset.Tables[0].Rows.Count > 0)
                        {
                            DataRow row = dataset.Tables[0].Rows[0];

                            output.Fname = row["FName"].ToString();
                            output.Lname = row["LName"].ToString();
                            output.ID = id;
                        }
                    }
                }
            }

            return output;
        }

        [OperationContract]
        public List<DoctorDetails> BmhConsentGetPhysicianList(ConsentType consentType)
        {
            var output = new List<DoctorDetails>();
            System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            var conStr = config.AppSettings.Settings["BethesdaDBConnection"].Value;
            using (var sqlConnection = new SqlConnection(conStr))
            {
                using (var sqlDataAdapter = new SqlDataAdapter("BMH_Consent_GetPhysicianList", sqlConnection))
                {
                    sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    var dataset = new DataSet();
                    sqlDataAdapter.Fill(dataset);
                    if (dataset.Tables.Count > 0)
                    {
                        output.AddRange(from DataRow row in dataset.Tables[0].Rows
                                        select new DoctorDetails
                                                   {
                                                       ID = Convert.ToInt32(row[0].ToString()),
                                                       Fname = row[1].ToString(),
                                                       Lname = row[2].ToString()
                                                   });
                    }
                }
            }
            return output;
        }

        [OperationContract]
        public List<AssociatedDoctorDetails> GetAssociatedDoctors(int primaryDoctorID)
        {
            var output = new List<AssociatedDoctorDetails>();
            System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            var conStr = config.AppSettings.Settings["DBConnection"].Value;
            using (var sqlConnection = new SqlConnection(conStr))
            {
                using (var sqlDataAdapter = new SqlDataAdapter("GetAssociatedDoctors", sqlConnection))
                {
                    sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@PCID", SqlDbType.Int)).Value = primaryDoctorID;
                    var dataset = new DataSet();
                    sqlDataAdapter.Fill(dataset);
                    if (dataset.Tables.Count > 0)
                    {
                        output.AddRange(from DataRow row in dataset.Tables[0].Rows select new AssociatedDoctorDetails { Fname = row["FName"].ToString(), Lname = row["LName"].ToString() });
                    }
                }
            }
            return output;
        }

        [OperationContract]
        public void SavePdFFolderPath(ConsentType consenttype, string folderPath)
        {
            System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            var conStr = config.AppSettings.Settings["DBConnection"].Value;
            using (var sqlConnection = new SqlConnection(conStr))
            {
                sqlConnection.Open();

                using (var sqlDataAdapter = new SqlDataAdapter("select ConsentType.ID as ID from ConsentType where ConsentType.Name ='" + consenttype + "' ", sqlConnection))
                {
                    var dataset = new DataSet();
                    sqlDataAdapter.Fill(dataset);
                    if (dataset.Tables.Count > 0)
                        if (dataset.Tables[0].Rows.Count > 0)
                        {
                            DataRow record = dataset.Tables[0].Rows[0];
                            var id = record["ID"].ToString();

                            using (var sqlDataAdapter2 = new SqlDataAdapter("select count(*) from PDFExportPaths where ConsentID='" + id + "' ", sqlConnection))
                            {
                                dataset = new DataSet();
                                sqlDataAdapter2.Fill(dataset);
                                if (dataset.Tables.Count > 0)
                                    if (dataset.Tables[0].Rows.Count > 0)
                                    {
                                        int count = Convert.ToInt32(dataset.Tables[0].Rows[0][0]);
                                        if (count > 0)
                                        {
                                            string sql = "Update PDFExportPaths set ConsentID='" + id + "',Path='" + folderPath + "' where ConsentID='" + id + "'";
                                            var command = new SqlCommand(sql, sqlConnection);
                                            command.ExecuteNonQuery();
                                        }
                                        else
                                        {
                                            string query = "Insert into PDFExportPaths values('" + id + "','" + folderPath + "')";
                                            var sqlcommand = new SqlCommand(query, sqlConnection);
                                            sqlcommand.ExecuteNonQuery();
                                            sqlConnection.Close();
                                        }
                                    }
                            }
                        }
                }
            }
        }

        [OperationContract]
        public string GetPdFFolderPath(ConsentType consenttype)
        {
            System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            var conStr = config.AppSettings.Settings["DBConnection"].Value;
            using (var sqlConnection = new SqlConnection(conStr))
            {
                sqlConnection.Open();
                using (var sqlDataAdapter = new SqlDataAdapter("GetPdFFolderPath", sqlConnection))
                {
                    sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@consentName", SqlDbType.VarChar)).Value = consenttype.ToString();
                    sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    var dataset = new DataSet();
                    sqlDataAdapter.Fill(dataset);
                    if (dataset.Tables.Count > 0 && dataset.Tables[0].Rows.Count > 0)
                        return dataset.Tables[0].Rows[0][0].ToString();
                }
            }
            return string.Empty;
        }

        [OperationContract]
        public bool IsValidEmployee(string empID)
        {
            System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
            var conStr = config.AppSettings.Settings["DBConnection"].Value;
            using (var sqlConnection = new SqlConnection(conStr))
            {
                sqlConnection.Open();

                using (var sqlDataAdapter = new SqlDataAdapter("CountOfEmpIdFromEmployeeInformation", sqlConnection))
                {
                    sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    sqlDataAdapter.SelectCommand.Parameters.Add(new SqlParameter("@EmpID", SqlDbType.NChar)).Value = empID;
                    var dataset = new DataSet();
                    sqlDataAdapter.Fill(dataset);
                    if (dataset.Tables.Count > 0)
                        if (dataset.Tables[0].Rows.Count > 0)
                        {
                            int count = Convert.ToInt32(dataset.Tables[0].Rows[0][0]);
                            if (count > 0)
                            {
                                return true;
                            }
                        }
                }
                return false;
            }
        }

        [OperationContract]
        public bool TestMethod()
        {
            return true;
        }

        //private void InsertSeedRecords(bool associated, bool primaryDoc, int consentTypeId, string fName, string lName, int pcid)
        //{
        //    System.Configuration.Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
        //    var conStr = config.AppSettings.Settings["DBConnection"].Value;
        //    using (var sqlConnection = new SqlConnection(conStr))
        //    {
        //        sqlConnection.Open();
        //        var cmdTreatment = new SqlCommand("insert into Physican(Associated,Primary_Doctor,ConsentTypeID,Fname,Lname,PCID) values('" + (associated == true ? 1 : 0) + ",'" + (primaryDoc == true ? 1 : 0) + ",'" + consentTypeId + ",'" + fName + ",'" + lName + "'," + pcid + "," + "')", sqlConnection);
        //        cmdTreatment.ExecuteNonQuery();
        //    }
        //}

        private DocumentConverterServiceClient OpenService(string address)
        {
            DocumentConverterServiceClient client = null;

            try
            {
                var binding = new BasicHttpBinding();

                // ** Use standard Windows Authentication
                binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;

                // ** Allow long running conversions
                binding.SendTimeout = TimeSpan.FromMinutes(30);
                binding.ReceiveTimeout = TimeSpan.FromMinutes(30);

                // ** Allow file sizes of 50MB
                binding.MaxReceivedMessageSize = 50 * 1024 * 1024;
                binding.ReaderQuotas.MaxArrayLength = 50 * 1024 * 1024;
                binding.ReaderQuotas.MaxStringContentLength = 50 * 1024 * 1024;

                // ** We need to specify an identity (any identity) in order to get it past .net3.5 sp1
                EndpointIdentity epi = EndpointIdentity.CreateUpnIdentity("unknown");
                var epa = new EndpointAddress(new Uri(address), epi);

                client = new DocumentConverterServiceClient(binding, epa);

                client.Open();

                return client;
            }

            catch (Exception)
            {
                CloseService(client);
                throw;
            }
        }

        private void CloseService(DocumentConverterServiceClient client)
        {
            if (client != null && client.State == CommunicationState.Opened)
                client.Close();
        }

        private int GetConsentTypeId(SqlConnection con, SqlTransaction transaction, string concenType)
        {
            var cmdConsentId = new SqlCommand("GetConsentTypeId", con, transaction) { CommandType = CommandType.StoredProcedure };
            cmdConsentId.Parameters.Add(new SqlParameter("@name", SqlDbType.NVarChar)).Value = concenType;
            using (var read = cmdConsentId.ExecuteReader())
            {
                //dr = cmd.ExecuteReader();
                if (read.Read())
                    return Convert.ToInt32(read["ID"].ToString());
                return 0;
            }
        }

        private int GetTrackingId(SqlConnection con, SqlTransaction transaction, string device, string ip)
        {
            var cmdInsert = new SqlCommand("insert into TrackingInformation(Device,IP) values('" + device + "','" + ip + "')", con, transaction);
            cmdInsert.ExecuteNonQuery();

            var cmdTrackingId = new SqlCommand("GetMaxFromTrackingInformation", con, transaction) { CommandType = CommandType.StoredProcedure };
            using (var read = cmdTrackingId.ExecuteReader())
            {
                if (read.Read())
                    return Convert.ToInt32(read["ID"].ToString());
                return 0;
            }
        }

        private int GetDoctorsAndProcedures(SqlConnection con, SqlTransaction transaction, int consentTypeId, IEnumerable<DoctorAndProcedure> doctorsAndProcedures)
        {
            var uniqueId = 0;
            var cmdUniquId = new SqlCommand("select isnull(max(UniqueID),0)+1 as UniqueID from Doctor_Procedures", con, transaction);
            using (var read = cmdUniquId.ExecuteReader())
            {
                if (read.Read())
                    uniqueId = Convert.ToInt32(read["UniqueID"].ToString());
            }
            foreach (DoctorAndProcedure dap in doctorsAndProcedures)
            {
                var strProcedures = dap._precedures.Split('#');
                var procedureId = 0;
                foreach (string procedure in strProcedures)
                {
                    if (!string.IsNullOrEmpty(procedure))
                    {
                        var cmdProcId = new SqlDataAdapter("select ID from CFProcedures where Name='" + procedure + "'", con);
                        var dsProcId = new DataSet();
                        cmdProcId.SelectCommand.Transaction = transaction;
                        cmdProcId.Fill(dsProcId);
                        if (dsProcId.Tables[0].Rows.Count > 0)
                        {
                            procedureId = Convert.ToInt32(dsProcId.Tables[0].Rows[0][0].ToString());
                        }
                        else
                        {
                            var cmdInsert = new SqlCommand("insert into CFProcedures(Name,ConsentTypeID) values('" + procedure + "','" + consentTypeId + "')", con, transaction);
                            cmdInsert.ExecuteNonQuery();

                            var cmdProcId1 = new SqlDataAdapter("select ID from CFProcedures where Name='" + procedure + "'", con);
                            var dsProc = new DataSet();
                            cmdProcId1.SelectCommand.Transaction = transaction;
                            cmdProcId1.Fill(dsProc);
                            if (dsProc.Tables[0].Rows.Count > 0)
                            {
                                procedureId = Convert.ToInt32(dsProc.Tables[0].Rows[0][0].ToString());
                            }
                        }
                    }
                    var cmdInsertDap = new SqlCommand("insert into Doctor_Procedures(ProcID,UniqueID,PrimaryDoctorID) values(" + procedureId + "," + uniqueId + "," + dap._primaryDoctorId + ")", con, transaction);
                    cmdInsertDap.ExecuteNonQuery();
                }
            }

            return uniqueId;
        }

        private int GetSignatures(SqlConnection con, SqlTransaction transaction, IEnumerable<Signatures> signatures)
        {
            var tsID = 0;
            var cmdTsId = new SqlCommand("select isnull(max(TSID),0)+1 as TSID from Treatment_Signature", con, transaction);
            using (var read = cmdTsId.ExecuteReader())
            {
                if (read.Read())
                    tsID = Convert.ToInt32(read["TSID"].ToString());
            }

            foreach (Signatures sig in signatures)
            {
                var strSignatures = sig._signatureType.ToString();
                var signatureId = 0;
                if (!string.IsNullOrEmpty(strSignatures))
                {
                    var cmdSigId = new SqlCommand("select ID from Signatures where Type='" + strSignatures + "'", con, transaction);
                    using (var read1 = cmdSigId.ExecuteReader())
                    {
                        if (read1.Read())
                        {
                            signatureId = Convert.ToInt32(read1["ID"].ToString());
                        }
                    }
                    var cmdInsert = new SqlCommand("insert into Treatment_Signature(SignatureId,TContent,Name,TSID) values(" + signatureId + ",'" + sig._signatureContent + "','" + sig._name + "'," + tsID + ")", con, transaction);
                    cmdInsert.ExecuteNonQuery();
                }
            }
            return tsID;
        }

        private TrackingInformation GetTrackingInformation(SqlConnection con, string trackingId)
        {
            var tracking = new TrackingInformation();
            var cmdTacking = new SqlCommand("GetTrackingInformation", con) { CommandType = CommandType.StoredProcedure };
            cmdTacking.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = trackingId;
            using (var read = cmdTacking.ExecuteReader())
            {
                if (read.Read())
                {
                    tracking._device = read["Device"].ToString();
                    tracking._iP = read["IP"].ToString();
                }
            }
            return tracking;
        }

        private List<DoctorAndProcedure> GetDoctorsProceduresInformation(SqlConnection con, string uniqueId)
        {
            var outPut = new List<DoctorAndProcedure>();
            var daDrProc = new SqlDataAdapter("GetDoctorsProceduresInformation", con) { SelectCommand = { CommandType = CommandType.StoredProcedure } };
            daDrProc.SelectCommand.Parameters.Add(new SqlParameter("@UniqueId", SqlDbType.Int)).Value = uniqueId;
            var dsDr = new DataSet();
            daDrProc.Fill(dsDr);
            if (dsDr.Tables.Count > 0)
            {
                outPut.AddRange(from DataRow row in dsDr.Tables[0].Rows
                                select new DoctorAndProcedure
                                           {
                                               _precedures = row["ProcedureName"].ToString(),
                                               _primaryDoctorId = row["ID"].ToString()
                                           });
            }
            return outPut;
        }

        private List<Signatures> GetSignaturesInformation(SqlConnection con, string signaturesId)
        {
            var listSig = new List<Signatures>();
            try
            {
                var daSig = new SqlDataAdapter("GetSignaturesInformation", con) { SelectCommand = { CommandType = CommandType.StoredProcedure } };
                daSig.SelectCommand.Parameters.Add(new SqlParameter("@TSID", SqlDbType.Int)).Value = signaturesId;
                var dsSig = new DataSet();
                daSig.Fill(dsSig);
                if (dsSig.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dsSig.Tables[0].Rows.Count; i++)
                    {
                        var signatures = new Signatures
                                             {
                                                 _name = dsSig.Tables[0].Rows[i]["Name"].ToString(),
                                                 _signatureContent = dsSig.Tables[0].Rows[i]["TContent"].ToString(),
                                                 _signatureType =
                                                     (SignatureType)
                                                     Enum.Parse(typeof(SignatureType),
                                                                dsSig.Tables[0].Rows[i]["SType"].ToString())
                                             };
                        listSig.Add(signatures);
                    }
                }
            }
            catch (Exception)
            {
                return listSig;
            }
            return listSig;
        }
    }
}