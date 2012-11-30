using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.Configuration;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Configuration = System.Configuration.Configuration;

namespace WindowsCEConsentForms.Administration
{
    public partial class Setup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string checkIfExist = ConfigurationManager.AppSettings["DBSetupStatus"];
            if (checkIfExist != "0")
            {
                Response.Redirect("/patientConsent.aspx");
            }
        }

        protected void BtnReset_Click(object sender, EventArgs e)
        {
            TxtDatabasename.Text = string.Empty;
            TxtServerName.Text = string.Empty;
            TxtUsername.Text = string.Empty;
            TxtPassword.Text = string.Empty;
            TxtServerName.Focus();
        }

        protected void BtnCompleted_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtServerName.Text.Trim()) && !string.IsNullOrEmpty(TxtDatabasename.Text.Trim()) && !string.IsNullOrEmpty(TxtUsername.Text.Trim()) && !string.IsNullOrEmpty(TxtPassword.Text.Trim()))
            {
                string checkIfExist = ConfigurationManager.AppSettings["DBSetupStatus"];
                if (checkIfExist == "0")
                {
                    string connectionString = @"server=" + TxtServerName.Text.Trim() + ";database=master;uid=" + TxtUsername.Text.Trim() + ";pwd=" + TxtPassword.Text.Trim();
                    Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
                    config.AppSettings.Settings.Remove("ConnectionString");
                    config.AppSettings.Settings.Add("ConnectionString", connectionString);
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");

                    if (CreateDatabase(TxtDatabasename.Text.Trim(), connectionString))
                    {
                        config.AppSettings.Settings.Remove("DBSetupStatus");
                        config.AppSettings.Settings.Add("DBSetupStatus", "1");
                        connectionString = connectionString.Replace(connectionString.Split('=')[2], TxtDatabasename.Text + ";uid");
                        config.AppSettings.Settings.Remove("ConnectionString");
                        config.AppSettings.Settings.Add("ConnectionString", connectionString);
                        config.Save(ConfigurationSaveMode.Modified);
                        ConfigurationManager.RefreshSection("appSettings");
                        LblError.Text = "Database Created Succefully";
                    }
                }
            }
            else
                LblError.Text = "Please input required fields and submit.";
        }

        public bool CreateDatabase(string databaseName, string connectionString)
        {
            try
            {
                string strConnData = ConfigurationManager.AppSettings["ConnectionString"];
                using (var connData = new SqlConnection(strConnData))
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
            catch (Exception)
            {
                return false;
            }
        }
    }
}