namespace job_calendar
{
    partial class DayView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dayListDgv = new DataGridView();
            addBtn = new Button();
            editBtn = new Button();
            deleteBtn = new Button();
            closeBtn = new Button();
            label1 = new Label();
            numApplicationsLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)dayListDgv).BeginInit();
            SuspendLayout();
            // 
            // dayListDgv
            // 
            dayListDgv.AllowUserToAddRows = false;
            dayListDgv.AllowUserToDeleteRows = false;
            dayListDgv.AllowUserToResizeRows = false;
            dayListDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dayListDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dayListDgv.Location = new Point(12, 60);
            dayListDgv.MultiSelect = false;
            dayListDgv.Name = "dayListDgv";
            dayListDgv.ReadOnly = true;
            dayListDgv.RowHeadersVisible = false;
            dayListDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dayListDgv.Size = new Size(335, 157);
            dayListDgv.TabIndex = 0;
            dayListDgv.DataBindingComplete += dataBindingComplete;
            // 
            // addBtn
            // 
            addBtn.Location = new Point(12, 31);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(75, 23);
            addBtn.TabIndex = 1;
            addBtn.Text = "Add";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // editBtn
            // 
            editBtn.Location = new Point(93, 31);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(75, 23);
            editBtn.TabIndex = 2;
            editBtn.Text = "Edit";
            editBtn.UseVisualStyleBackColor = true;
            editBtn.Click += editBtn_Click;
            // 
            // deleteBtn
            // 
            deleteBtn.Location = new Point(174, 31);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(75, 23);
            deleteBtn.TabIndex = 3;
            deleteBtn.Text = "Delete";
            deleteBtn.UseVisualStyleBackColor = true;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // closeBtn
            // 
            closeBtn.BackColor = SystemColors.Window;
            closeBtn.Location = new Point(272, 31);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(75, 23);
            closeBtn.TabIndex = 4;
            closeBtn.Text = "Close";
            closeBtn.UseVisualStyleBackColor = false;
            closeBtn.Click += closeBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(258, 9);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 5;
            label1.Text = "Applications:";
            // 
            // numApplicationsLabel
            // 
            numApplicationsLabel.AutoSize = true;
            numApplicationsLabel.Location = new Point(331, 9);
            numApplicationsLabel.Name = "numApplicationsLabel";
            numApplicationsLabel.Size = new Size(13, 15);
            numApplicationsLabel.TabIndex = 6;
            numApplicationsLabel.Text = "0";
            // 
            // DayView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(359, 229);
            Controls.Add(numApplicationsLabel);
            Controls.Add(label1);
            Controls.Add(closeBtn);
            Controls.Add(deleteBtn);
            Controls.Add(editBtn);
            Controls.Add(addBtn);
            Controls.Add(dayListDgv);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DayView";
            Text = "Day View";
            ((System.ComponentModel.ISupportInitialize)dayListDgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dayListDgv;
        private Button addBtn;
        private Button editBtn;
        private Button deleteBtn;
        private Button closeBtn;
        private Label label1;
        private Label numApplicationsLabel;
    }
}