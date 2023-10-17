namespace SimpleSheduler
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.TaskDataView = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsFinished = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsInProgress = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CreatedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChangedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.TaskDataView)).BeginInit();
            this.SuspendLayout();
            // 
            // TaskDataView
            // 
            this.TaskDataView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TaskDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TaskDataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.TaskName,
            this.TaskDescription,
            this.IsFinished,
            this.IsInProgress,
            this.CreatedDate,
            this.ChangedDate});
            this.TaskDataView.Location = new System.Drawing.Point(-1, -2);
            this.TaskDataView.Name = "TaskDataView";
            this.TaskDataView.RowHeadersWidth = 62;
            this.TaskDataView.RowTemplate.Height = 28;
            this.TaskDataView.Size = new System.Drawing.Size(1676, 647);
            this.TaskDataView.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.HeaderText = "№";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 150;
            // 
            // TaskName
            // 
            this.TaskName.HeaderText = "Task Name";
            this.TaskName.MinimumWidth = 8;
            this.TaskName.Name = "TaskName";
            this.TaskName.Width = 150;
            // 
            // TaskDescription
            // 
            this.TaskDescription.HeaderText = "Description";
            this.TaskDescription.MinimumWidth = 8;
            this.TaskDescription.Name = "TaskDescription";
            this.TaskDescription.Width = 150;
            // 
            // IsFinished
            // 
            this.IsFinished.HeaderText = "Is Completed?";
            this.IsFinished.MinimumWidth = 8;
            this.IsFinished.Name = "IsFinished";
            this.IsFinished.ReadOnly = true;
            this.IsFinished.Width = 150;
            // 
            // IsInProgress
            // 
            this.IsInProgress.HeaderText = "Working on it?";
            this.IsInProgress.MinimumWidth = 8;
            this.IsInProgress.Name = "IsInProgress";
            this.IsInProgress.ReadOnly = true;
            this.IsInProgress.Width = 150;
            // 
            // CreatedDate
            // 
            this.CreatedDate.HeaderText = "Created:";
            this.CreatedDate.MinimumWidth = 8;
            this.CreatedDate.Name = "CreatedDate";
            this.CreatedDate.ReadOnly = true;
            this.CreatedDate.Width = 150;
            // 
            // ChangedDate
            // 
            this.ChangedDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ChangedDate.HeaderText = "Modified/Finished:";
            this.ChangedDate.MinimumWidth = 8;
            this.ChangedDate.Name = "ChangedDate";
            this.ChangedDate.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1678, 644);
            this.Controls.Add(this.TaskDataView);
            this.MaximumSize = new System.Drawing.Size(1700, 700);
            this.MinimumSize = new System.Drawing.Size(1500, 150);
            this.Name = "MainForm";
            this.Text = "My Sheduler :)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TaskDataView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView TaskDataView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskDescription;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsFinished;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsInProgress;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreatedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ChangedDate;
    }
}

