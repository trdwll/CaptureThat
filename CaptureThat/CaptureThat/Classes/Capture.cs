/*
 * Copyright (c) 2016-2019 Russ 'trdwll' Treadwell. All rights reserved.
 * Licensed under the MIT License. See LICENSE.md file in the project root for full license information.
 */
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using apollo.Core;

namespace CaptureThat
{
    public class Capture
    {
        // External methods required to get the selected window
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        // Create a Bitmap that we can access throughout the class
        private static Bitmap image;
        
        // Create the struct for the borders of the window
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        /// <summary>
        /// Get the bitmap 'image'
        /// </summary>
        /// <returns></returns>
        public static Bitmap getBitmap()
        {
            return image;
        }

        /// <summary>
        /// Capture the selected window
        /// </summary>
        public static void CaptureWindow()
        {
            IntPtr hWnd = GetForegroundWindow(); // Get the Window ID
            RECT rct = new RECT(); // Create a new RECT
            GetWindowRect(hWnd, out rct); // Get the windows border

            Rectangle r = new Rectangle(); // Create a new Rectangle
            r.Location = new Point(rct.Left, rct.Top); // Set the location of r to rct
            r.Size = new Size(rct.Right - rct.Left, rct.Bottom - rct.Top); // Set the size of r to the size of rct
            CaptureImage(r); // Capture, Save, and Upload the image
        }

        /// <summary>
        /// Capture, Save, and Upload the Image
        /// </summary>
        /// <param name="r"></param>
        public static void CaptureImage(Rectangle r)
        {
            try
            {
                // Check if PreviewForm is open (means you just took a screenshot)
                if (Utils.IsFormAlreadyOpen(typeof(PreviewForm)) == null)
                {
                    // Create the bitmap based on the r.Width and r.Height
                    image = new Bitmap(r.Width, r.Height);

                    // Create the new image
                    using (Graphics g = Graphics.FromImage(image))
                    {
                        g.CopyFromScreen(r.Location, new Point(0, 0), r.Size);
                    }

                    image.UnlockBits(image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, image.PixelFormat));

                    // Create the image path
                    string img = $@"{Config.conf.ScreenshotSavePath}\{DateTime.Now.ToString("yyyyMMddHHmmss")}.png";

                    // Check if you want to save the image on capture
                    if (Config.conf.SaveImageOnCapture)
                    {
                        // Create the directory of the screenshots path
                        Directory.CreateDirectory(Config.conf.ScreenshotSavePath);
                        if (Directory.Exists(Config.conf.ScreenshotSavePath))
                        {
                            // Save the image to the screenshots path
                            image.Save(img, ImageFormat.Png);
                        }
                    }

                    // Check if you enabled saving the image to clipboard
                    if (Config.conf.CopyImageToClipboard && !Config.conf.CopyLinkToClipboard)
                    {
                        // Clear and set the clipboard
                        Clipboard.Clear();
                        Clipboard.SetDataObject(getBitmap(), false, 3, 200);
                    }

                    // Play the Camera sound if you enabled that feature
                    Utils.PlayCamera();

                    // Check if you enabled the preview window
                    if (Config.conf.ShowPreviewWindow)
                    {
                        // Create the preview window form
                        PreviewForm pf = new PreviewForm();
                        
                        System.Drawing.Image pbimg = getBitmap(); // Get the bitmap 
                        pf.Width = pbimg.Width > 750 ? pbimg.Width / 2 : pbimg.Width; // Size the bitmap
                        pf.Height = pbimg.Height > 750 ? pbimg.Height / 2 : pbimg.Height; // Size the bitmap
                        PreviewForm.pb.Image = pbimg; // Set the bitmap to the PictureBox on PreviewForm
                        PreviewForm.pb.Height = pbimg.Height; // Size the bitmap
                        PreviewForm.pb.Width = pbimg.Width; // Size the bitmap

                        pf.Show(); // Show the PreviewForm
                    }

                    // Check if you want to upload the image to a host after you capture
                    if (Config.conf.UploadImageAfterCapture)
                    {
                        // Check if the File exists or if the bitmap isn't null
                        if (File.Exists(img) || getBitmap() != null)
                        {
                            Utilities.Sleep(1); // Just take a breather, you just worked hard...

                            // Check if the PictureBox on PreviewForm is null
                            if (PreviewForm.pb == null)
                            {
                                // Upload the image
                                Uploader.Upload(getBitmap());
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("You're unable to capture another image while the Preview Window is open!\nPlease close the Preview Window if you'd like to take another screenshot!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
    }
}
