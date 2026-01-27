namespace job_calendar
{
    partial class AllView
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
            viewAllDgv = new DataGridView();
            searchBtn = new Button();
            closeBtn = new Button();
            searchBox = new TextBox();
            clearBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)viewAllDgv).BeginInit();
            SuspendLayout();
            // 
            // viewAllDgv
            // 
            viewAllDgv.AllowUserToAddRows = false;
            viewAllDgv.AllowUserToDeleteRows = false;
            viewAllDgv.AllowUserToResizeRows = false;
            viewAllDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            viewAllDgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            viewAllDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            viewAllDgv.Location = new Point(12, 45);
            viewAllDgv.Name = "viewAllDgv";
            viewAllDgv.ReadOnly = true;
            viewAllDgv.RowHeadersVisible = false;
            viewAllDgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            viewAllDgv.ShowCellToolTips = false;
            viewAllDgv.Size = new Size(445, 232);
            viewAllDgv.TabIndex = 4;
            viewAllDgv.CellDoubleClick += viewAllDgv_CellDoubleClick;
            viewAllDgv.DataBindingComplete += viewAllDgv_DataBindingComplete;
            // 
            // searchBtn
            // 
            searchBtn.Location = new Point(147, 17);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(75, 23);
            searchBtn.TabIndex = 2;
            searchBtn.Text = "Search";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // closeBtn
            // 
            closeBtn.Location = new Point(382, 16);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(75, 23);
            closeBtn.TabIndex = 0;
            closeBtn.Text = "Close";
            closeBtn.UseVisualStyleBackColor = true;
            closeBtn.Click += closeBtn_Click;
            // 
            // searchBox
            // 
            searchBox.Location = new Point(12, 17);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(129, 23);
            searchBox.TabIndex = 1;
            // 
            // clearBtn
            // 
            clearBtn.Location = new Point(228, 16);
            clearBtn.Name = "clearBtn";
            clearBtn.Size = new Size(75, 23);
            clearBtn.TabIndex = 3;
            clearBtn.Text = "Clear";
            clearBtn.UseVisualStyleBackColor = true;
            clearBtn.Click += clearBtn_Click;
            // 
            // AllView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(469, 291);
            Controls.Add(clearBtn);
            Controls.Add(searchBox);
            Controls.Add(closeBtn);
            Controls.Add(searchBtn);
            Controls.Add(viewAllDgv);
            Name = "AllView";
            Text = "View All";
            ((System.ComponentModel.ISupportInitialize)viewAllDgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView viewAllDgv;
        private Button searchBtn;
        private Button closeBtn;
        private TextBox searchBox;
        private Button clearBtn;
    }
}