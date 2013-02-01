using System;
using System.Linq;
using Microsoft.Win32.TaskScheduler;

namespace WindowsCEConsentForms.Administration
{
    public partial class Synchronization : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Get the service on the local machine
                using (var ts = new TaskService())
                {
                    bool isTaskFound = ts.RootFolder.GetTasks().Any(task => task.Name == "BethedaContentSync");
                    if (!isTaskFound)
                    {
                        // Create a new task definition and assign properties
                        TaskDefinition td = ts.NewTask();
                        td.RegistrationInfo.Description = "Bethesda Employee, Patient and Physician import task.";

                        // Create a trigger that will fire the task at this time every day
                        td.Triggers.Add(new DailyTrigger
                                            {
                                                StartBoundary = DateTime.Now.AddHours(-DateTime.Now.Hour),
                                                DaysInterval = 1,
                                                Enabled = true
                                            });

                        // Create an action that will launch Notepad whenever the trigger fires
                        td.Actions.Add(new ExecAction(Request.Url.Host, "", null));

                        // Register the task in the root folder
                        ts.RootFolder.RegisterTaskDefinition(@"BethedaContentSync", td);
                    }
                }

                var formHandlerServiceClient = Utilities.GetConsentFormSvcClient();
                formHandlerServiceClient.SynchronizeBethesdaData();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                Response.Write(ex.StackTrace);
            }
        }
    }
}