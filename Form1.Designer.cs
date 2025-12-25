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
            SuspendLayout();
            // 
            // CalendarFlowPanel
            // 
            CalendarFlowPanel.Location = new Point(12, 92);
            CalendarFlowPanel.Name = "CalendarFlowPanel";
            CalendarFlowPanel.Size = new Size(395, 344);
            CalendarFlowPanel.TabIndex = 0;
            // 
            // monthLabel
            // 
            monthLabel.AutoSize = true;
            monthLabel.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            monthLabel.Location = new Point(165, 61);
            monthLabel.Name = "monthLabel";
            monthLabel.Size = new Size(61, 23);
            monthLabel.TabIndex = 1;
            monthLabel.Text = "month";
            // 
            // nextBtn
            // 
            nextBtn.Location = new Point(332, 63);
            nextBtn.Name = "nextBtn";
            nextBtn.Size = new Size(75, 23);
            nextBtn.TabIndex = 2;
            nextBtn.Text = "next";
            nextBtn.UseVisualStyleBackColor = true;
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(419, 448);
            Controls.Add(previousBtn);
            Controls.Add(nextBtn);
            Controls.Add(monthLabel);
            Controls.Add(CalendarFlowPanel);
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
    }
}
