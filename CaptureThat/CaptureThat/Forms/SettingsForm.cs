/*
 * Copyright (c) 2016-2019 Russ 'trdwll' Treadwell. All rights reserved.
 * Licensed under the MIT License. See LICENSE.md file in the project root for full license information.
 */
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using apollo.Core;

namespace CaptureThat
{
    public partial class SettingsForm : Form
    {
        private string selectedName = "";

        private string[] Dirs;

        string areaKey = Config.conf.Keys.AreaCaptureHotKey.ToString() + "+" + Config.conf.Keys.AreaCaptureHotKey.Keys;
        bool[] areaKeyModifiers = Config.conf.Keys.AreaCaptureHotKey.getModifiers();
        string areaKeyKey = Config.conf.Keys.AreaCaptureHotKey.Keys;

        string windowKey = Config.conf.Keys.WindowCaptureHotKey.ToString() + "+" + Config.conf.Keys.WindowCaptureHotKey.Keys;
        bool[] windowKeyModifiers = Config.conf.Keys.WindowCaptureHotKey.getModifiers();
        string windowKeyKey = Config.conf.Keys.WindowCaptureHotKey.Keys;

        string fullKey = Config.conf.Keys.FullCaptureHotKey.ToString() + "+" +Config.conf.Keys.FullCaptureHotKey.Keys;
        bool[] fullKeyModifiers = Config.conf.Keys.FullCaptureHotKey.getModifiers();
        string fullKeyKey = Config.conf.Keys.FullCaptureHotKey.Keys;

        public SettingsForm()
        {
            InitializeComponent();

            cbFormColor.Enabled = Config.conf.FormStyle.EnableStyling;
            cbButtonColor.Enabled = Config.conf.FormStyle.EnableStyling;

            if (Directory.Exists($@"{Application.StartupPath}\iconpacks"))
            {
                cblbIconPacks.Enabled = true;
                Dirs = Directory.GetDirectories($@"{Application.StartupPath}\iconpacks", "*", SearchOption.AllDirectories);

                // Populate IconPacks
                if (Dirs.Length > 0)
                {
                    foreach (string dir in Dirs)
                    {
                        cblbIconPacks.Items.Add(Path.GetFileName(dir));
                    }
                }
            }

            foreach (PropertyInfo c in typeof(Color).GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public))
            {
                cbBeforeCapture.Items.Add(c.Name);
                cbWhileCapture.Items.Add(c.Name);
                cbPenColor.Items.Add(c.Name);
                cbFontColor.Items.Add(c.Name);

                cbFormColor.Items.Add(c.Name);
                cbButtonColor.Items.Add(c.Name);
            }

            cbFormColor.Items.Add("Control"); // Add Control
            cbButtonColor.Items.Add("Control"); // Add Control

            foreach (string c in Enum.GetNames(typeof(DashStyle)))
            {
                cbPenStyle.Items.Add(c);
            }

            // General
            cbStartup.Checked = Config.conf.RunOnWindowsStartup;
            cbMinimizeForm.Checked = Config.conf.MinimizeFormOnStartup;
            cbIconsOnButtons.Checked = Config.conf.ForceIconsOnButtons;
            cbUploadAfterCapture.Checked = Config.conf.UploadImageAfterCapture;
            cbMinimize.Checked = Config.conf.ExitMinimize;
            cbSounds.Checked = Config.conf.EnableSounds;
            cbEnableNotifications.Checked = Config.conf.EnableNotifications;
            cbPreviewWindow.Checked = Config.conf.ShowPreviewWindow;
            cbUploader.SelectedItem = Config.conf.Uploader;
            txtImgurAPI.Text = Config.conf.ImgurAPI;
            txtGyazoAPI.Text = Config.conf.GyazoAPI;
            cbImageClipboard.Checked = Config.conf.CopyImageToClipboard;
            cbLinkClipboard.Checked = Config.conf.CopyLinkToClipboard;
            cbSaveImage.Checked = Config.conf.SaveImageOnCapture;
            cbScreenshot.Checked = Config.conf.SingleClickScreenshot;
            cbMultiMonitor.Checked = Config.conf.MultiMonitorScreenshot;
            txtScreenshotLocation.Text = Config.conf.ScreenshotSavePath;
            cbOpenAfterCapture.Checked = Config.conf.OpenURLAfterCapture;
            btnAreaHotKey.Text = areaKey;
            btnWindowHotKey.Text = windowKey;
            btnFullHotKey.Text = fullKey;

            // Design
            cbShowPen.Checked = Config.conf.ShowPenBeforeCapture;
            cbPenBorder.Checked = Config.conf.ShowPenToBorderSelection;
            cbBeforeCapture.SelectedItem = Config.conf.BeforeCaptureColor;
            cbWhileCapture.SelectedItem = Config.conf.WhileCaptureColor;
            cbPenColor.SelectedItem = Config.conf.PenColor;
            cbFontColor.SelectedItem = Config.conf.FontColor;
            cbPenStyle.SelectedItem = Config.conf.PenStyle.ToString();
            cblbIconPacks.SetItemChecked(cblbIconPacks.Items.Contains(Config.conf.IconPackName) ? 
                cblbIconPacks.Items.IndexOf(Config.conf.IconPackName) : 0, true);

            cbEnableStyling.Checked = Config.conf.FormStyle.EnableStyling;
            cbFormColor.SelectedItem = Config.conf.FormStyle.FormBackgroundColor;
            cbButtonColor.SelectedItem = Config.conf.FormStyle.ButtonColor;

            cbSaveDeletionURL.Checked = Config.conf.SaveDeletionUrl;

            // Remove Custom
            cbPenStyle.Items.RemoveAt(cbPenStyle.Items.Count - 1);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cbStartup.Checked != Config.conf.RunOnWindowsStartup ||
                cbMinimizeForm.Checked != Config.conf.MinimizeFormOnStartup ||
                cbIconsOnButtons.Checked != Config.conf.ForceIconsOnButtons ||
                selectedName != Config.conf.IconPackName ||
                cbUploadAfterCapture.Checked != Config.conf.UploadImageAfterCapture ||
                cbScreenshot.Checked != Config.conf.SingleClickScreenshot ||
                cbSaveImage.Checked != Config.conf.SaveImageOnCapture ||
                cbMultiMonitor.Checked != Config.conf.MultiMonitorScreenshot ||
                cbMinimize.Checked != Config.conf.ExitMinimize ||
                cbSounds.Checked != Config.conf.EnableSounds ||
                cbEnableNotifications.Checked != Config.conf.EnableNotifications ||
                cbPreviewWindow.Checked != Config.conf.ShowPreviewWindow ||
                cbUploader.SelectedItem.ToString() != Config.conf.Uploader ||
                txtImgurAPI.Text != Config.conf.ImgurAPI ||
                txtGyazoAPI.Text != Config.conf.GyazoAPI ||
                cbImageClipboard.Checked != Config.conf.CopyImageToClipboard ||
                cbLinkClipboard.Checked != Config.conf.CopyLinkToClipboard ||
                cbShowPen.Checked != Config.conf.ShowPenBeforeCapture ||
                cbPenBorder.Checked != Config.conf.ShowPenToBorderSelection ||
                txtScreenshotLocation.Text != Config.conf.ScreenshotSavePath ||
                cbOpenAfterCapture.Checked != Config.conf.OpenURLAfterCapture ||
                btnAreaHotKey.Text != areaKey ||
                btnWindowHotKey.Text != windowKey ||
                btnFullHotKey.Text != fullKey ||
                cbBeforeCapture.SelectedItem.ToString() != Config.conf.BeforeCaptureColor ||
                cbWhileCapture.SelectedItem.ToString() != Config.conf.WhileCaptureColor ||
                cbPenColor.SelectedItem.ToString() != Config.conf.PenColor ||
                cbFontColor.SelectedItem.ToString() != Config.conf.FontColor ||
                cbPenStyle.SelectedItem.ToString() != Config.conf.PenStyle.ToString() ||
                cbSaveDeletionURL.Checked != Config.conf.SaveDeletionUrl ||

                cbEnableStyling.Checked != Config.conf.FormStyle.EnableStyling ||
                cbFormColor.SelectedItem.ToString() != Config.conf.FormStyle.FormBackgroundColor || 
                cbButtonColor.SelectedItem.ToString() != Config.conf.FormStyle.ButtonColor
                )
            {
                if (MessageBox.Show("Are you sure you want to overwrite your existing config with this new config?", "Overwrite?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Config.C cfg = new Config.C();
                    cfg.RunOnWindowsStartup = cbStartup.Checked;
                    cfg.MinimizeFormOnStartup = cbMinimizeForm.Checked;
                    cfg.ForceIconsOnButtons = cbIconsOnButtons.Checked;
                    cfg.IconPackName = selectedName;
                    cfg.UploadImageAfterCapture = cbUploadAfterCapture.Checked;
                    cfg.SaveImageOnCapture = cbSaveImage.Checked;
                    cfg.ExitMinimize = cbMinimize.Checked;
                    cfg.EnableSounds = cbSounds.Checked;
                    cfg.EnableNotifications = cbEnableNotifications.Checked;
                    cfg.ShowPreviewWindow = cbPreviewWindow.Checked;
                    cfg.ScreenshotSavePath = txtScreenshotLocation.Text;
                    cfg.SingleClickScreenshot = cbScreenshot.Checked;
                    cfg.MultiMonitorScreenshot = cbMultiMonitor.Checked;
                    cfg.Uploader = cbUploader.SelectedItem.ToString();
                    cfg.ImgurAPI = txtImgurAPI.Text;
                    cfg.GyazoAPI = txtGyazoAPI.Text;
                    cfg.OpenURLAfterCapture = cbOpenAfterCapture.Checked;
                    cfg.Keys.AreaCaptureHotKey.setModifiers(areaKeyModifiers);
                    cfg.Keys.AreaCaptureHotKey.Keys = areaKeyKey;
                    cfg.Keys.WindowCaptureHotKey.setModifiers(windowKeyModifiers);
                    cfg.Keys.WindowCaptureHotKey.Keys = windowKeyKey;
                    cfg.Keys.FullCaptureHotKey.setModifiers(fullKeyModifiers);
                    cfg.Keys.FullCaptureHotKey.Keys = fullKeyKey;
                    cfg.CopyImageToClipboard = cbImageClipboard.Checked;
                    cfg.CopyLinkToClipboard = cbLinkClipboard.Checked;
                    cfg.ShowPenBeforeCapture = cbShowPen.Checked;
                    cfg.ShowPenToBorderSelection = cbPenBorder.Checked;
                    cfg.BeforeCaptureColor = cbBeforeCapture.SelectedItem.ToString();
                    cfg.WhileCaptureColor = cbWhileCapture.SelectedItem.ToString();
                    cfg.PenColor = cbPenColor.SelectedItem.ToString();
                    cfg.FontColor = cbFontColor.SelectedItem.ToString();
                    cfg.PenStyle = (DashStyle)Enum.Parse(typeof(DashStyle), cbPenStyle.SelectedItem.ToString());
                    cfg.SaveDeletionUrl = cbSaveDeletionURL.Checked;

                    cfg.FormStyle.EnableStyling = cbEnableStyling.Checked;
                    cfg.FormStyle.FormBackgroundColor = cbFormColor.SelectedItem.ToString();
                    cfg.FormStyle.ButtonColor = cbButtonColor.SelectedItem.ToString();

                    Directory.GetParent(Config.ConfigFile).Create();
                    File.WriteAllText(Config.ConfigFile, new JavaScriptSerializer().Serialize(cfg));

                    Application.Restart();
                }
                else
                {
                    Close();
                }
            }
            else
            {
                Close();
            }
        }

        private void cbBeforeCapture_DrawItem(object sender, DrawItemEventArgs e)
        {
            drawColor(sender, e);
        }

        private void cbWhileCapture_DrawItem(object sender, DrawItemEventArgs e)
        {
            drawColor(sender, e);
        }

        private void cbPenColor_DrawItem(object sender, DrawItemEventArgs e)
        {
            drawColor(sender, e);
        }

        private void cbFontColor_DrawItem(object sender, DrawItemEventArgs e)
        {
            drawColor(sender, e);
        }

        private void cbFormColor_DrawItem(object sender, DrawItemEventArgs e)
        {
            drawColor(sender, e);
        }

        private void cbButtonColor_DrawItem(object sender, DrawItemEventArgs e)
        {
            drawColor(sender, e);
        }

        private void cbUploader_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                e.Graphics.DrawString(((ComboBox)sender).Items[e.Index].ToString(), 
                    new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular), Brushes.Black, e.Bounds.X, e.Bounds.Top);
            }
        }

        private void cbPenStyle_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                Pen pen = new Pen(Color.Black, 2);
                pen.DashStyle = (DashStyle)Enum.Parse(typeof(DashStyle), cbPenStyle.Items[e.Index].ToString());

                Rectangle rect = e.Bounds;
                Graphics g = e.Graphics;
                g.DrawString(((ComboBox)sender).Items[e.Index].ToString(), 
                    new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular), Brushes.Black, rect.X, rect.Top);
                g.DrawLine(pen, rect.X + 150, rect.Y + rect.Height / 2, rect.Width - 5, rect.Y + rect.Height / 2);
            }
        }

        void drawColor(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                string n = ((ComboBox)sender).Items[e.Index].ToString();
                Brush b = new SolidBrush(Color.FromName(n));

                Rectangle rect = e.Bounds;
                Graphics g = e.Graphics;
                g.DrawString(n, new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular), Brushes.Black, rect.X, rect.Top);
                g.FillRectangle(b, rect.X + 150, rect.Y +1, rect.Width - 10, rect.Height - 2);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbImageClipboard_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLinkClipboard.Checked)
            {
                cbImageClipboard.Checked = false;
            }
        }

        private void cbLinkClipboard_CheckedChanged(object sender, EventArgs e)
        {
            if (cbImageClipboard.Checked)
            {
                cbLinkClipboard.Checked = false;
            }
        }

        private void cblbIconPacks_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < cblbIconPacks.Items.Count; i++)
            {
                if (i != e.Index)
                {
                    cblbIconPacks.SetItemChecked(i, false);
                }
            }
            selectedName = cblbIconPacks.Items[e.Index].ToString();
        }

        private void cbUploader_SelectedIndexChanged(object sender, EventArgs e)
        {
            label8.Text = cbUploader.SelectedIndex == 0 ? "Imgur API Key" : cbUploader.SelectedIndex == 2 ? "Gyazo API Key" : "";
            txtImgurAPI.Visible = cbUploader.SelectedIndex == 0;
            txtGyazoAPI.Visible = cbUploader.SelectedIndex == 2;
            cbSaveDeletionURL.Visible = cbUploader.SelectedIndex == 1;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog()
            {
                Description = "Select a location that you'd like to save your screenshots to!",
                ShowNewFolderButton = true
            };

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtScreenshotLocation.Text = fbd.SelectedPath;
            }
        }

        private void cbSaveImage_CheckedChanged(object sender, EventArgs e)
        {
            btnBrowse.Enabled = cbSaveImage.Checked;
        }

        private void btnAreaHotKey_KeyDown(object sender, KeyEventArgs e)
        {
            string f = Config.HotKeys.Key.parseHotKeyModifiersToString(e.Control, e.Alt, e.Shift);
            btnAreaHotKey.Text = (!IO.isEmpty(f) ? f + "+" : "") + (e.KeyCode.ToString() != "" ? e.KeyCode.ToString() : "");

            areaKeyModifiers[0] = e.Control;
            areaKeyModifiers[1] = e.Alt;
            areaKeyModifiers[2] = e.Shift;
            areaKeyKey = e.KeyCode.ToString();
        }

        private void btnWindowHotKey_KeyDown(object sender, KeyEventArgs e)
        {
            string f = Config.HotKeys.Key.parseHotKeyModifiersToString(e.Control, e.Alt, e.Shift);
            btnWindowHotKey.Text = (!IO.isEmpty(f) ? f + "+" : "") + (e.KeyCode.ToString() != "" ? e.KeyCode.ToString() : "");

            windowKeyModifiers[0] = e.Control;
            windowKeyModifiers[1] = e.Alt;
            windowKeyModifiers[2] = e.Shift;
            windowKeyKey = e.KeyCode.ToString();
        }

        private void btnFullHotKey_KeyDown(object sender, KeyEventArgs e)
        {
            string f = Config.HotKeys.Key.parseHotKeyModifiersToString(e.Control, e.Alt, e.Shift);
            btnFullHotKey.Text = (!IO.isEmpty(f) ? f + "+" : "") + (e.KeyCode.ToString() != "" ? e.KeyCode.ToString() : "");

            fullKeyModifiers[0] = e.Control;
            fullKeyModifiers[1] = e.Alt;
            fullKeyModifiers[2] = e.Shift;
            fullKeyKey = e.KeyCode.ToString();
        }

        private void cbEnableStyling_CheckedChanged(object sender, EventArgs e)
        {
            if (cbEnableStyling.Checked)
            {
                cbFormColor.Enabled = true;
                cbButtonColor.Enabled = true;
            }
            else
            {
                cbFormColor.Enabled = false;
                cbButtonColor.Enabled = false;
            }
        }
    }
}
