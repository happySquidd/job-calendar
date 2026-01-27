using job_calendar.database;
using job_calendar.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace job_calendar
{
    public partial class AllView : Form
    {
        BindingList<Applicationz> allApplications = new BindingList<Applicationz>();

        public AllView()
        {
            InitializeComponent();

            viewAllDgv.EnableHeadersVisualStyles = false;
            viewAllDgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = viewAllDgv.ColumnHeadersDefaultCellStyle.BackColor;

            searchBox.PlaceholderText = "Company name";

            LoadDgv();
        }

        private void LoadDgv()
        {
            allApplications = Database.GetApplications();
            viewAllDgv.DataSource = allApplications;
            viewAllDgv.Columns["Id"].HeaderText = "#";
            viewAllDgv.Columns["Id"].FillWeight = 30;
            viewAllDgv.Columns["Date"].FillWeight = 60;
            viewAllDgv.Columns["Pay"].FillWeight = 35;

            // overwrite the id value to the number of the item relative to the list
            int newId = 1;
            foreach (Applicationz application in allApplications)
            {
                application.Id = newId;
                newId++;
            }
        }

        private void viewAllDgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // copy the website link on double click
            if (e.RowIndex >= 0)
            {
                var cellString = viewAllDgv.Rows[e.RowIndex].Cells["Website"].Value;
                Clipboard.SetText(cellString.ToString());

                // display a tooltip to show that it copied
                Point mouse = viewAllDgv.PointToClient(Cursor.Position);
                ToolTip toolTip = new ToolTip();
                toolTip.Show("Copied!", viewAllDgv, mouse.X + 10, mouse.Y, 700);
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
