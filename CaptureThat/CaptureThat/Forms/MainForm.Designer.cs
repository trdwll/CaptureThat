/*
 * Copyright (c) 2016-2019 Russ 'trdwll' Treadwell. All rights reserved.
 * Licensed under the MIT License. See LICENSE.md file in the project root for full license information.
 */
namespace CaptureThat
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnCaptureArea = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnCaptureWindow = new System.Windows.Forms.Button();
            this.btnCaptureFull = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCaptureArea
            // 
            this.btnCaptureArea.Location = new System.Drawing.Point(12, 12);
            this.btnCaptureArea.Name = "btnCaptureArea";
            this.btnCaptureArea.Size = new System.Drawing.Size(64, 64);
            this.btnCaptureArea.TabIndex = 0;
            this.btnCaptureArea.Text = "Area";
            this.btnCaptureArea.UseVisualStyleBackColor = true;
            this.btnCaptureArea.Click += new System.EventHandler(this.btnCaptureArea_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "CaptureThat";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // btnCaptureWindow
            // 
            this.btnCaptureWindow.Location = new System.Drawing.Point(82, 13);
            this.btnCaptureWindow.Name = "btnCaptureWindow";
            this.btnCaptureWindow.Size = new System.Drawing.Size(64, 64);
            this.btnCaptureWindow.TabIndex = 1;
            this.btnCaptureWindow.Text = "Window";
            this.btnCaptureWindow.UseVisualStyleBackColor = true;
            this.btnCaptureWindow.Click += new System.EventHandler(this.btnCaptureWindow_Click);
            // 
            // btnCaptureFull
            // 
            this.btnCaptureFull.Location = new System.Drawing.Point(152, 13);
            this.btnCaptureFull.Name = "btnCaptureFull";
            this.btnCaptureFull.Size = new System.Drawing.Size(64, 64);
            this.btnCaptureFull.TabIndex = 2;
            this.btnCaptureFull.Text = "Full";
            this.btnCaptureFull.UseVisualStyleBackColor = true;
            this.btnCaptureFull.Click += new System.EventHandler(this.btnCaptureFull_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(420, 13);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(64, 64);
            this.btnAbout.TabIndex = 6;
            this.btnAbout.Text = "About";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(350, 13);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(64, 64);
            this.btnSettings.TabIndex = 7;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 89);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnCaptureFull);
            this.Controls.Add(this.btnCaptureWindow);
            this.Controls.Add(this.btnCaptureArea);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CaptureThat";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCaptureArea;
        private System.Windows.Forms.Button btnCaptureWindow;
        private System.Windows.Forms.Button btnCaptureFull;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

