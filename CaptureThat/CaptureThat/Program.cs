/*
 * Copyright (c) 2016-2019 Russ 'trdwll' Treadwell. All rights reserved.
 * Licensed under the MIT License. See LICENSE.md file in the project root for full license information.
 */
using System;
using System.Threading;
using System.Windows.Forms;

namespace CaptureThat
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (Mutex m = new Mutex(false, "Global\\68a61104-0be4-4489-ad18-711022ba3124"))
            {
                if (!m.WaitOne(0, false))
                {
                    MessageBox.Show("CaptureThat is already running!", "CaptureThat", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                    return;
                }

                Application.Run(new MainForm());
            }
        }
    }
}
