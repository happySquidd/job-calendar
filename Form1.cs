namespace job_calendar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            MakeTheCalendar();
        }

        private void MakeTheCalendar()
        {
            monthLabel.Text = DateTime.Now.ToString("MMMM");
            // days of the week
            for (int i = 0; i < 7; i++)
            {
                Label dayName = new Label();
                dayName.Text = Enum.GetName(typeof(DayOfWeek), i)[..3];
                dayName.Width = 50;
                dayName.Height = 20;
                dayName.TextAlign = ContentAlignment.MiddleCenter;
                CalendarFlowPanel.Controls.Add(dayName);
            }
            // days in month
            int daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            for (int i = 1; i <= daysInMonth; i++)
            {
                Button dayButton = new Button();
                dayButton.Text = i.ToString();
                dayButton.Width = 50;
                dayButton.Height = 50;
                CalendarFlowPanel.Controls.Add(dayButton);
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            CalendarFlowPanel.Controls.Clear();
        }

        private void previousBtn_Click(object sender, EventArgs e)
        {
            CalendarFlowPanel.Controls.Clear();
        }
    }
}
