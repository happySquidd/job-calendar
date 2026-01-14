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
    public partial class EditEntry : Form
    {
        public int thisId;
        public bool positionFilled = true;
        public bool companyFilled = true;
        public bool payFilled = true;
        public bool websiteFilled = true;

        public EditEntry(Applicationz applicationData)
        {
            InitializeComponent();

            confirmBtn.Enabled = false;
            thisId = applicationData.Id;
            positionBox.Text = applicationData.Position;
            companyBox.Text = applicationData.Company;
            payBox.Value = applicationData.Pay;
            websiteBox.Text = applicationData.Website;
        }

        private void positionBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(positionBox.Text))
            {
                positionFilled = true;
                CheckSubmit();
            }
            else
            {
                positionFilled = false;
                confirmBtn.Enabled = false;
            }
        }

        private void companyBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(companyBox.Text))
            {
                companyFilled = true;
                CheckSubmit();
            }
            else
            {
                companyFilled = false;
                confirmBtn.Enabled = false;
            }
        }

        private void payBox_ValueChanged(object sender, EventArgs e)
        {
            if (payBox.Value > 0)
            {
                payFilled = true;
                CheckSubmit();
            }
            else
            {
                payFilled = false;
                confirmBtn.Enabled = false;
            }
        }

        private void websiteBox_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(websiteBox.Text))
            {
                websiteFilled = true;
                CheckSubmit();
            }
            else
            {
                websiteFilled = false;
                confirmBtn.Enabled = false;
            }
        }

        public void CheckSubmit()
        {
            if (positionFilled && companyFilled && payFilled && websiteFilled)
            {
                confirmBtn.Enabled = true;
            }
            else
            {
                confirmBtn.Enabled = false;
            }
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            Database.EditEntry(thisId, positionBox.Text, companyBox.Text, (int)payBox.Value, websiteBox.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
