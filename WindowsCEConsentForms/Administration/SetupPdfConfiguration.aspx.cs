using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.ServiceModel;
using System.Web;
using System.Web.Configuration;
using WindowsCEConsentForms.ConsentFormSvc;

namespace WindowsCEConsentForms.Administration
{
    public partial class SetupPdfConfiguration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Reset();
                }
            }
            catch (Exception ex)
            {
                try
                {
                    var client = Utilities.GetConsentFormSvcClient();
                    client.CreateLog(Utilities.GetUsername(Session), LogType.E, GetType().Name + "-" + new StackTrace().GetFrame(0).GetMethod().ToString(),
                                     ex.Message + Environment.NewLine + ex.StackTrace);
                }
                catch (Exception)
                {
                }
            }
        }

        protected void BtnCompleted_Click(object sender, EventArgs e)
        {
            try
            {
                // loading WCF Service URL from web.config
                Configuration config =
                    WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);

                // Getting export paths and display in boxes
                var endpoint = new EndpointAddress(new Uri(config.AppSettings.Settings["ServiceURL"].Value));
                var formHandlerServices = new ConsentFormSvcClient(new BasicHttpBinding(), endpoint);

                if (!string.IsNullOrEmpty(TxtBloodConsentOrRefusalExportPath.Text.Trim()))
                    formHandlerServices.SavePdFFolderPath(ConsentType.BloodConsentOrRefusal,
                                                          TxtBloodConsentOrRefusalExportPath.Text.Trim());

                if (!string.IsNullOrEmpty(TxtCardiovascularExportPath.Text.Trim()))
                    formHandlerServices.SavePdFFolderPath(ConsentType.Cardiovascular,
                                                          TxtCardiovascularExportPath.Text.Trim());

                if (!string.IsNullOrEmpty(TxtEndoscopyExportPath.Text.Trim()))
                    formHandlerServices.SavePdFFolderPath(ConsentType.Endoscopy, TxtEndoscopyExportPath.Text.Trim());

                if (!string.IsNullOrEmpty(TxtOutsideORExportPath.Text.Trim()))
                    formHandlerServices.SavePdFFolderPath(ConsentType.OutsideOR, TxtOutsideORExportPath.Text.Trim());

                if (!string.IsNullOrEmpty(TxtPICCExportPath.Text.Trim()))
                    formHandlerServices.SavePdFFolderPath(ConsentType.PICC, TxtPICCExportPath.Text.Trim());

                if (!string.IsNullOrEmpty(TxtPlasmanApheresisExportPath.Text.Trim()))
                    formHandlerServices.SavePdFFolderPath(ConsentType.PlasmanApheresis,
                                                          TxtPlasmanApheresisExportPath.Text.Trim());

                if (!string.IsNullOrEmpty(TxtSurgicalExportPath.Text.Trim()))
                    formHandlerServices.SavePdFFolderPath(ConsentType.Surgical, TxtSurgicalExportPath.Text.Trim());

                if (!string.IsNullOrEmpty(TxtDomain.Text.Trim()) &&
                    !string.IsNullOrEmpty(TxtUsernameExports.Text.Trim()) &&
                    !string.IsNullOrEmpty(TxtPasswordExports.Text.Trim()))
                {
                    formHandlerServices.SavePdFPathCredentials(new Credentials
                                                                   {
                                                                       Domain = TxtDomain.Text.Trim(),
                                                                       Username = TxtUsernameExports.Text.Trim(),
                                                                       Password = TxtPasswordExports.Text.Trim()
                                                                   });
                }

                LblError.Text = "Configuration saved successfully.";
            }
            catch (Exception ex)
            {
                try
                {
                    var client = Utilities.GetConsentFormSvcClient();
                    client.CreateLog(Utilities.GetUsername(Session), LogType.E, GetType().Name + "-" + new StackTrace().GetFrame(0).GetMethod().ToString(),
                                     ex.Message + Environment.NewLine + ex.StackTrace);
                }
                catch (Exception)
                {
                }
            }
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            try
            {
                TxtBloodConsentOrRefusalExportPath.Text = string.Empty;
                TxtCardiovascularExportPath.Text = string.Empty;
                TxtEndoscopyExportPath.Text = string.Empty;
                TxtOutsideORExportPath.Text = string.Empty;
                TxtPICCExportPath.Text = string.Empty;
                TxtPlasmanApheresisExportPath.Text = string.Empty;
                TxtSurgicalExportPath.Text = string.Empty;

                // loading WCF Service URL from web.config
                Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);

                // Getting export paths and display in boxes
                var endpoint = new EndpointAddress(new Uri(config.AppSettings.Settings["ServiceURL"].Value));
                var formHandlerServices = new ConsentFormSvcClient(new BasicHttpBinding(), endpoint);

                try // initially it might throw error
                {
                    TxtBloodConsentOrRefusalExportPath.Text =
                        formHandlerServices.GetPdFFolderPath(ConsentType.BloodConsentOrRefusal);
                    TxtCardiovascularExportPath.Text = formHandlerServices.GetPdFFolderPath(ConsentType.Cardiovascular);
                    TxtEndoscopyExportPath.Text = formHandlerServices.GetPdFFolderPath(ConsentType.Endoscopy);
                    TxtOutsideORExportPath.Text = formHandlerServices.GetPdFFolderPath(ConsentType.OutsideOR);
                    TxtPICCExportPath.Text = formHandlerServices.GetPdFFolderPath(ConsentType.PICC);
                    TxtPlasmanApheresisExportPath.Text = formHandlerServices.GetPdFFolderPath(ConsentType.PlasmanApheresis);
                    TxtSurgicalExportPath.Text = formHandlerServices.GetPdFFolderPath(ConsentType.Surgical);
                }
                catch (Exception)
                {
                }

                // try to loading credentials for export path
                try
                {
                    var credentials = formHandlerServices.GetPdFPathCredentials();
                    TxtDomain.Text = credentials.Domain;
                    TxtUsernameExports.Text = credentials.Username;
                    TxtPasswordExports.Text = credentials.Password;
                }
                catch (Exception)
                {
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