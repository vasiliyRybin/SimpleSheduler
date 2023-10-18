using Serilog;
using System;
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
                string test = QueriesStorage.SelectAllQuery.Substring(QueriesStorage.SelectAllQuery.Trim().ToLower().IndexOf(" "), QueriesStorage.SelectAllQuery.ToLower().IndexOf(" FROM"));
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
