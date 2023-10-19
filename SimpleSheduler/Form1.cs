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
                bool DB_Exists = MaintainanceClass.CheckIfDBExists();
                if (!DB_Exists)
                {
                    var succesfullyCreated = MaintainanceClass.CreateDBAndTable_MissingDB();
                    if (!succesfullyCreated) Log.Information("Main table been not created, check the DB connection");
                }

                var tasks = MaintainanceClass.GetAllTasks_ToList();
                if (tasks.Count == 0) MessageBox.Show("Something went wrong during getting tasks list. Please check log");

                TaskDataView.Rows.Clear();

                foreach (var item in tasks)
                {
                    int rowIdx = TaskDataView.Rows.Add();
                    TaskDataView.Rows[rowIdx].Cells["ID"].Value = item.TaskID;
                    TaskDataView.Rows[rowIdx].Cells["TaskName"].Value = item.TaskName;
                    TaskDataView.Rows[rowIdx].Cells["TaskDescription"].Value = item.TaskDescription;
                    TaskDataView.Rows[rowIdx].Cells["IsFinished"].Value = item.IsFinished;
                    TaskDataView.Rows[rowIdx].Cells["IsInProgress"].Value = item.IsInProcess;
                    TaskDataView.Rows[rowIdx].Cells["CreatedDate"].Value = item.CreatedDate;
                    TaskDataView.Rows[rowIdx].Cells["ChangedDate"].Value = item.ChangedDate == new DateTime() ? "" : item.ChangedDate.ToString();
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
