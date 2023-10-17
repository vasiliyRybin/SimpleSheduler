using Serilog;
using System;
using System.Windows.Forms;

namespace SimpleSheduler
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            string logFilePath = Environment.CurrentDirectory + "\\Info.log";
            Log.Logger = new LoggerConfiguration().WriteTo.File(logFilePath).CreateLogger();
            Log.Logger.Information("Program started at " + DateTime.Now);
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                bool DB_Exists = QueriesAndMaintainanceClass.CheckIfDBExists();
                if (!DB_Exists)
                {
                    var succesfullyCreated = QueriesAndMaintainanceClass.CreateDBAndTable_MissingDB();
                    if (!succesfullyCreated) Log.Information("Main table been not created, check the DB connection");
                }
            }
            catch (Exception ex)
            {
                Log.Logger.Fatal(ex.ToString() + "\n\n" + ex.Message + "\n\n" + ex.StackTrace);
                Log.Logger.Fatal(DateTime.Now + " Exiting program...");
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
