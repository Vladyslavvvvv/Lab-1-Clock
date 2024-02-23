using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab_1_Clock
{
    public partial class Clock : Form
    {
        private Time currentTime;
        private Timer timer;

        public Clock()
        {
            InitializeComponent();

            currentTime = new Time();
            UpdateTimeLabels();

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            currentTime.AddSeconds(1);
            UpdateTimeLabels();
        }

        private void UpdateTimeLabels()
        {
            labelHour.Text = $"{currentTime.Hours:D2}";
            labelMinute.Text = $"{currentTime.Minutes:D2}";
            labelSecond.Text = $"{currentTime.Seconds:D2}";
        }

        private void buttonSetTime_Click(object sender, EventArgs e)
        {
            currentTime.SetTime(int.Parse(textBoxHour.Text), int.Parse(textBoxMinute.Text), int.Parse(textBoxSecond.Text));
            UpdateTimeLabels();
        }
    }

    class Time
    {
        private int hours;
        private int minutes;
        private int seconds;

        public int Hours
        {
            get { return hours; }
            set
            {
                if (value >= 0 && value < 24)
                    hours = value;
                else
                    MessageBox.Show("Invalid hour value");
            }
        }

        public int Minutes
        {
            get { return minutes; }
            set
            {
                if (value >= 0 && value < 60)
                    minutes = value;
                else
                    MessageBox.Show("Invalid minute value");
            }
        }

        public int Seconds
        {
            get { return seconds; }
            set
            {
                if (value >= 0 && value < 60)
                    seconds = value;
                else
                    MessageBox.Show("Invalid second value");
            }
        }

        public void SetTime(int hours, int minutes, int seconds)
        {
            Hours = hours;
            Minutes = minutes;
            Seconds = seconds;
        }

        public void AddSeconds(int seconds)
        {
            Seconds += seconds;
        }
    }
}