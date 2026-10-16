using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace MeetingScheduler
{
    public partial class MainForm : Form
    {
        private readonly string[] timeZones = { "Pacific Standard Time", "Eastern Standard Time", "Central European Standard Time", "India Standard Time" };

        public MainForm()
        {
            InitializeComponent();
            this.BackColor = System.Drawing.Color.LightSkyBlue;

            // Setup ComboBox
            timeZoneComboBox.Items.AddRange(timeZones);
            timeZoneComboBox.SelectedIndex = 0; // Default selection
        }

        private void buttonSchedule_Click(object sender, EventArgs e)
        {
            DateTime selectedDateTime = dateTimePicker.Value;
            TimeZoneInfo selectedTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneComboBox.SelectedItem.ToString());

            // Convert the selected time to UTC
            DateTime utcTime = TimeZoneInfo.ConvertTimeToUtc(selectedDateTime, selectedTimeZone);

            // Check for the meeting time limit (20:00 local time)
            bool isValid = CheckMeetingTime(utcTime);

            if (isValid)
            {
                MessageBox.Show("Meeting scheduled successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Cannot schedule a meeting after 20:00 in selected time zone!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckMeetingTime(DateTime utcTime)
        {
            foreach (var timeZone in timeZones)
            {
                TimeZoneInfo tzInfo = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
                DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzInfo);
                
                // Check if the time is after 20:00
                if (localTime.Hour >= 20)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
