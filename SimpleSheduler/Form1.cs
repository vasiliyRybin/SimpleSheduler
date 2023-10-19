using Serilog;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace SimpleSheduler
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File(GlobalVariables.logFilePath).CreateLogger();
            Log.Information("Program started at " + DateTime.Now);
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                ////////////////////////////////////////THING TO REMOVE AFTER TESTS//////////////////////////////////////////////////
                List<Dictionary<string, string>> DBObjects_List = new List<Dictionary<string, string>>(); 
                Dictionary<string, string> DBObject;
                using (var sqlite = new SQLiteConnection($"Data Source={GlobalVariables.dbPath}"))
                {
                    sqlite.Open();
                    SQLiteCommand command = new SQLiteCommand(QueriesStorage.SelectAllQuery, sqlite);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DBObject = new Dictionary<string, string>();

                            for (int i = 0; i < reader.FieldCount; i++) 
                            {
                                DBObject.Add(reader.GetName(i), reader[i]?.ToString());
                            }

                            DBObjects_List.Add(DBObject);
                        }
                    }
                }

                Validators.Validate_SheduledTaskList(DBObjects_List);
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                
                bool DB_Exists = MaintainanceClass.CheckIfDBExists();
                if (!DB_Exists)
                {
                    var succesfullyCreated = MaintainanceClass.CreateDBAndTable_MissingDB();
                    if (!succesfullyCreated) Log.Information("Main table been not created, check the DB connection");
                }
            }
            catch (Exception ex)
            {
                Log.Fatal(ex.ToString() + "\n\n" + ex.Message + "\n\n" + ex.StackTrace);
                Log.Fatal("Exiting program...");
                Environment.Exit(2);
            }

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log.Information("Exiting program. Enjoy your day :)");
            Log.CloseAndFlush();
        }
    }
}
