/*
 * Copyright (c) 2016-2019 Russ 'trdwll' Treadwell. All rights reserved.
 * Licensed under the MIT License. See LICENSE.md file in the project root for full license information.
 */
using apollo.Forms;
using System;
using System.Windows.Forms;

namespace CaptureThat
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void pbtrdwll_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.trdwll.com");
        }

        private void btnUpdater_Click(object sender, EventArgs e)
        {
            UpdaterForm uf = new UpdaterForm(false, Config.AppUpdateURL, Config.AssemblyVersion, true, true);

            uf.Show();
        }
    }
}
