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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace job_calendar
{
    public partial class DayView : Form
    {
        public BindingList<Applicationz> applications = new BindingList<Applicationz>();
        public DateTime thisDate;

        public DayView(DateTime date)
        {
            InitializeComponent();

            // visual style
            dayListDgv.EnableHeadersVisualStyles = false;
            dayListDgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = dayListDgv.ColumnHeadersDefaultCellStyle.BackColor;
            
            thisDate = date;
            LoadDgv();
        }

        private void LoadDgv()
        {
            // load the data with the list of applications
            applications = Database.GetApplications(thisDate);
            dayListDgv.DataSource = applications;
            dayListDgv.Columns["Id"].Visible = false;
            numApplicationsLabel.Text = applications.Count.ToString();
        }

        private void dataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dayListDgv.ClearSelection();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddEntry addEntry = new AddEntry(thisDate);
            addEntry.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = addEntry.ShowDialog(this);

            // if added entry
            if (result == DialogResult.OK)
            {
                LoadDgv();
            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (dayListDgv.CurrentRow == null || !dayListDgv.CurrentRow.Selected)
            {
                return;
            }

            Applicationz selected = dayListDgv.CurrentRow.DataBoundItem as Applicationz;
            EditEntry editEntry = new EditEntry(selected);
            editEntry.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = editEntry.ShowDialog(this);

            if (result == DialogResult.OK)
            {
                LoadDgv();
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            // validation
            if (dayListDgv.CurrentRow == null || !dayListDgv.CurrentRow.Selected)
            {
                return;
            }
            DialogResult answer = MessageBox.Show(text: "Delete the selected item?", caption: "Confirm", buttons: MessageBoxButtons.YesNo);
            if (answer == DialogResult.No)
            {
                return;
            }

            Applicationz selected = dayListDgv.CurrentRow.DataBoundItem as Applicationz;
            Database.DeleteEntry(selected.Id);
            applications.Remove(selected);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
