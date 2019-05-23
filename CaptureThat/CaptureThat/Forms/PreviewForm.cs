/*
 * Copyright (c) 2016-2019 Russ 'trdwll' Treadwell. All rights reserved.
 * Licensed under the MIT License. See LICENSE.md file in the project root for full license information.
 */
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using apollo;
using System.Drawing;

namespace CaptureThat
{
    public partial class PreviewForm : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public static PictureBox pb { get { return pb1; } }
        private static PictureBox pb1;

        public PreviewForm()
        {
            InitializeComponent();

            if (Config.conf.FormStyle.EnableStyling)
            {
                Color btnColor = Color.FromName(Config.conf.FormStyle.ButtonColor);

                btn_Close.FlatStyle = FlatStyle.Flat;
                btn_Close.FlatAppearance.BorderColor = btnColor;
                btn_CloseUpload.FlatStyle = FlatStyle.Flat;
                btn_CloseUpload.FlatAppearance.BorderColor = btnColor;

                BackColor = Color.FromName(Config.conf.FormStyle.FormBackgroundColor);

                foreach (Control control in Controls)
                {
                    if (control.GetType() == typeof(Button))
                    {
                        control.BackColor = Color.FromName(Config.conf.FormStyle.ButtonColor);
                    }
                }
            }

            pb1 = pictureBox1;
        }

        private void PreviewForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            pb1 = null;
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_CloseUpload_Click(object sender, EventArgs e)
        {
            btn_CloseUpload.Text = "Uploading...";
            btn_CloseUpload.Enabled = false;
            btn_Close.Enabled = false;

            Uploader.Upload(CaptureThat.Capture.getBitmap());

            Close();
        }

        private void PreviewForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}