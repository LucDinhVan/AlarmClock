using System.Runtime.InteropServices;
using System.Timers;
using Timer = System.Timers.Timer;

namespace ClockAlarmConsoleApp
{
    class Program
    {
        //private static NotifyIcon notifyIcon;

        static void Main(string[] args)
        {
            // Create a timer to update the time display every second
            Timer timer = new Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            Console.ReadLine();

            // Create the system tray icon and handle the Console.CancelKeyPress event
            //notifyIcon = new NotifyIcon();
            //notifyIcon.Icon = new Icon("app_icon.ico");
            //notifyIcon.Visible = true;

            // Create a context menu with a "Show" menu item
            //ContextMenuStrip contextMenu = new ContextMenuStrip();
            //contextMenu.Items.Add("Show", null, (s, e) => ShowConsoleWindow());
            //contextMenu.Items.Add("Exit", null, (s, e) => Application.Exit());
            //notifyIcon.ContextMenuStrip = contextMenu;

            Console.CancelKeyPress += Console_CancelKeyPress;

            // Wait for user input or a system event to exit the app
            Console.WriteLine("Press CTRL+C to exit...");
            while (true)
            {
                // Do nothing, just wait for user input or a system event
            }
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Update the time display every second
            Console.WriteLine(DateTime.Now.ToString("HH:mm:ss"));

            // Check if the current time matches the alarm time
            int hours = 8; // Example alarm time
            int minutes = 0;
            int seconds = 0;
            if (DateTime.Now.Hour == hours && DateTime.Now.Minute == minutes && DateTime.Now.Second == seconds)
            {
                // Play a sound or perform any other action
                Console.WriteLine("Alarm!");
                //SystemSounds.Asterisk.Play();
            }
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            // Cancel the exit event and hide the console window
            e.Cancel = true;
            Console.WriteLine("Hiding console window...");
            HideConsoleWindow();

            // Show the system tray icon
            //notifyIcon.ShowBalloonTip(1000, "Clock Alarm", "The app is running in the background.", ToolTipIcon.Info);
        }

        private static void ShowConsoleWindow()
        {
            // Show the console window
            ShowWindow(GetConsoleWindow(), SW_SHOW);
        }

        private static void HideConsoleWindow()
        {
            // Hide the console window
            ShowWindow(GetConsoleWindow(), SW_HIDE);
        }

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;
    }
}