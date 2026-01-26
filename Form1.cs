using job_calendar.database;
using job_calendar.model;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace job_calendar
{
    public partial class Form1 : Form
    {
        public Dictionary<string, int> heatMap = new Dictionary<string, int>();
        public int monthCounter = 0;
        public DateTime today = DateTime.Now;

        public Form1()
        {
            InitializeComponent();

            MakeTheCalendar(today);
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

            // get heatmap data
            DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            DateTime lastDayOfMonth = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
            heatMap = Database.LoadMonthHeatmap(firstDayOfMonth, lastDayOfMonth);
            numOfApplications.Text = CountHeatMap(heatMap).ToString();

            // days in month
            int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
            for (int i = 1; i <= daysInMonth; i++)
            {
                // fill empty cells before the first day to align days correctly
                if (i == 1)
                {
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
                DateTime buttonDay = new DateTime(date.Year, date.Month, i);
                dayButton.BackColor = Color.White;

                // see if date is in database and color it accordingly
                string dateKey = buttonDay.ToString("yyyy-MM-dd");
                if (heatMap.TryGetValue(dateKey, out int entries))
                {
                    dayButton.BackColor = MakeGreen(entries);
                }
                dayButton.Click += ViewDay;
                dayButton.Text = i.ToString();
                dayButton.Name = i.ToString();
                dayButton.Width = 50;
                dayButton.Height = 50;
                dayButton.FlatStyle = FlatStyle.Flat;
                // tag to know the date
                dayButton.Tag = buttonDay;
                CalendarFlowPanel.Controls.Add(dayButton);
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            CalendarFlowPanel.Controls.Clear();
            monthCounter++;
            MakeTheCalendar(DateTime.Now.AddMonths(monthCounter));
        }

        private void previousBtn_Click(object sender, EventArgs e)
        {
            CalendarFlowPanel.Controls.Clear();
            monthCounter--;
            MakeTheCalendar(DateTime.Now.AddMonths(monthCounter));
        }

        private void ViewDay(object sender, EventArgs e)
        {
            // load the day view form with the date
            Button button = sender as Button;
            DateTime btnDate = (DateTime)button.Tag;
            DayView dayView = new DayView(btnDate);
            dayView.StartPosition = FormStartPosition.CenterParent;
            // compare old entries to new to update the applications count
            int oldEntries = Database.GetDayEntries(btnDate);
            dayView.ShowDialog(this);

            // update the back color
            int entries = Database.GetDayEntries(btnDate);
            button.BackColor = MakeGreen(entries);

            // update count from the difference
            int difference = entries - oldEntries;
            UpdateApplicationCount(difference);
        }

        private static Color MakeGreen(int number)
        {
            switch (number)
            {
                case 1:
                    return Color.FromArgb(204, 255, 204);
                case 2:
                    return Color.FromArgb(153, 255, 153);
                case 3:
                    return Color.FromArgb(102, 255, 102);
                case 4:
                    return Color.FromArgb(51, 255, 51);
                case 5:
                    return Color.FromArgb(0, 255, 0);
                case >= 6:
                    return Color.FromArgb(0, 204, 0);
                default:
                    return Color.White;
            }
        }

        private int CountHeatMap(Dictionary<string, int> heatMap)
        {
            int total = 0;
            foreach (int v in heatMap.Values)
            {
                total += v;
            }
            return total;
        }

        private void UpdateApplicationCount(int difference)
        {
            int allApps = Int32.Parse(numOfApplications.Text);
            int newApps = allApps + difference;
            numOfApplications.Text = newApps.ToString();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            AddEntry addEntry = new AddEntry(today);
            addEntry.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = addEntry.ShowDialog(this);

            // if entry is added, color it
            if (result == DialogResult.OK)
            {
                int entries = Database.GetDayEntries(today);
                var button = CalendarFlowPanel.Controls.Find(today.Day.ToString(), false);
                button[0].BackColor = MakeGreen(entries);
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
