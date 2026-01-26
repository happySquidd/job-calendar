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
            // if user decides to backfill, prompt three questions to discourage backfilling
            // question 1
            var question1 = MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo);
            if (question1 == DialogResult.No)
            {
                return;
            }
            // question 2
            var rand = new Random();
            int variable_x = rand.Next(100);
            int variable_y = rand.Next(100);
            int answer = variable_x - variable_y;
            int fake_answer_1 = rand.Next(100);
            int fake_answer_2 = rand.Next(100);
            List<int> answers = new List<int>() { answer, fake_answer_1, fake_answer_2 };
            TaskDialogButtonCollection btns = new TaskDialogButtonCollection();
            for (int i = 0; i < 3; i++)
            {
                int idx = rand.Next(answers.Count);
                btns.Add(answers[idx].ToString());
                answers.RemoveAt(idx);
            }
            TaskDialogButton btn1 = new TaskDialogButton($"{answer}");
            TaskDialogButton btn2 = new TaskDialogButton($"{fake_answer_1}");
            TaskDialogButton btn3 = new TaskDialogButton($"{fake_answer_2}");
            TaskDialogPage question2 = new TaskDialogPage()
            {
                Caption = "Solve the equation",
                Text = $"Solve: {variable_x} - {variable_y} = ?",
                Buttons = btns
            };
            TaskDialogButton response = TaskDialog.ShowDialog(question2);
            if (Int32.Parse(response.Text) != answer)
            {
                MessageBox.Show("Incorrect!");
                return;
            }
            else
            {
                MessageBox.Show("Correct!");
            }
            // question 3
            var question3 = MessageBox.Show("To build a habit consider avoiding backfilling. Continue anyway?", "Confirm", MessageBoxButtons.YesNo);
            if (question3 == DialogResult.No)
            {
                return;
            }

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
