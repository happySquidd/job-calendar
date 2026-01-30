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

            //viewAllDgv.EnableHeadersVisualStyles = false;
            viewAllDgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = viewAllDgv.ColumnHeadersDefaultCellStyle.BackColor;

            searchBox.PlaceholderText = "Company name";

            allApplications = Database.GetApplications();
            LoadDgv();
        }

        private void viewAllDgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            viewAllDgv.ClearSelection();
        }

        private void LoadDgv()
        {
            // copy the list into a data table to allow sorting
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Date", typeof(string));
            dt.Columns.Add("Position", typeof(string));
            dt.Columns.Add("Company", typeof(string));
            dt.Columns.Add("Pay", typeof(int));
            dt.Columns.Add("Website", typeof(string));

            int newId = 1;
            foreach (Applicationz item in allApplications)
            {
                // overwrite the id value to the number of the item relative to the list
                item.Id = newId;
                newId++;

                dt.Rows.Add(item.Id, item.Date, item.Position, item.Company, item.Pay, item.Website);
            }
            viewAllDgv.DataSource = dt;

            viewAllDgv.Columns["Id"].HeaderText = "#";
            viewAllDgv.Columns["Id"].FillWeight = 30;
            viewAllDgv.Columns["Date"].FillWeight = 60;
            viewAllDgv.Columns["Pay"].FillWeight = 35;
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
            if (string.IsNullOrWhiteSpace(searchBox.Text))
            {
                return;
            }

            allApplications = Database.GetCompanyApplications(searchBox.Text);
            LoadDgv();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            allApplications = Database.GetApplications();
            LoadDgv();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void viewAllDgv_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewColumn selected = viewAllDgv.Columns[e.ColumnIndex];
            ListSortDirection direction = ListSortDirection.Ascending;

            if (selected.HeaderCell.SortGlyphDirection == SortOrder.Ascending)
            {
                direction = ListSortDirection.Descending;
            }


        }
    }
}
