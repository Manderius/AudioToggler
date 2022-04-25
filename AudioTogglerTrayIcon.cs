namespace AudioToggler
{
    internal class AudioTogglerTrayIcon : ApplicationContext
    {
        private NotifyIcon trayIcon;
        private Icon iconHigh = new Icon("resources/speakerHigh.ico");
        private Icon iconLow = new Icon("resources/speakerLow.ico");

        public AudioTogglerTrayIcon()
        {
            // Initialize Tray Icon
            trayIcon = new NotifyIcon();

            trayIcon.DoubleClick += Toggle;
            trayIcon.MouseClick += Exit;

            SetTrayIconForLevel(AudioManipulation.GetAudioLevel());

            trayIcon.Visible = true;
        }

        void Toggle(object? sender, EventArgs e)
        {
            AudioLevel level = AudioManipulation.ToggleAudio();
            SetTrayIconForLevel(level);
        }

        void SetTrayIconForLevel(AudioLevel level)
        {
            var icon = level == AudioLevel.HIGH ? iconHigh : iconLow;
            trayIcon.Icon = icon;
        }

        void Exit(object? sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button != MouseButtons.Right) return;

            // Hide tray icon, otherwise it will remain shown until user mouses over it
            trayIcon.Visible = false;

            Application.Exit();
        }
    }
}
