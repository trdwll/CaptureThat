/*
 * Copyright (c) 2016-2019 Russ 'trdwll' Treadwell. All rights reserved.
 * Licensed under the MIT License. See LICENSE.md file in the project root for full license information.
 */
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using apollo.Core;
using apollo.Forms;

namespace CaptureThat
{
    public partial class MainForm : Form
    {
        // Get the RegistryKey to set data into (to make CaptureThat run on Windows start)
        RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

        // Create the UpdaterForm object to allow it to be accessable in the form multiple times
        UpdaterForm uf;

        private bool areaFormShowing = false;

        private static NotifyIcon notifyIcon;
        public static NotifyIcon Notify { get { return notifyIcon; } }

        // Create the hotkeys
        private HotKeys areaHotKey;
        private HotKeys windowHotKey;
        private HotKeys fullHotKey;

        public MainForm()
        {
            InitializeComponent();

            // Clean the update (deletes temporary files)
            Utilities.CleanUpdate(Application.StartupPath);

            // Check for updates
            uf = new UpdaterForm(true, Config.AppUpdateURL, Config.AssemblyVersion, true, true);
            uf.Show();

            // Check the config version
            if (new Config.C().ConfigVersion > Config.conf.ConfigVersion)
            {
                // Check if the user wants to update their config
                if (MessageBox.Show($"Your config is outdated, would you like to update your config?\nYour config version \"{Config.conf.ConfigVersion}\"\nNew config version \"{new Config.C().ConfigVersion}\"", "Update Config?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    File.Delete(Config.ConfigFile); // Delete the config
                    Application.Restart(); // Restart CaptureThat
                    Environment.Exit(0); // Exit CaptureThat
                }
            }

            // Check if form styling is enabled
            if (Config.conf.FormStyle.EnableStyling)
            {
                // Get the button color from the config
                Color btnColor = Color.FromName(Config.conf.FormStyle.ButtonColor);

                // Style the buttons
                btnCaptureArea.FlatStyle = FlatStyle.Flat;
                btnCaptureArea.FlatAppearance.BorderColor = btnColor;
                btnCaptureWindow.FlatStyle = FlatStyle.Flat;
                btnCaptureWindow.FlatAppearance.BorderColor = btnColor;
                btnCaptureFull.FlatStyle = FlatStyle.Flat;
                btnCaptureFull.FlatAppearance.BorderColor = btnColor;

                btnSettings.FlatStyle = FlatStyle.Flat;
                btnSettings.FlatAppearance.BorderColor = btnColor;
                btnAbout.FlatStyle = FlatStyle.Flat;
                btnAbout.FlatAppearance.BorderColor = btnColor;

                BackColor = Color.FromName(Config.conf.FormStyle.FormBackgroundColor);

                // Get all of the buttons
                foreach (Control control in Controls)
                {
                    if (control.GetType() == typeof(Button))
                    {
                        // Change the color to the color in the config
                        control.BackColor = Color.FromName(Config.conf.FormStyle.ButtonColor);
                    }
                }
            }

            // Set the title of the form to display the version and if it's portable mode
            Text += " v" + Config.AppVersion + (Config.mode.PortableMode ? " (PORTABLE)" : "");

            // Set notifyIcon to notifyIcon1 to be accessable in the project
            notifyIcon = notifyIcon1;

            // Set notifyIcon1 text
            notifyIcon1.Text = $"CaptureThat v{Config.AppVersion}";

            // Check if the user wants to minimize the form on startup
            if (Config.conf.MinimizeFormOnStartup)
            {
                WindowState = FormWindowState.Minimized; // Set the WindowState to Minimized
                ShowInTaskbar = false; // Disable showing the form in the taskbar
            }

            // Check if the user wants to force icons on the buttons
            if (Config.conf.ForceIconsOnButtons)
            {
                // Remove the text from all buttons
                btnCaptureArea.Text = "";
                btnCaptureWindow.Text = "";
                btnCaptureFull.Text = "";
                btnSettings.Text = "";
                btnAbout.Text = "";

                // Create the path for the icons
                string p = $@"{Application.StartupPath}\iconpacks\{Config.conf.IconPackName}";

                // Set the background image on the buttons
                btnCaptureArea.BackgroundImage = File.Exists($@"{p}\area.png") ? System.Drawing.Image.FromFile($@"{p}\area.png") : Properties.Resources.area_icon;
                btnCaptureWindow.BackgroundImage = File.Exists($@"{p}\window.png") ? System.Drawing.Image.FromFile($@"{p}\window.png") : Properties.Resources.window_icon;
                btnCaptureFull.BackgroundImage = File.Exists($@"{p}\full.png") ? System.Drawing.Image.FromFile($@"{p}\full.png") : Properties.Resources.full_icon;
                btnSettings.BackgroundImage = File.Exists($@"{p}\settings.png") ? System.Drawing.Image.FromFile($@"{p}\settings.png") : Properties.Resources.settings_icon;
                btnAbout.BackgroundImage = File.Exists($@"{p}\about.png") ? System.Drawing.Image.FromFile($@"{p}\about.png") : Properties.Resources.about_icon;

                // Set the layout for the background image on the buttons
                btnCaptureArea.BackgroundImageLayout = ImageLayout.Stretch;
                btnCaptureWindow.BackgroundImageLayout = ImageLayout.Stretch;
                btnCaptureFull.BackgroundImageLayout = ImageLayout.Stretch;
                btnSettings.BackgroundImageLayout = ImageLayout.Stretch;
                btnAbout.BackgroundImageLayout = ImageLayout.Stretch;
            }

            try
            {
                // Check if the user wants CaptureThat to run on Windows startup
                if (Config.conf.RunOnWindowsStartup)
                {
                    // Set the key CaptureThat to the Executable file (so CaptureThat runs on windows startup)
                    key.SetValue("CaptureThat", Application.ExecutablePath);
                }
                else if (!Config.conf.RunOnWindowsStartup)
                {
                    key.SetValue("CaptureThat", ""); // Set the key to null
                    key.DeleteValue("CaptureThat"); // Delete the key
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            // Create the context menu
            ContextMenu cm = new ContextMenu();
            MenuItem niOpen = cm.MenuItems.Add("Open CaptureThat");
            MenuItem niSettings = cm.MenuItems.Add("CaptureThat Settings");
            MenuItem niAbout = cm.MenuItems.Add("About CaptureThat");
            MenuItem niUpdate = cm.MenuItems.Add("Check for Updates");
            MenuItem niSpacer = cm.MenuItems.Add("-");
            MenuItem niExit = cm.MenuItems.Add("Exit CaptureThat");

            // Context menu event handlers
            niOpen.Click += NiOpen_Click;
            niSettings.Click += NiSettings_Click;
            niAbout.Click += NiAbout_Click;
            niUpdate.Click += NiUpdate_Click;
            niExit.Click += NiExit_Click;

            // Set the context menu to the notifyIcon1
            notifyIcon1.ContextMenu = cm;

            // Check if the AppSettingsPath exists
            if (!Directory.Exists(Config.AppSettingsPath))
            {
                // Create the AppSettingsPath directory
                Directory.CreateDirectory(Config.AppSettingsPath);
            }
        }

        /// <summary>
        /// Display the form (MainForm)
        /// </summary>
        private void ShowForm()
        {
            // Check if the form is visible
            if (Visible)
            {
                Hide(); // Hide the form
            }
            else
            {
                Show(); // Show the form
                WindowState = FormWindowState.Normal; // Set the WindowState to Normal
                ShowInTaskbar = true; // Show the form in the taskbar
            }
        }

        private void NiExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Exit the application
        }

        private void NiAbout_Click(object sender, EventArgs e)
        {
            AboutForm af = new AboutForm();
            af.ShowDialog();
        }

        private void NiUpdate_Click(object sender, EventArgs e)
        {
            uf = new UpdaterForm(false, Config.AppUpdateURL, Config.AssemblyVersion, true, true);

            uf.Show();
        }

        private void NiOpen_Click(object sender, EventArgs e)
        {
            ShowForm(); // Display the form
        }

        private void CaptureArea()
        {
            // Check if the Area form is showing
            if (areaFormShowing)
            {
                return;
            }

            Hide(); // Hide the form

            areaFormShowing = true; // Set areaFormShowing to true

            // Create instance of the CaptureAreaForm
            using (CaptureAreaForm caf = new CaptureAreaForm(this))
            {
                // Show the CaptureAreaForm
                caf.ShowDialog();

                // Set sLastSize to the CaptureAreaForm lastSize
                Size sLastSize = caf.lastSize;

                // Check if the sLastSize isn't null
                if (sLastSize.Width > 0 && sLastSize.Height > 0)
                {
                    Rectangle r = new Rectangle(); // Create a new Rectangle
                    r.Location = caf.lastLoc; // Set the location of r to the CaptureAreaForm location
                    r.Size = sLastSize; // Set r size to the lastsize of CaptureAreaForm
                    CaptureThat.Capture.CaptureImage(r); // Capture the area image
                }
            }

            areaFormShowing = false; // Set areaFormShowing to false
        }

        private void btnCaptureArea_Click(object sender, EventArgs e)
        {
            CaptureArea(); // Capture an Area
        }

        private void btnCaptureWindow_Click(object sender, EventArgs e)
        {
            Hide(); // Hide the form
            Utilities.Sleep(2);// fixes the error when you're capturing the window/capturethat window
            CaptureThat.Capture.CaptureWindow(); // Capture the selected Window
        }

        private void btnCaptureFull_Click(object sender, EventArgs e)
        {
            Hide(); // Hide the form

            // Check if the user has enabled MultiMonitorScreenshots
            if (!Config.conf.MultiMonitorScreenshot)
            {
                // Only screenshot the primary monitor
                CaptureThat.Capture.CaptureImage(Screen.FromControl(this).Bounds);
            }
            else
            {
                // Screenshot all monitors on the system
                CaptureThat.Capture.CaptureImage(new Rectangle(
                   SystemInformation.VirtualScreen.Left,
                   SystemInformation.VirtualScreen.Top,
                   SystemInformation.VirtualScreen.Width,
                   SystemInformation.VirtualScreen.Height));
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Check if the user left clicked notifyIcon1 and check if SingleClickScreenshots is enabled
            if (e.Button == MouseButtons.Left && !Config.conf.SingleClickScreenshot)
            {
                ShowForm(); // Display the form
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutForm af = new AboutForm();
            af.ShowDialog();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm();
            sf.ShowDialog();
        }

        private void NiSettings_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm();
            sf.ShowDialog();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check if the user has not enabled SecurityMode, if the close reason is from the user, and check if the Exit button closes CaptureThat
            if (!Config.mode.SecurityMode && e.CloseReason == CloseReason.UserClosing && Config.conf.ExitMinimize)
            {
                Hide(); // Hide the form
                e.Cancel = true; // Cancelled is true
            }

            // Check if SecurityMode is enabled
            if (Config.mode.SecurityMode)
            {
                // Unset runonstartup
                key.SetValue("CaptureThat", "");
                key.DeleteValue("CaptureThat");

                // Delete config.json and screenshots
                Directory.Delete(Config.AppSettingsPath, true);
            }

            // Check if the user has enabled the Exit button to close CaptureThat
            if (!Config.conf.ExitMinimize)
            {
                // Unregister the hotkeys
                areaHotKey.Unregiser();
                windowHotKey.Unregiser();
                fullHotKey.Unregiser();
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            // Check if the mouse click was the left and if SingleClickScreenshot is enabled
            if (e.Button == MouseButtons.Left && Config.conf.SingleClickScreenshot)
            {
                CaptureArea(); // Take a screenshot of an area
            }
        }

        /// <summary>
        /// Receive all input directed at your window
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            // Check if a hotkey was pressed and if the PreviewForm is not open
            if (m.Msg == HotKeys.Constants.WM_HOTKEY_MSG_ID && Utils.IsFormAlreadyOpen(typeof(PreviewForm)) == null)
            {
                switch (m.WParam.ToInt32())
                {
                    case 1:
                        CaptureArea(); // Capture an Area
                        break;
                    case 2:
                        Hide(); // Hide the form
                        Utilities.Sleep(2);// fixes the error when you're capturing the window/capturethat window
                        CaptureThat.Capture.CaptureWindow(); // Capture the selected Window
                        break;
                    case 3:
                        Hide(); // Hide

                        // Check if the user has enabled MultiMonitorScreenshots
                        if (!Config.conf.MultiMonitorScreenshot)
                        {
                            // Only screenshot the primary monitor
                            CaptureThat.Capture.CaptureImage(Screen.FromControl(this).Bounds);
                        }
                        else
                        {
                            // Screenshot all monitors on the system
                            CaptureThat.Capture.CaptureImage(new Rectangle(
                               SystemInformation.VirtualScreen.Left,
                               SystemInformation.VirtualScreen.Top,
                               SystemInformation.VirtualScreen.Width,
                               SystemInformation.VirtualScreen.Height));
                        }
                        break;
                }
            }

            base.WndProc(ref m);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Create the hotkeys
            areaHotKey = new HotKeys(1, Utils.parseHotKeyModifiers(
                Config.conf.Keys.AreaCaptureHotKey.Control,
                Config.conf.Keys.AreaCaptureHotKey.Alt,
                Config.conf.Keys.AreaCaptureHotKey.Shift), (Keys)Enum.Parse(typeof(Keys), Config.conf.Keys.AreaCaptureHotKey.Keys).GetHashCode(), this);
            windowHotKey = new HotKeys(2, Utils.parseHotKeyModifiers(
                Config.conf.Keys.WindowCaptureHotKey.Control,
                Config.conf.Keys.WindowCaptureHotKey.Alt,
                Config.conf.Keys.WindowCaptureHotKey.Shift), (Keys)Enum.Parse(typeof(Keys), Config.conf.Keys.WindowCaptureHotKey.Keys).GetHashCode(), this);
            fullHotKey = new HotKeys(3, Utils.parseHotKeyModifiers(
                Config.conf.Keys.FullCaptureHotKey.Control,
                Config.conf.Keys.FullCaptureHotKey.Alt,
                Config.conf.Keys.FullCaptureHotKey.Shift), (Keys)Enum.Parse(typeof(Keys), Config.conf.Keys.FullCaptureHotKey.Keys).GetHashCode(), this);

            // Register the hotkeys
            areaHotKey.Register();
            windowHotKey.Register();
            fullHotKey.Register();
        }
    }
}
