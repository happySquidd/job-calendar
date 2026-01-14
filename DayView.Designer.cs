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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
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
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(93, 12);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 2;
            button2.Text = "Edit";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(174, 12);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 3;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(272, 12);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 4;
            button4.Text = "Close";
            button4.UseVisualStyleBackColor = true;
            // 
            // DayView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(359, 210);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dayListDgv);
            Name = "DayView";
            Text = "Day View";
            ((System.ComponentModel.ISupportInitialize)dayListDgv).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dayListDgv;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}