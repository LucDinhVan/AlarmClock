using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        private DateTime alarmTime;
        private NotifyIcon notifyIcon;
        

        public MainForm()
        {
            InitializeComponent();

            // Create the NotifyIcon control with an icon and a context menu
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = new Icon("app_icon.ico");
            notifyIcon.Visible = true;

            ContextMenuStrip contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Show", null, (s, e) => this.Show());
            contextMenu.Items.Add("Exit", null, (s, e) => Application.Exit());
            notifyIcon.ContextMenuStrip = contextMenu;
        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    // Update the time label every second
        //    labelTime.Text = DateTime.Now.ToString("HH:mm:ss");

        //    // Check if the current time matches the alarm time
        //    if (DateTime.Now >= alarmTime)
        //    {
        //        // Play a sound and show a message box
        //        //SoundPlayer player = new SoundPlayer(Properties.Resources.alarm_sound);
        //        //player.Play();
        //        MessageBox.Show("Alarm!");
        //    }
        //}

        private void buttonSetAlarm_Click(object sender, EventArgs e)
        {
            // Parse the user input and set the alarm time
            int hours = (int)numericUpDownHours.Value;
            int minutes = (int)numericUpDownMinutes.Value;
            int seconds = (int)numericUpDownSeconds.Value;
            alarmTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hours, minutes, seconds);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Hide the form and move it to the system tray instead of closing it
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
                notifyIcon.ShowBalloonTip(1000, "Clock Alarm", "The app is running in the background.", ToolTipIcon.Info);
            }
            else
            {
                base.OnFormClosing(e);
            }
        }
    }
}
