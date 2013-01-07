using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Configuration;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using WindowsCEConsentForms.FormHandlerService;
using Configuration = System.Configuration.Configuration;

namespace WindowsCEConsentForms.Administration
{
    public partial class Setup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string checkIfExist = ConfigurationManager.AppSettings["DBSetupStatus"];
            //if (checkIfExist == "1")
            //{
            //    PnlDBConfiguration.Visible = false;
            //}
            if (!IsPostBack)
            {
                RdoSqlServerAuthentication.Checked = true;
                Reset();
            }
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            TxtDatabasename.Text = string.Empty;
            TxtServerName.Text = string.Empty;
            TxtUsername.Text = string.Empty;
            TxtPassword.Text = string.Empty;

            TxtDatabasenameExternal.Text = string.Empty;
            TxtServerNameExternal.Text = string.Empty;
            TxtUsernameExternal.Text = string.Empty;
            TxtPasswordExternal.Text = string.Empty;

            TxtBloodConsentOrRefusalExportPath.Text = string.Empty;
            TxtCardiovascularExportPath.Text = string.Empty;
            TxtEndoscopyExportPath.Text = string.Empty;
            TxtOutsideORExportPath.Text = string.Empty;
            TxtPICCExportPath.Text = string.Empty;
            TxtPlasmanApheresisExportPath.Text = string.Empty;
            TxtSurgicalExportPath.Text = string.Empty;
            TxtServerName.Focus();

            // Getting export paths and display in boxes

            var formHandlerServices = new ConsentFormSvcClient();
            TxtBloodConsentOrRefusalExportPath.Text = formHandlerServices.GetPdFFolderPath(ConsentType.BloodConsentOrRefusal);
            TxtCardiovascularExportPath.Text = formHandlerServices.GetPdFFolderPath(ConsentType.Cardiovascular);
            TxtEndoscopyExportPath.Text = formHandlerServices.GetPdFFolderPath(ConsentType.Endoscopy);
            TxtOutsideORExportPath.Text = formHandlerServices.GetPdFFolderPath(ConsentType.OutsideOR);
            TxtPICCExportPath.Text = formHandlerServices.GetPdFFolderPath(ConsentType.PICC);
            TxtPlasmanApheresisExportPath.Text = formHandlerServices.GetPdFFolderPath(ConsentType.PlasmanApheresis);
            TxtSurgicalExportPath.Text = formHandlerServices.GetPdFFolderPath(ConsentType.Surgical);

            SetCredentialPanel();
        }

        protected void BtnCompleted_Click(object sender, EventArgs e)
        {
            if (PnlDBConfiguration.Visible)
            {
                try
                {
                    if (!string.IsNullOrEmpty(TxtServerName.Text.Trim()) &&
                        !string.IsNullOrEmpty(TxtDatabasename.Text.Trim()) ||

                        (RdoSqlServerAuthentication.Checked && !string.IsNullOrEmpty(TxtUsername.Text.Trim()) && !string.IsNullOrEmpty(TxtPassword.Text.Trim())))
                    {
                        string checkIfExist = ConfigurationManager.AppSettings["DBSetupStatus"];
                        if (checkIfExist == "0")
                        {
                            string connectionString;
                            if (RdoSqlServerAuthentication.Checked)
                                connectionString = @"server=" + TxtServerName.Text.Trim() + ";database=master;uid=" +
                                   TxtUsername.Text.Trim() + ";pwd=" + TxtPassword.Text.Trim();
                            else
                                connectionString = "Server=" + TxtServerName.Text.Trim() + ";Database=" + TxtDatabasename.Text.Trim() + ";Trusted_Connection=True;";
                            Configuration config =
                                WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
                            config.AppSettings.Settings.Remove("ConnectionString");
                            config.AppSettings.Settings.Add("ConnectionString", connectionString);
                            config.Save(ConfigurationSaveMode.Modified);
                            ConfigurationManager.RefreshSection("appSettings");

                            var formHanlderServices = new ConsentFormSvcClient();
                            formHanlderServices.SetDBConnection(connectionString);

                            if (CreateDatabase(TxtDatabasename.Text.Trim(), connectionString))
                            {
                                config.AppSettings.Settings.Remove("DBSetupStatus");
                                config.AppSettings.Settings.Add("DBSetupStatus", "1");
                                connectionString = connectionString.Replace(connectionString.Split('=')[2],
                                                                            TxtDatabasename.Text + ";uid");
                                config.AppSettings.Settings.Remove("ConnectionString");
                                config.AppSettings.Settings.Add("ConnectionString", connectionString);
                                config.Save(ConfigurationSaveMode.Modified);
                                ConfigurationManager.RefreshSection("appSettings");
                                LblError.Text = "Database Created Succefully";
                            }
                        }
                        else
                            LblError.Text = "DB Information Already configured.";
                    }
                    else
                        LblError.Text = "Please input required fields and submit.";
                }
                catch (Exception ex)
                {
                    LblError.Text = "Unable to create database due to [" + ex.Message + "]";
                }

                try
                {
                    if (!string.IsNullOrEmpty(TxtServerNameExternal.Text.Trim()) &&
                        !string.IsNullOrEmpty(TxtDatabasenameExternal.Text.Trim()) ||

                        (RdoSqlServerAuthenticationExternal.Checked && !string.IsNullOrEmpty(TxtUsernameExternal.Text.Trim()) && !string.IsNullOrEmpty(TxtPasswordExternal.Text.Trim())))
                    {
                        string connectionString;
                        if (RdoSqlServerAuthenticationExternal.Checked)
                            connectionString = @"server=" + TxtServerNameExternal.Text.Trim() + ";database=master;uid=" +
                               TxtUsernameExternal.Text.Trim() + ";pwd=" + TxtPasswordExternal.Text.Trim();
                        else
                            connectionString = "Server=" + TxtServerNameExternal.Text.Trim() + ";Database=" + TxtDatabasenameExternal.Text.Trim() + ";Trusted_Connection=True;";
                        Configuration config =
                            WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
                        config.AppSettings.Settings.Remove("BethesdaConnectionString");
                        config.AppSettings.Settings.Add("BethesdaConnectionString", connectionString);
                        config.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("appSettings");

                        var formHanlderServices = new ConsentFormSvcClient();
                        formHanlderServices.SetBethesdaDBConnection(connectionString);

                    }
                    else
                        LblError.Text = "Please input required fields and submit.";
                }
                catch (Exception ex)
                {
                    LblError.Text = "Unable to create database due to [" + ex.Message + "]";
                }
            }

            //setting exports path
            try
            {
                if (!string.IsNullOrEmpty(TxtSurgicalExportPath.Text.Trim())
                    && !string.IsNullOrEmpty(TxtBloodConsentOrRefusalExportPath.Text.Trim())
                    && !string.IsNullOrEmpty(TxtCardiovascularExportPath.Text.Trim())
                    && !string.IsNullOrEmpty(TxtEndoscopyExportPath.Text.Trim())
                    && !string.IsNullOrEmpty(TxtOutsideORExportPath.Text.Trim())
                    && !string.IsNullOrEmpty(TxtPICCExportPath.Text.Trim())
                    && !string.IsNullOrEmpty(TxtPlasmanApheresisExportPath.Text.Trim()))
                {
                    var formHanlderServices = new ConsentFormSvcClient();
                    formHanlderServices.SavePdFFolderPath(ConsentType.Surgical, TxtSurgicalExportPath.Text);
                    formHanlderServices.SavePdFFolderPath(ConsentType.BloodConsentOrRefusal, TxtBloodConsentOrRefusalExportPath.Text);
                    formHanlderServices.SavePdFFolderPath(ConsentType.Cardiovascular, TxtCardiovascularExportPath.Text);
                    formHanlderServices.SavePdFFolderPath(ConsentType.Endoscopy, TxtEndoscopyExportPath.Text);
                    formHanlderServices.SavePdFFolderPath(ConsentType.OutsideOR, TxtOutsideORExportPath.Text);
                    formHanlderServices.SavePdFFolderPath(ConsentType.PICC, TxtPICCExportPath.Text);
                    formHanlderServices.SavePdFFolderPath(ConsentType.PlasmanApheresis, TxtPlasmanApheresisExportPath.Text);
                    LblError.Text = "Export paths saved successfully.";
                }
                else
                    LblError.Text = "Please input all exports path and then complete.";
            }
            catch (Exception ex)
            {
                LblError.Text = "Unable to config export paths due to [" + ex.Message + "]";
            }
        }

        public bool CreateDatabase(string databaseName, string connectionString)
        {
            using (var connData = new SqlConnection(connectionString))
            {
                var file = new FileInfo(Server.MapPath("/Administration/ConsentDB.sql"));
                string script = file.OpenText().ReadToEnd();
                var streamReader = new StreamReader(Server.MapPath("/Administration/ConsentDB.sql"));
                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine();
                    if (line != null && line.Split(' ')[0].ToLower() == "use")
                    {
                        script = script.Replace(line.Split('[')[1], databaseName + "]");
                        break;
                    }
                }
                streamReader.Dispose();
                var server = new Server(new ServerConnection(connData));
                server.ConnectionContext.ExecuteNonQuery("create database [" + databaseName + "]");
                server.ConnectionContext.ExecuteNonQuery(script);
                file.OpenText().Close();
                connData.Close();
                return true;
            }
        }

        protected void RdoSqlServerAuthentication_CheckedChanged(object sender, EventArgs e)
        {
            SetCredentialPanel();
        }

        protected void RdoWindowsAuthentication_CheckedChanged(object sender, EventArgs e)
        {
            SetCredentialPanel();
        }

        protected void RdoWindowsAuthenticationExternal_CheckedChanged(object sender, EventArgs e)
        {
            SetCredentialPanelExternal();
        }

        private void SetCredentialPanel()
        {
            PnlCredentials1.Visible = RdoSqlServerAuthentication.Checked;
            PnlCredentials2.Visible = RdoSqlServerAuthentication.Checked;
        }

        private void SetCredentialPanelExternal()
        {
            PnlCredentialsExternal1.Visible = RdoSqlServerAuthenticationExternal.Checked;
            PnlCredentialsExternal2.Visible = RdoSqlServerAuthenticationExternal.Checked;
        }

        private bool CheckConnectionString(string connectionString,string errorText)
        {
            try
            {
                using(SqlConnection connection=new SqlConnection())
                {
                    connection.Open();
                }
                return true;
            }
            catch (Exception)
            {
                LblError.Text = errorText;
                return false;
            }
        }
    }
}