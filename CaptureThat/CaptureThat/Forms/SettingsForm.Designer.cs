/*
 * Copyright (c) 2016-2019 Russ 'trdwll' Treadwell. All rights reserved.
 * Licensed under the MIT License. See LICENSE.md file in the project root for full license information.
 */
namespace CaptureThat
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpGeneral = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnFullHotKey = new System.Windows.Forms.Button();
            this.btnWindowHotKey = new System.Windows.Forms.Button();
            this.btnAreaHotKey = new System.Windows.Forms.Button();
            this.cbScreenshot = new System.Windows.Forms.CheckBox();
            this.cbMinimize = new System.Windows.Forms.CheckBox();
            this.cbPreviewWindow = new System.Windows.Forms.CheckBox();
            this.cbEnableNotifications = new System.Windows.Forms.CheckBox();
            this.cbMinimizeForm = new System.Windows.Forms.CheckBox();
            this.cbSounds = new System.Windows.Forms.CheckBox();
            this.cbStartup = new System.Windows.Forms.CheckBox();
            this.tpDesign = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.cblbIconPacks = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbIconsOnButtons = new System.Windows.Forms.CheckBox();
            this.cbPenBorder = new System.Windows.Forms.CheckBox();
            this.cbPenStyle = new System.Windows.Forms.ComboBox();
            this.cbShowPen = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbFontColor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPenColor = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbWhileCapture = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbBeforeCapture = new System.Windows.Forms.ComboBox();
            this.tpScreenshot = new System.Windows.Forms.TabPage();
            this.cbOpenAfterCapture = new System.Windows.Forms.CheckBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtScreenshotLocation = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbMultiMonitor = new System.Windows.Forms.CheckBox();
            this.txtGyazoAPI = new System.Windows.Forms.TextBox();
            this.cbImageClipboard = new System.Windows.Forms.CheckBox();
            this.cbSaveImage = new System.Windows.Forms.CheckBox();
            this.cbLinkClipboard = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbUploadAfterCapture = new System.Windows.Forms.CheckBox();
            this.txtImgurAPI = new System.Windows.Forms.TextBox();
            this.cbUploader = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tpFormStyle = new System.Windows.Forms.TabPage();
            this.cbEnableStyling = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbButtonColor = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbFormColor = new System.Windows.Forms.ComboBox();
            this.cbSaveDeletionURL = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tpGeneral.SuspendLayout();
            this.tpDesign.SuspendLayout();
            this.tpScreenshot.SuspendLayout();
            this.tpFormStyle.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(407, 322);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(488, 322);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpGeneral);
            this.tabControl1.Controls.Add(this.tpDesign);
            this.tabControl1.Controls.Add(this.tpScreenshot);
            this.tabControl1.Controls.Add(this.tpFormStyle);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(551, 304);
            this.tabControl1.TabIndex = 2;
            // 
            // tpGeneral
            // 
            this.tpGeneral.Controls.Add(this.label13);
            this.tpGeneral.Controls.Add(this.label12);
            this.tpGeneral.Controls.Add(this.label11);
            this.tpGeneral.Controls.Add(this.btnFullHotKey);
            this.tpGeneral.Controls.Add(this.btnWindowHotKey);
            this.tpGeneral.Controls.Add(this.btnAreaHotKey);
            this.tpGeneral.Controls.Add(this.cbScreenshot);
            this.tpGeneral.Controls.Add(this.cbMinimize);
            this.tpGeneral.Controls.Add(this.cbPreviewWindow);
            this.tpGeneral.Controls.Add(this.cbEnableNotifications);
            this.tpGeneral.Controls.Add(this.cbMinimizeForm);
            this.tpGeneral.Controls.Add(this.cbSounds);
            this.tpGeneral.Controls.Add(this.cbStartup);
            this.tpGeneral.Location = new System.Drawing.Point(4, 22);
            this.tpGeneral.Name = "tpGeneral";
            this.tpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tpGeneral.Size = new System.Drawing.Size(543, 278);
            this.tpGeneral.TabIndex = 0;
            this.tpGeneral.Text = "General";
            this.tpGeneral.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(275, 69);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 13);
            this.label13.TabIndex = 26;
            this.label13.Text = "Full";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(275, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 13);
            this.label12.TabIndex = 25;
            this.label12.Text = "Window";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(275, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Area";
            // 
            // btnFullHotKey
            // 
            this.btnFullHotKey.Location = new System.Drawing.Point(341, 64);
            this.btnFullHotKey.Name = "btnFullHotKey";
            this.btnFullHotKey.Size = new System.Drawing.Size(196, 23);
            this.btnFullHotKey.TabIndex = 23;
            this.btnFullHotKey.Text = "Full Screen HotKey";
            this.btnFullHotKey.UseVisualStyleBackColor = true;
            this.btnFullHotKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnFullHotKey_KeyDown);
            // 
            // btnWindowHotKey
            // 
            this.btnWindowHotKey.Location = new System.Drawing.Point(341, 35);
            this.btnWindowHotKey.Name = "btnWindowHotKey";
            this.btnWindowHotKey.Size = new System.Drawing.Size(196, 23);
            this.btnWindowHotKey.TabIndex = 22;
            this.btnWindowHotKey.Text = "Window HotKey";
            this.btnWindowHotKey.UseVisualStyleBackColor = true;
            this.btnWindowHotKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnWindowHotKey_KeyDown);
            // 
            // btnAreaHotKey
            // 
            this.btnAreaHotKey.Location = new System.Drawing.Point(341, 6);
            this.btnAreaHotKey.Name = "btnAreaHotKey";
            this.btnAreaHotKey.Size = new System.Drawing.Size(196, 23);
            this.btnAreaHotKey.TabIndex = 21;
            this.btnAreaHotKey.Text = "Area HotKey";
            this.btnAreaHotKey.UseVisualStyleBackColor = true;
            this.btnAreaHotKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.btnAreaHotKey_KeyDown);
            // 
            // cbScreenshot
            // 
            this.cbScreenshot.AutoSize = true;
            this.cbScreenshot.Location = new System.Drawing.Point(3, 144);
            this.cbScreenshot.Name = "cbScreenshot";
            this.cbScreenshot.Size = new System.Drawing.Size(162, 17);
            this.cbScreenshot.TabIndex = 20;
            this.cbScreenshot.Text = "Single Click Icon Screenshot";
            this.cbScreenshot.UseVisualStyleBackColor = true;
            // 
            // cbMinimize
            // 
            this.cbMinimize.AutoSize = true;
            this.cbMinimize.Location = new System.Drawing.Point(3, 52);
            this.cbMinimize.Name = "cbMinimize";
            this.cbMinimize.Size = new System.Drawing.Size(120, 17);
            this.cbMinimize.TabIndex = 17;
            this.cbMinimize.Text = "Exit Button Minimize";
            this.cbMinimize.UseVisualStyleBackColor = true;
            // 
            // cbPreviewWindow
            // 
            this.cbPreviewWindow.AutoSize = true;
            this.cbPreviewWindow.Location = new System.Drawing.Point(3, 121);
            this.cbPreviewWindow.Name = "cbPreviewWindow";
            this.cbPreviewWindow.Size = new System.Drawing.Size(142, 17);
            this.cbPreviewWindow.TabIndex = 16;
            this.cbPreviewWindow.Text = "Enable Preview Window";
            this.cbPreviewWindow.UseVisualStyleBackColor = true;
            // 
            // cbEnableNotifications
            // 
            this.cbEnableNotifications.AutoSize = true;
            this.cbEnableNotifications.Location = new System.Drawing.Point(3, 98);
            this.cbEnableNotifications.Name = "cbEnableNotifications";
            this.cbEnableNotifications.Size = new System.Drawing.Size(120, 17);
            this.cbEnableNotifications.TabIndex = 11;
            this.cbEnableNotifications.Text = "Enable Notifications";
            this.cbEnableNotifications.UseVisualStyleBackColor = true;
            // 
            // cbMinimizeForm
            // 
            this.cbMinimizeForm.AutoSize = true;
            this.cbMinimizeForm.Location = new System.Drawing.Point(3, 29);
            this.cbMinimizeForm.Name = "cbMinimizeForm";
            this.cbMinimizeForm.Size = new System.Drawing.Size(144, 17);
            this.cbMinimizeForm.TabIndex = 8;
            this.cbMinimizeForm.Text = "Minimize Form on Startup";
            this.cbMinimizeForm.UseVisualStyleBackColor = true;
            // 
            // cbSounds
            // 
            this.cbSounds.AutoSize = true;
            this.cbSounds.Location = new System.Drawing.Point(3, 75);
            this.cbSounds.Name = "cbSounds";
            this.cbSounds.Size = new System.Drawing.Size(98, 17);
            this.cbSounds.TabIndex = 1;
            this.cbSounds.Text = "Enable Sounds";
            this.cbSounds.UseVisualStyleBackColor = true;
            // 
            // cbStartup
            // 
            this.cbStartup.AutoSize = true;
            this.cbStartup.Location = new System.Drawing.Point(3, 6);
            this.cbStartup.Name = "cbStartup";
            this.cbStartup.Size = new System.Drawing.Size(145, 17);
            this.cbStartup.TabIndex = 0;
            this.cbStartup.Text = "Run on Windows Startup";
            this.cbStartup.UseVisualStyleBackColor = true;
            // 
            // tpDesign
            // 
            this.tpDesign.Controls.Add(this.label9);
            this.tpDesign.Controls.Add(this.cblbIconPacks);
            this.tpDesign.Controls.Add(this.label6);
            this.tpDesign.Controls.Add(this.label5);
            this.tpDesign.Controls.Add(this.cbIconsOnButtons);
            this.tpDesign.Controls.Add(this.cbPenBorder);
            this.tpDesign.Controls.Add(this.cbPenStyle);
            this.tpDesign.Controls.Add(this.cbShowPen);
            this.tpDesign.Controls.Add(this.label4);
            this.tpDesign.Controls.Add(this.cbFontColor);
            this.tpDesign.Controls.Add(this.label3);
            this.tpDesign.Controls.Add(this.cbPenColor);
            this.tpDesign.Controls.Add(this.label2);
            this.tpDesign.Controls.Add(this.cbWhileCapture);
            this.tpDesign.Controls.Add(this.label1);
            this.tpDesign.Controls.Add(this.cbBeforeCapture);
            this.tpDesign.Location = new System.Drawing.Point(4, 22);
            this.tpDesign.Name = "tpDesign";
            this.tpDesign.Padding = new System.Windows.Forms.Padding(3);
            this.tpDesign.Size = new System.Drawing.Size(543, 278);
            this.tpDesign.TabIndex = 1;
            this.tpDesign.Text = "Design";
            this.tpDesign.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(330, 162);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(203, 65);
            this.label9.TabIndex = 16;
            this.label9.Text = "Icon packs need to be located at \r\nInstall/iconpacks/YourIconPackName \r\nThe icons" +
    " that are required are area.png, \r\nwindow.png, full.png, settings.png, and \r\nabo" +
    "ut.png.";
            // 
            // cblbIconPacks
            // 
            this.cblbIconPacks.Enabled = false;
            this.cblbIconPacks.FormattingEnabled = true;
            this.cblbIconPacks.Items.AddRange(new object[] {
            "default"});
            this.cblbIconPacks.Location = new System.Drawing.Point(117, 162);
            this.cblbIconPacks.Name = "cblbIconPacks";
            this.cblbIconPacks.Size = new System.Drawing.Size(207, 94);
            this.cblbIconPacks.TabIndex = 15;
            this.cblbIconPacks.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cblbIconPacks_ItemCheck);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Icon Pack";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Pen Style";
            // 
            // cbIconsOnButtons
            // 
            this.cbIconsOnButtons.AutoSize = true;
            this.cbIconsOnButtons.Location = new System.Drawing.Point(336, 62);
            this.cbIconsOnButtons.Name = "cbIconsOnButtons";
            this.cbIconsOnButtons.Size = new System.Drawing.Size(136, 17);
            this.cbIconsOnButtons.TabIndex = 9;
            this.cbIconsOnButtons.Text = "Force Icons on Buttons";
            this.cbIconsOnButtons.UseVisualStyleBackColor = true;
            // 
            // cbPenBorder
            // 
            this.cbPenBorder.AutoSize = true;
            this.cbPenBorder.Location = new System.Drawing.Point(336, 39);
            this.cbPenBorder.Name = "cbPenBorder";
            this.cbPenBorder.Size = new System.Drawing.Size(164, 17);
            this.cbPenBorder.TabIndex = 6;
            this.cbPenBorder.Text = "Show Pen Border on Capture";
            this.cbPenBorder.UseVisualStyleBackColor = true;
            // 
            // cbPenStyle
            // 
            this.cbPenStyle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPenStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPenStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPenStyle.FormattingEnabled = true;
            this.cbPenStyle.Location = new System.Drawing.Point(117, 133);
            this.cbPenStyle.Name = "cbPenStyle";
            this.cbPenStyle.Size = new System.Drawing.Size(197, 23);
            this.cbPenStyle.TabIndex = 12;
            this.cbPenStyle.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbPenStyle_DrawItem);
            // 
            // cbShowPen
            // 
            this.cbShowPen.AutoSize = true;
            this.cbShowPen.Location = new System.Drawing.Point(336, 16);
            this.cbShowPen.Name = "cbShowPen";
            this.cbShowPen.Size = new System.Drawing.Size(130, 17);
            this.cbShowPen.TabIndex = 5;
            this.cbShowPen.Text = "Show Pen on Capture";
            this.cbShowPen.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Font Color";
            // 
            // cbFontColor
            // 
            this.cbFontColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFontColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFontColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFontColor.FormattingEnabled = true;
            this.cbFontColor.Location = new System.Drawing.Point(117, 104);
            this.cbFontColor.Name = "cbFontColor";
            this.cbFontColor.Size = new System.Drawing.Size(197, 23);
            this.cbFontColor.TabIndex = 9;
            this.cbFontColor.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbFontColor_DrawItem);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Pen Color";
            // 
            // cbPenColor
            // 
            this.cbPenColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbPenColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPenColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPenColor.FormattingEnabled = true;
            this.cbPenColor.Location = new System.Drawing.Point(117, 75);
            this.cbPenColor.Name = "cbPenColor";
            this.cbPenColor.Size = new System.Drawing.Size(197, 23);
            this.cbPenColor.TabIndex = 6;
            this.cbPenColor.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbPenColor_DrawItem);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "While Capture Color";
            // 
            // cbWhileCapture
            // 
            this.cbWhileCapture.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbWhileCapture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWhileCapture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbWhileCapture.FormattingEnabled = true;
            this.cbWhileCapture.Location = new System.Drawing.Point(117, 46);
            this.cbWhileCapture.Name = "cbWhileCapture";
            this.cbWhileCapture.Size = new System.Drawing.Size(197, 23);
            this.cbWhileCapture.TabIndex = 2;
            this.cbWhileCapture.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbWhileCapture_DrawItem);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Before Capture Color";
            // 
            // cbBeforeCapture
            // 
            this.cbBeforeCapture.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbBeforeCapture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBeforeCapture.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBeforeCapture.FormattingEnabled = true;
            this.cbBeforeCapture.Location = new System.Drawing.Point(117, 16);
            this.cbBeforeCapture.Name = "cbBeforeCapture";
            this.cbBeforeCapture.Size = new System.Drawing.Size(197, 23);
            this.cbBeforeCapture.TabIndex = 0;
            this.cbBeforeCapture.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbBeforeCapture_DrawItem);
            // 
            // tpScreenshot
            // 
            this.tpScreenshot.Controls.Add(this.cbSaveDeletionURL);
            this.tpScreenshot.Controls.Add(this.cbOpenAfterCapture);
            this.tpScreenshot.Controls.Add(this.btnBrowse);
            this.tpScreenshot.Controls.Add(this.txtScreenshotLocation);
            this.tpScreenshot.Controls.Add(this.label10);
            this.tpScreenshot.Controls.Add(this.cbMultiMonitor);
            this.tpScreenshot.Controls.Add(this.txtGyazoAPI);
            this.tpScreenshot.Controls.Add(this.cbImageClipboard);
            this.tpScreenshot.Controls.Add(this.cbSaveImage);
            this.tpScreenshot.Controls.Add(this.cbLinkClipboard);
            this.tpScreenshot.Controls.Add(this.label7);
            this.tpScreenshot.Controls.Add(this.cbUploadAfterCapture);
            this.tpScreenshot.Controls.Add(this.txtImgurAPI);
            this.tpScreenshot.Controls.Add(this.cbUploader);
            this.tpScreenshot.Controls.Add(this.label8);
            this.tpScreenshot.Location = new System.Drawing.Point(4, 22);
            this.tpScreenshot.Name = "tpScreenshot";
            this.tpScreenshot.Padding = new System.Windows.Forms.Padding(3);
            this.tpScreenshot.Size = new System.Drawing.Size(543, 278);
            this.tpScreenshot.TabIndex = 2;
            this.tpScreenshot.Text = "Screenshot";
            this.tpScreenshot.UseVisualStyleBackColor = true;
            // 
            // cbOpenAfterCapture
            // 
            this.cbOpenAfterCapture.AutoSize = true;
            this.cbOpenAfterCapture.Location = new System.Drawing.Point(6, 121);
            this.cbOpenAfterCapture.Name = "cbOpenAfterCapture";
            this.cbOpenAfterCapture.Size = new System.Drawing.Size(140, 17);
            this.cbOpenAfterCapture.TabIndex = 24;
            this.cbOpenAfterCapture.Text = "Open Link After Capture";
            this.cbOpenAfterCapture.UseVisualStyleBackColor = true;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(515, 147);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(25, 23);
            this.btnBrowse.TabIndex = 23;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtScreenshotLocation
            // 
            this.txtScreenshotLocation.Enabled = false;
            this.txtScreenshotLocation.Location = new System.Drawing.Point(193, 149);
            this.txtScreenshotLocation.Name = "txtScreenshotLocation";
            this.txtScreenshotLocation.Size = new System.Drawing.Size(316, 20);
            this.txtScreenshotLocation.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 152);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Screenshot Save Location";
            // 
            // cbMultiMonitor
            // 
            this.cbMultiMonitor.AutoSize = true;
            this.cbMultiMonitor.Location = new System.Drawing.Point(6, 6);
            this.cbMultiMonitor.Name = "cbMultiMonitor";
            this.cbMultiMonitor.Size = new System.Drawing.Size(184, 17);
            this.cbMultiMonitor.TabIndex = 21;
            this.cbMultiMonitor.Text = "Enable Multi-Monitor Screenshots";
            this.cbMultiMonitor.UseVisualStyleBackColor = true;
            // 
            // txtGyazoAPI
            // 
            this.txtGyazoAPI.Location = new System.Drawing.Point(348, 35);
            this.txtGyazoAPI.Name = "txtGyazoAPI";
            this.txtGyazoAPI.Size = new System.Drawing.Size(189, 20);
            this.txtGyazoAPI.TabIndex = 19;
            // 
            // cbImageClipboard
            // 
            this.cbImageClipboard.AutoSize = true;
            this.cbImageClipboard.Location = new System.Drawing.Point(6, 52);
            this.cbImageClipboard.Name = "cbImageClipboard";
            this.cbImageClipboard.Size = new System.Drawing.Size(141, 17);
            this.cbImageClipboard.TabIndex = 3;
            this.cbImageClipboard.Text = "Copy Image to Clipboard";
            this.cbImageClipboard.UseVisualStyleBackColor = true;
            this.cbImageClipboard.CheckedChanged += new System.EventHandler(this.cbImageClipboard_CheckedChanged);
            // 
            // cbSaveImage
            // 
            this.cbSaveImage.AutoSize = true;
            this.cbSaveImage.Location = new System.Drawing.Point(6, 98);
            this.cbSaveImage.Name = "cbSaveImage";
            this.cbSaveImage.Size = new System.Drawing.Size(138, 17);
            this.cbSaveImage.TabIndex = 10;
            this.cbSaveImage.Text = "Save Image on Capture";
            this.cbSaveImage.UseVisualStyleBackColor = true;
            this.cbSaveImage.CheckedChanged += new System.EventHandler(this.cbSaveImage_CheckedChanged);
            // 
            // cbLinkClipboard
            // 
            this.cbLinkClipboard.AutoSize = true;
            this.cbLinkClipboard.Location = new System.Drawing.Point(6, 75);
            this.cbLinkClipboard.Name = "cbLinkClipboard";
            this.cbLinkClipboard.Size = new System.Drawing.Size(132, 17);
            this.cbLinkClipboard.TabIndex = 4;
            this.cbLinkClipboard.Text = "Copy Link to Clipboard";
            this.cbLinkClipboard.UseVisualStyleBackColor = true;
            this.cbLinkClipboard.CheckedChanged += new System.EventHandler(this.cbLinkClipboard_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(282, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Uploader";
            // 
            // cbUploadAfterCapture
            // 
            this.cbUploadAfterCapture.AutoSize = true;
            this.cbUploadAfterCapture.Location = new System.Drawing.Point(6, 29);
            this.cbUploadAfterCapture.Name = "cbUploadAfterCapture";
            this.cbUploadAfterCapture.Size = new System.Drawing.Size(125, 17);
            this.cbUploadAfterCapture.TabIndex = 7;
            this.cbUploadAfterCapture.Text = "Upload After Capture";
            this.cbUploadAfterCapture.UseVisualStyleBackColor = true;
            // 
            // txtImgurAPI
            // 
            this.txtImgurAPI.Location = new System.Drawing.Point(348, 35);
            this.txtImgurAPI.Name = "txtImgurAPI";
            this.txtImgurAPI.Size = new System.Drawing.Size(189, 20);
            this.txtImgurAPI.TabIndex = 15;
            // 
            // cbUploader
            // 
            this.cbUploader.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbUploader.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUploader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUploader.FormattingEnabled = true;
            this.cbUploader.Items.AddRange(new object[] {
            "Imgur",
            "VgyMe",
            "Gyazo"});
            this.cbUploader.Location = new System.Drawing.Point(348, 6);
            this.cbUploader.Name = "cbUploader";
            this.cbUploader.Size = new System.Drawing.Size(189, 23);
            this.cbUploader.TabIndex = 12;
            this.cbUploader.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbUploader_DrawItem);
            this.cbUploader.SelectedIndexChanged += new System.EventHandler(this.cbUploader_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(258, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "API Key";
            // 
            // tpFormStyle
            // 
            this.tpFormStyle.Controls.Add(this.cbEnableStyling);
            this.tpFormStyle.Controls.Add(this.label15);
            this.tpFormStyle.Controls.Add(this.cbButtonColor);
            this.tpFormStyle.Controls.Add(this.label14);
            this.tpFormStyle.Controls.Add(this.cbFormColor);
            this.tpFormStyle.Location = new System.Drawing.Point(4, 22);
            this.tpFormStyle.Name = "tpFormStyle";
            this.tpFormStyle.Padding = new System.Windows.Forms.Padding(3);
            this.tpFormStyle.Size = new System.Drawing.Size(543, 278);
            this.tpFormStyle.TabIndex = 3;
            this.tpFormStyle.Text = "Form Style";
            this.tpFormStyle.UseVisualStyleBackColor = true;
            // 
            // cbEnableStyling
            // 
            this.cbEnableStyling.AutoSize = true;
            this.cbEnableStyling.Location = new System.Drawing.Point(421, 6);
            this.cbEnableStyling.Name = "cbEnableStyling";
            this.cbEnableStyling.Size = new System.Drawing.Size(119, 17);
            this.cbEnableStyling.TabIndex = 6;
            this.cbEnableStyling.Text = "Enable Form Styling";
            this.cbEnableStyling.UseVisualStyleBackColor = true;
            this.cbEnableStyling.CheckedChanged += new System.EventHandler(this.cbEnableStyling_CheckedChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 39);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 13);
            this.label15.TabIndex = 5;
            this.label15.Text = "Button Color";
            // 
            // cbButtonColor
            // 
            this.cbButtonColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbButtonColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbButtonColor.Enabled = false;
            this.cbButtonColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbButtonColor.FormattingEnabled = true;
            this.cbButtonColor.Location = new System.Drawing.Point(117, 34);
            this.cbButtonColor.Name = "cbButtonColor";
            this.cbButtonColor.Size = new System.Drawing.Size(197, 23);
            this.cbButtonColor.TabIndex = 4;
            this.cbButtonColor.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbButtonColor_DrawItem);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 13);
            this.label14.TabIndex = 3;
            this.label14.Text = "Form Color";
            // 
            // cbFormColor
            // 
            this.cbFormColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFormColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFormColor.Enabled = false;
            this.cbFormColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFormColor.FormattingEnabled = true;
            this.cbFormColor.Location = new System.Drawing.Point(117, 5);
            this.cbFormColor.Name = "cbFormColor";
            this.cbFormColor.Size = new System.Drawing.Size(197, 23);
            this.cbFormColor.TabIndex = 2;
            this.cbFormColor.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbFormColor_DrawItem);
            // 
            // cbSaveDeletionURL
            // 
            this.cbSaveDeletionURL.AutoSize = true;
            this.cbSaveDeletionURL.Location = new System.Drawing.Point(419, 35);
            this.cbSaveDeletionURL.Name = "cbSaveDeletionURL";
            this.cbSaveDeletionURL.Size = new System.Drawing.Size(118, 17);
            this.cbSaveDeletionURL.TabIndex = 25;
            this.cbSaveDeletionURL.Text = "Save Deletion URL";
            this.cbSaveDeletionURL.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 357);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.tabControl1.ResumeLayout(false);
            this.tpGeneral.ResumeLayout(false);
            this.tpGeneral.PerformLayout();
            this.tpDesign.ResumeLayout(false);
            this.tpDesign.PerformLayout();
            this.tpScreenshot.ResumeLayout(false);
            this.tpScreenshot.PerformLayout();
            this.tpFormStyle.ResumeLayout(false);
            this.tpFormStyle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpGeneral;
        private System.Windows.Forms.TabPage tpDesign;
        private System.Windows.Forms.CheckBox cbStartup;
        private System.Windows.Forms.CheckBox cbSounds;
        private System.Windows.Forms.ComboBox cbBeforeCapture;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbWhileCapture;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbPenColor;
        private System.Windows.Forms.CheckBox cbLinkClipboard;
        private System.Windows.Forms.CheckBox cbImageClipboard;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbFontColor;
        private System.Windows.Forms.CheckBox cbPenBorder;
        private System.Windows.Forms.CheckBox cbShowPen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbPenStyle;
        private System.Windows.Forms.CheckBox cbUploadAfterCapture;
        private System.Windows.Forms.CheckBox cbMinimizeForm;
        private System.Windows.Forms.CheckBox cbIconsOnButtons;
        private System.Windows.Forms.CheckedListBox cblbIconPacks;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbSaveImage;
        private System.Windows.Forms.CheckBox cbEnableNotifications;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbUploader;
        private System.Windows.Forms.TextBox txtImgurAPI;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbPreviewWindow;
        private System.Windows.Forms.CheckBox cbMinimize;
        private System.Windows.Forms.TextBox txtGyazoAPI;
        private System.Windows.Forms.CheckBox cbScreenshot;
        private System.Windows.Forms.CheckBox cbMultiMonitor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tpScreenshot;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtScreenshotLocation;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnFullHotKey;
        private System.Windows.Forms.Button btnWindowHotKey;
        private System.Windows.Forms.Button btnAreaHotKey;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox cbOpenAfterCapture;
        private System.Windows.Forms.TabPage tpFormStyle;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbFormColor;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbButtonColor;
        private System.Windows.Forms.CheckBox cbEnableStyling;
        private System.Windows.Forms.CheckBox cbSaveDeletionURL;
    }
}