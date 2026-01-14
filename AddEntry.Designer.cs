namespace job_calendar
{
    partial class AddEntry
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            positionBox = new TextBox();
            companyBox = new TextBox();
            payBox = new NumericUpDown();
            websiteBox = new TextBox();
            addBtn = new Button();
            cancelBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)payBox).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(132, 21);
            label1.TabIndex = 0;
            label1.Text = "Add application";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(41, 61);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 1;
            label2.Text = "Position";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(65, 130);
            label3.Name = "label3";
            label3.Size = new Size(26, 15);
            label3.TabIndex = 2;
            label3.Text = "Pay";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 96);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 3;
            label4.Text = "Company";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(42, 166);
            label5.Name = "label5";
            label5.Size = new Size(49, 15);
            label5.TabIndex = 4;
            label5.Text = "Website";
            // 
            // positionBox
            // 
            positionBox.Location = new Point(97, 58);
            positionBox.Name = "positionBox";
            positionBox.Size = new Size(167, 23);
            positionBox.TabIndex = 5;
            positionBox.TextChanged += positionBox_TextChanged;
            // 
            // companyBox
            // 
            companyBox.Location = new Point(97, 93);
            companyBox.Name = "companyBox";
            companyBox.Size = new Size(167, 23);
            companyBox.TabIndex = 6;
            companyBox.TextChanged += companyBox_TextChanged;
            // 
            // payBox
            // 
            payBox.Location = new Point(97, 128);
            payBox.Name = "payBox";
            payBox.Size = new Size(57, 23);
            payBox.TabIndex = 8;
            payBox.ValueChanged += payBox_ValueChanged;
            // 
            // websiteBox
            // 
            websiteBox.Location = new Point(97, 163);
            websiteBox.Name = "websiteBox";
            websiteBox.Size = new Size(167, 23);
            websiteBox.TabIndex = 9;
            websiteBox.TextChanged += websiteBox_TextChanged;
            // 
            // addBtn
            // 
            addBtn.Location = new Point(125, 215);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(75, 23);
            addBtn.TabIndex = 10;
            addBtn.Text = "Add";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += addBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(206, 215);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(75, 23);
            cancelBtn.TabIndex = 11;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // AddEntry
            // 
            AcceptButton = addBtn;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelBtn;
            ClientSize = new Size(293, 250);
            Controls.Add(cancelBtn);
            Controls.Add(addBtn);
            Controls.Add(websiteBox);
            Controls.Add(payBox);
            Controls.Add(companyBox);
            Controls.Add(positionBox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddEntry";
            Text = "Add";
            ((System.ComponentModel.ISupportInitialize)payBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox positionBox;
        private TextBox companyBox;
        private NumericUpDown payBox;
        private TextBox websiteBox;
        private Button addBtn;
        private Button cancelBtn;
    }
}