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
            TxtBloodConsentOrRefusalExportPath.Text = string.Empty;
            TxtCardiovascularExportPath.Text = string.Empty;
            TxtEndoscopyExportPath.Text = string.Empty;
            TxtOutsideORExportPath.Text = string.Empty;
            TxtPICCExportPath.Text = string.Empty;
            TxtPlasmanApheresisExportPath.Text = string.Empty;
            TxtSurgicalExportPath.Text = string.Empty;
            TxtServerName.Focus();

            // Getting export paths and display in boxes

            var formHandlerServices = new FormHandlerServiceClient();
            TxtBloodConsentOrRefusalExportPath.Text = formHandlerServices.GetPdfFolderPath(ConsentType.BloodConsentOrRefusal);
            TxtCardiovascularExportPath.Text = formHandlerServices.GetPdfFolderPath(ConsentType.Cardiovascular);
            TxtEndoscopyExportPath.Text = formHandlerServices.GetPdfFolderPath(ConsentType.Endoscopy);
            TxtOutsideORExportPath.Text = formHandlerServices.GetPdfFolderPath(ConsentType.OutsideOR);
            TxtPICCExportPath.Text = formHandlerServices.GetPdfFolderPath(ConsentType.PICC);
            TxtPlasmanApheresisExportPath.Text = formHandlerServices.GetPdfFolderPath(ConsentType.PlasmanApheresis);
            TxtSurgicalExportPath.Text = formHandlerServices.GetPdfFolderPath(ConsentType.Surgical);

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
                    var formHanlderServices = new FormHandlerServiceClient();
                    formHanlderServices.savePdfFoderPath(ConsentType.Surgical.ToString(), TxtSurgicalExportPath.Text);
                    formHanlderServices.savePdfFoderPath(ConsentType.BloodConsentOrRefusal.ToString(), TxtBloodConsentOrRefusalExportPath.Text);
                    formHanlderServices.savePdfFoderPath(ConsentType.Cardiovascular.ToString(), TxtCardiovascularExportPath.Text);
                    formHanlderServices.savePdfFoderPath(ConsentType.Endoscopy.ToString(), TxtEndoscopyExportPath.Text);
                    formHanlderServices.savePdfFoderPath(ConsentType.OutsideOR.ToString(), TxtOutsideORExportPath.Text);
                    formHanlderServices.savePdfFoderPath(ConsentType.PICC.ToString(), TxtPICCExportPath.Text);
                    formHanlderServices.savePdfFoderPath(ConsentType.PlasmanApheresis.ToString(), TxtPlasmanApheresisExportPath.Text);
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

        private void SetCredentialPanel()
        {
            PnlCredentials1.Visible = RdoSqlServerAuthentication.Checked;
            PnlCredentials2.Visible = RdoSqlServerAuthentication.Checked;
        }
    }
}