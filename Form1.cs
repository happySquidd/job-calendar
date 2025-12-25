namespace job_calendar
{
    public partial class Form1 : Form
    {
        public int counter = 0;
        public Form1()
        {
            InitializeComponent();

            DateTime Date = DateTime.Now;
            MakeTheCalendar(Date);
        }

        private void MakeTheCalendar(DateTime date)
        {
            monthLabel.Text = date.ToString("MMMM");
            yearLabel.Text = date.ToString("yyyy");
            // name for days of week
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
            int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            for (int i = 1; i <= daysInMonth; i++)
            {
                // fill empty cells before the first day to align days correctly
                if (i == 1)
                {
                    DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
                    int dayOfWeek = firstDayOfMonth.DayOfWeek switch
                    {
                        DayOfWeek.Sunday => 0,
                        DayOfWeek.Monday => 1,
                        DayOfWeek.Tuesday => 2,
                        DayOfWeek.Wednesday => 3,
                        DayOfWeek.Thursday => 4,
                        DayOfWeek.Friday => 5,
                        DayOfWeek.Saturday => 6,
                        _ => 0,
                    };
                    for (int j = 0; j < dayOfWeek; j++)
                    {
                        Label emptyCell = new Label();
                        emptyCell.Width = 50;
                        emptyCell.Height = 50;
                        emptyCell.Text = "";
                        CalendarFlowPanel.Controls.Add(emptyCell);
                    }
                }

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
            counter++;
            MakeTheCalendar(DateTime.Now.AddMonths(counter));
        }

        private void previousBtn_Click(object sender, EventArgs e)
        {
            CalendarFlowPanel.Controls.Clear();
            counter--;
            MakeTheCalendar(DateTime.Now.AddMonths(counter));
        }
    }
}
