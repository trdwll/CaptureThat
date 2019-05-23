/*
 * Copyright (c) 2016-2019 Russ 'trdwll' Treadwell. All rights reserved.
 * Licensed under the MIT License. See LICENSE.md file in the project root for full license information.
 */
using System.Windows.Forms;
using apollo.Core;

namespace CaptureThat
{
    public class Utils
    {
        /// <summary>
        /// Notify message using BalloonTips
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="seconds"></param>
        public static void Notify(string title, string message, int seconds)
        {
            if (Config.conf.EnableNotifications)
            {
                MainForm.Notify.BalloonTipTitle = title;
                MainForm.Notify.BalloonTipText = message;

                MainForm.Notify.ShowBalloonTip(1000 * seconds);
            }
        }

        /// <summary>
        /// Play an error sound
        /// </summary>
        public static void PlayError()
        {
            if (Config.conf.EnableSounds)
            {
                Utilities.PlaySound(Properties.Resources.FailedSound);
            }
        }

        /// <summary>
        /// Play a success sound
        /// </summary>
        public static void PlaySuccess()
        {
            if (Config.conf.EnableSounds)
            {
                Utilities.PlaySound(Properties.Resources.SuccessSound);
            }
        }

        /// <summary>
        /// Play a camera sound
        /// </summary>
        public static void PlayCamera()
        {
            if (Config.conf.EnableSounds)
            {
                Utilities.PlaySound(Properties.Resources.CameraSound);
            }
        }

        // Create a random file name
        private static string file = $@"{Application.StartupPath}\tmp\{Security.generateString()}.png";

        /// <summary>
        /// Save a temporary image
        /// </summary>
        /// <param name="image"></param>
        public static void SaveTmpImage(System.Drawing.Bitmap image)
        {
            System.IO.Directory.CreateDirectory($@"{Application.StartupPath}\tmp");
            image.Save(file, System.Drawing.Imaging.ImageFormat.Png);
        }

        /// <summary>
        /// Get the temporary image
        /// </summary>
        /// <returns></returns>
        public static string getTmpImage()
        {
            return System.IO.File.Exists(file) ? file : null;
        }

        /// <summary>
        /// Delete the temporary image(s)
        /// </summary>
        public static void DeleteTmpImage()
        {
            if (System.IO.Directory.Exists($@"{Application.StartupPath}\tmp"))
            {
                System.IO.Directory.Delete($@"{Application.StartupPath}\tmp", true);
            }
        }

        // Terrible way to handle this, but we'll clean it up later
        public static int parseHotKeyModifiers(bool Control, bool Alt, bool Shift)
        {
            int x = Control ? HotKeys.Constants.CTRL : HotKeys.Constants.NOMOD;
            int y = Alt ? HotKeys.Constants.ALT : HotKeys.Constants.NOMOD;
            int z = Shift ? HotKeys.Constants.SHIFT : HotKeys.Constants.NOMOD;

            return x + y + z;
        }

        /// <summary>
        /// Set the clipboard content
        /// </summary>
        /// <param name="content"></param>
        public static void SetClipboard(string content)
        {
            if (Config.conf.CopyLinkToClipboard)
            {
                Clipboard.Clear();
                Clipboard.SetDataObject(content, false, 3, 200);
            }
        }

        /// <summary>
        /// Open a url after capture
        /// </summary>
        /// <param name="url"></param>
        public static void OpenUrlAfterCapture(string url)
        {
            if (Config.conf.OpenURLAfterCapture)
            {
                System.Diagnostics.Process.Start(url);
            }
        }

        /// <summary>
        /// Check if a form is already open
        /// </summary>
        /// <param name="FormType"></param>
        /// <returns></returns>
        public static Form IsFormAlreadyOpen(System.Type FormType)
        {
            foreach (Form OpenForm in Application.OpenForms)
            {
                if (OpenForm.GetType() == FormType)
                {
                    return OpenForm;
                }
            }

            return null;
        }
    }
}
