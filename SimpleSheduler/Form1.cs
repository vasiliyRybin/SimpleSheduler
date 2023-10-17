using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleSheduler
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                bool DB_Exists = QueriesAndMaintainanceClass.CheckIfDBExists();
                if (!DB_Exists)
                {
                    QueriesAndMaintainanceClass.CreateDBAndTable_MissingDB();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + "\n\n" + ex.Message + "\n\n" + ex.StackTrace);
                throw;
            }
            finally 
            {
                Environment.Exit(2);
            }
        }
    }
}
