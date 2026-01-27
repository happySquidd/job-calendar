using job_calendar.database;
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
    public partial class AddEntry : Form
    {
        public DateTime thisDate;
        public bool positionFilled = false;
        public bool companyFilled = false;
        public bool payFilled = true;
        public bool websiteFilled = false;

        public AddEntry(DateTime date)
        {
            InitializeComponent();

            thisDate = date;
            addBtn.Enabled = false;
        }

        private void positionBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(positionBox.Text))
            {
                positionFilled = true;
            }
            else
            {
                positionFilled = false;
            }
            CheckSubmit();
        }

        private void companyBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(companyBox.Text))
            {
                companyFilled = true;
            }
            else
            {
                companyFilled = false;
            }
            CheckSubmit();
        }

        private void payBox_ValueChanged(object sender, EventArgs e)
        {
            if (payBox.Value >= 0)
            {
                payFilled = true;
            }
            else
            {
                payFilled = false;
            }
            CheckSubmit();
        }

        private void websiteBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(websiteBox.Text))
            {
                websiteFilled = true;
            }
            else
            {
                websiteFilled = false;
            }
            CheckSubmit();
        }

        public void CheckSubmit()
        {
            if (positionFilled && companyFilled && payFilled && websiteFilled)
            {
                addBtn.Enabled = true;
            }
            else
            {
                addBtn.Enabled = false;
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            Database.AddEntry(thisDate, positionBox.Text, companyBox.Text, (int)payBox.Value, websiteBox.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
