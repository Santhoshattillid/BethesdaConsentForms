using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using Microsoft.Win32.TaskScheduler;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main()
        {
            // Get the service on the local machine
            using (var ts = new TaskService())
            {
                if (ts.RootFolder.GetTasks().Any(task => task.Name == "BethedaContentSync"))
                {
                    ts.RootFolder.DeleteTask("BethedaContentSync");
                }

                // Create a new task definition and assign properties
                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = "Bethesda Employee, Patient and Physician import task.";

                // Create a trigger that will fire the task at this time every day
                //td.Triggers.Add(new DailyTrigger { StartBoundary = DateTime.Now.AddHours(-DateTime.Now.Hour), DaysInterval = 1, Enabled = true });
                td.Triggers.Add(new DailyTrigger { StartBoundary = DateTime.Now.AddSeconds(5), DaysInterval = 1, Enabled = true });

                string path = @"C:\Program Files\Internet Explorer\iexplore.exe";

                // Create an action that will launch Notepad whenever the trigger fires
                td.Actions.Add(new ExecAction(path, "", null));

                // Register the task in the root folder
                ts.RootFolder.RegisterTaskDefinition(@"BethedaContentSync", td);
            }

            return;

            const string localConStr = "server=192.168.1.158;database=bethesdaCollege;uid=sa;pwd=sa@123";
            const string bethesdaConStr = "server=192.168.1.93;database=Soarian_Clin_Tst_1;uid=sa;pwd=sa@123";

            using (var sqlConnectionLocal = new SqlConnection(localConStr))
            {
                sqlConnectionLocal.Open();
                using (var sqlConnectionBethesda = new SqlConnection(bethesdaConStr))
                {
                    sqlConnectionBethesda.Open();

                    # region Import Physician

                    //                    // ---------------starts physician import process------------------

                    //                    // starts synchronizing
                    //                    var command = new SqlCommand(string.Empty, sqlConnectionBethesda)
                    //                    {
                    //                        //CommandText = "select user_oid,GroupName,UserDescription from [soariandbtest].[dbo].[Physician]"
                    //                        CommandText = "BMH_Consent_GetPhysicianList",
                    //                        CommandType = CommandType.StoredProcedure
                    //                    };

                    //                    var daPhysician = new SqlDataAdapter(command);

                    //                    var physiciansDs = new DataSet();
                    //                    daPhysician.Fill(physiciansDs);

                    //                    int syncId = Convert.ToInt32(DateTime.Now.Ticks % 65323);

                    //                    foreach (DataTable dataTable in physiciansDs.Tables)
                    //                    {
                    //                        foreach (DataRow dataRow in dataTable.Rows)
                    //                        {
                    //                            command = new SqlCommand("select * from Physician where Fname='" + dataRow["UserDescription"] + "'", sqlConnectionLocal);

                    //                            daPhysician = new SqlDataAdapter(command);

                    //                            var physiciansCheck = new DataSet();
                    //                            daPhysician.Fill(physiciansCheck);

                    //                            if (physiciansCheck.Tables.Count == 0 || physiciansCheck.Tables[0].Rows.Count == 0)
                    //                            {
                    //                                string physicianName = dataRow["UserDescription"].ToString();
                    //                                string userId = dataRow["user_oid"].ToString();
                    //                                string groupName = dataRow["GroupName"].ToString();

                    //                                command = new SqlCommand(@"insert into Physician
                    //                                                            values('False','True',8,'" + physicianName + "','" + userId +
                    //                                                            "',0,'" + groupName + "'," + syncId + ")", sqlConnectionLocal);
                    //                                command.ExecuteNonQuery();
                    //                            }
                    //                        }
                    //                    }

                    //                    // removing un - available physicians
                    //                    command = new SqlCommand("delete from Physician where SyncID !=" + syncId, sqlConnectionLocal);
                    //                    command.ExecuteNonQuery();

                    #endregion

                    #region Import Patients for BHE location

                    AddPatient(sqlConnectionLocal, sqlConnectionBethesda, "BHE");

                    AddPatient(sqlConnectionLocal, sqlConnectionBethesda, "BMH");

                    #endregion
                }
            }
        }

        private static void AddPatient(SqlConnection sqlConnectionLocal, SqlConnection sqlConnectionBethesda, string location)
        {
            // ---------------starts patient import process------------------

            // starts synchronizing
            var command = new SqlCommand(string.Empty, sqlConnectionBethesda)
            {
                CommandText = "BMH_Consent_GetCurrentCensus",
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add(new SqlParameter("@Entity", SqlDbType.NVarChar)).Value = location;

            var daPatients = new SqlDataAdapter(command);

            var patientDs = new DataSet();
            daPatients.Fill(patientDs);

            foreach (DataTable dataTable in patientDs.Tables)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    command = new SqlCommand("select * from Patient where Patient#='" + dataRow["PatientAccountID"] + "'", sqlConnectionLocal);

                    daPatients = new SqlDataAdapter(command);

                    var patientCheck = new DataSet();
                    daPatients.Fill(patientCheck);

                    if (patientCheck.Tables.Count == 0 || patientCheck.Tables[0].Rows.Count == 0)
                    {
                        string fullname = dataRow["FullName"].ToString();
                        string mrn = dataRow["MRN"].ToString();
                        string patientAccountId = dataRow["PatientAccountID"].ToString();
                        string sex = dataRow["Sex"].ToString();
                        string birthDate = dataRow["BirthDate"].ToString();
                        string attPhysicianName = dataRow["AttPhysicianName"].ToString();
                        string visitDateTime = dataRow["VisitStartDateTime"].ToString();
                        string age = dataRow["Age"].ToString();

                        command = new SqlCommand(@"insert into Patient
                                                   values('','','" + fullname + "','" + birthDate + "','" + age +
                                                 "','" + sex + "','" + mrn + "',0,0,'" + visitDateTime + "','" + location +
                                                 "','','" + patientAccountId + "','" + attPhysicianName + "')", sqlConnectionLocal);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    }
}