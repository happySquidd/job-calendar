namespace job_calendar
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            CalendarFlowPanel = new FlowLayoutPanel();
            monthLabel = new Label();
            nextBtn = new Button();
            previousBtn = new Button();
            yearLabel = new Label();
            closeBtn = new Button();
            label1 = new Label();
            numOfApplications = new Label();
            searchBtn = new Button();
            addBtn = new Button();
            viewAllBtn = new Button();
            SuspendLayout();
            // 
            // CalendarFlowPanel
            // 
            CalendarFlowPanel.Location = new Point(12, 92);
            CalendarFlowPanel.Name = "CalendarFlowPanel";
            CalendarFlowPanel.Size = new Size(395, 362);
            CalendarFlowPanel.TabIndex = 0;
            // 
            // monthLabel
            // 
            monthLabel.AutoSize = true;
            monthLabel.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            monthLabel.Location = new Point(177, 61);
            monthLabel.Name = "monthLabel";
            monthLabel.Size = new Size(61, 23);
            monthLabel.TabIndex = 1;
            monthLabel.Text = "month";
            // 
            // nextBtn
            // 
            nextBtn.BackColor = SystemColors.Window;
            nextBtn.Location = new Point(332, 63);
            nextBtn.Name = "nextBtn";
            nextBtn.Size = new Size(75, 23);
            nextBtn.TabIndex = 2;
            nextBtn.Text = "next";
            nextBtn.UseVisualStyleBackColor = false;
            nextBtn.Click += nextBtn_Click;
            // 
            // previousBtn
            // 
            previousBtn.Location = new Point(12, 63);
            previousBtn.Name = "previousBtn";
            previousBtn.Size = new Size(75, 23);
            previousBtn.TabIndex = 3;
            previousBtn.Text = "previous";
            previousBtn.UseVisualStyleBackColor = true;
            previousBtn.Click += previousBtn_Click;
            // 
            // yearLabel
            // 
            yearLabel.AutoSize = true;
            yearLabel.Location = new Point(14, 6);
            yearLabel.Name = "yearLabel";
            yearLabel.Size = new Size(29, 15);
            yearLabel.TabIndex = 4;
            yearLabel.Text = "year";
            // 
            // closeBtn
            // 
            closeBtn.Location = new Point(332, 454);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(75, 23);
            closeBtn.TabIndex = 5;
            closeBtn.Text = "Close";
            closeBtn.UseVisualStyleBackColor = true;
            closeBtn.Click += closeBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(302, 6);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 6;
            label1.Text = "Applications:";
            // 
            // numOfApplications
            // 
            numOfApplications.AutoSize = true;
            numOfApplications.Location = new Point(377, 6);
            numOfApplications.Name = "numOfApplications";
            numOfApplications.Size = new Size(32, 15);
            numOfApplications.TabIndex = 7;
            numOfApplications.Text = "num";
            // 
            // searchBtn
            // 
            searchBtn.Location = new Point(93, 454);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(75, 23);
            searchBtn.TabIndex = 8;
            searchBtn.Text = "Search";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // addBtn
            // 
            addBtn.BackColor = Color.FromArgb(192, 255, 192);
            addBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addBtn.Location = new Point(12, 454);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(75, 23);
            addBtn.TabIndex = 9;
            addBtn.Text = "Add";
            addBtn.UseVisualStyleBackColor = false;
            addBtn.Click += addBtn_Click;
            // 
            // viewAllBtn
            // 
            viewAllBtn.Location = new Point(174, 454);
            viewAllBtn.Name = "viewAllBtn";
            viewAllBtn.Size = new Size(75, 23);
            viewAllBtn.TabIndex = 10;
            viewAllBtn.Text = "View All";
            viewAllBtn.UseVisualStyleBackColor = true;
            viewAllBtn.Click += viewAllBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(419, 489);
            Controls.Add(viewAllBtn);
            Controls.Add(addBtn);
            Controls.Add(searchBtn);
            Controls.Add(numOfApplications);
            Controls.Add(label1);
            Controls.Add(closeBtn);
            Controls.Add(yearLabel);
            Controls.Add(previousBtn);
            Controls.Add(nextBtn);
            Controls.Add(monthLabel);
            Controls.Add(CalendarFlowPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Joble";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel CalendarFlowPanel;
        private Label monthLabel;
        private Button nextBtn;
        private Button previousBtn;
        private Label yearLabel;
        private Button closeBtn;
        private Label label1;
        private Label numOfApplications;
        private Button searchBtn;
        private Button addBtn;
        private Button viewAllBtn;
    }
}
