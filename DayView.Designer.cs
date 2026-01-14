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
            dayListDgv.Location = new Point(12, 41);
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
            addBtn.Location = new Point(12, 12);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(75, 23);
            addBtn.TabIndex = 1;
            addBtn.Text = "Add";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // editBtn
            // 
            editBtn.Location = new Point(93, 12);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(75, 23);
            editBtn.TabIndex = 2;
            editBtn.Text = "Edit";
            editBtn.UseVisualStyleBackColor = true;
            editBtn.Click += editBtn_Click;
            // 
            // deleteBtn
            // 
            deleteBtn.Location = new Point(174, 12);
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
            closeBtn.Location = new Point(272, 12);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(75, 23);
            closeBtn.TabIndex = 4;
            closeBtn.Text = "Close";
            closeBtn.UseVisualStyleBackColor = false;
            closeBtn.Click += closeBtn_Click;
            // 
            // DayView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(359, 210);
            Controls.Add(closeBtn);
            Controls.Add(deleteBtn);
            Controls.Add(editBtn);
            Controls.Add(addBtn);
            Controls.Add(dayListDgv);
            Name = "DayView";
            Text = "Day View";
            ((System.ComponentModel.ISupportInitialize)dayListDgv).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dayListDgv;
        private Button addBtn;
        private Button editBtn;
        private Button deleteBtn;
        private Button closeBtn;
    }
}