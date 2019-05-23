/*
 * Copyright (c) 2016-2019 Russ 'trdwll' Treadwell. All rights reserved.
 * Licensed under the MIT License. See LICENSE.md file in the project root for full license information.
 */
using System;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Linq;
using apollo.Core;

namespace CaptureThat
{
    public class Config
    {
        public static Mode mode = Serialization.JSON.Deserialize.getFromFile<Mode>($@"{Application.StartupPath}\mode.json");

        public static readonly string AppUpdateURL = "https://trdwll.com/f/CaptureThatVersion.txt";

        public static readonly string MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static readonly string MyPictures = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        public static readonly string AppSettingsPath = mode.PortableMode ? Application.StartupPath : $@"{MyDocuments}\CaptureThat";
        public static readonly string ConfigFile = $@"{AppSettingsPath}\config.json";

        public const string AppVersion = "2.4";
        public static Version AssemblyVersion = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;

        public static C conf = Serialization.JSON.Deserialize.getFromFile<C>(ConfigFile);
   
        public class C
        {
            public int ConfigVersion = 7;

            public bool RunOnWindowsStartup = true;
            public bool MinimizeFormOnStartup = true;
            public bool ForceIconsOnButtons = true;
            public bool EnableSounds = true;
            public bool EnableNotifications = true;
            public bool ShowPreviewWindow = false;
            public bool ExitMinimize = true;

            public bool SingleClickScreenshot = false;
            public bool MultiMonitorScreenshot = true;
            
            public string Uploader = "Imgur";
            public bool SaveDeletionUrl = true;
            public string ImgurAPI = "b70e5f1ee4c4313";
            public string GyazoAPI = "13cfc8a8cffc936a9d981dc99079f1af79ee7e0d7029bd23cfbf8015d602d83a";

            public string IconPackName = "default";

            public bool UploadImageAfterCapture = true;
            public bool OpenURLAfterCapture = false;

            public bool SaveImageOnCapture = true;
            public string ScreenshotSavePath = $@"{MyPictures}\Screenshots";

            public bool CopyImageToClipboard = false;
            public bool CopyLinkToClipboard = true;

            public string BeforeCaptureColor = "Black";
            public string WhileCaptureColor = "LightGray";

            public string FontFamily = "Arial"; // Needs implemented
            public float FontSize = 12.0F; // Needs implemented
            public string FontColor = "White"; // Needs implemented

            public bool ShowPenBeforeCapture = true;
            public bool ShowPenToBorderSelection = true;
            public string PenColor = "Green";
            public DashStyle PenStyle = DashStyle.Dash; // Add "marching ants" as option

            public Style FormStyle = new Style();

            public HotKeys Keys = new HotKeys();
        }

        public class Style
        {
            public bool EnableStyling = false;
            public string FormBackgroundColor = "Control";
            public string ButtonColor = "Control";
        }

        public class HotKeys
        {
            public class Key
            {
                public string Keys;
                public bool Control;
                public bool Alt;
                public bool Shift;

                public void setModifiers(bool[] modifiers)
                {
                    if (modifiers == null || modifiers.Length != 3)
                    {
                        throw new ArgumentException("Key modifiers must consist of the three modifiers");
                    }

                    Control = modifiers[0];
                    Alt = modifiers[1];
                    Shift = modifiers[2];
                }

                public bool[] getModifiers()
                {
                    return new bool[] { Control, Alt, Shift };
                }

                public override string ToString()
                {
                    return parseHotKeyModifiersToString(Control, Alt, Shift);
                }

                public static string parseHotKeyModifiersToString(bool Control, bool Alt, bool Shift)
                {
                    string x = Control ? "Control" : "";
                    string y = Alt ? "Alt" : "";
                    string z = Shift ? "Shift" : "";

                    return string.Join("+", new string[] { x, y, z }.Where(m => !IO.isEmpty(m)));
                }
            }

            public Key AreaCaptureHotKey = new Key()
            {
                Keys = "C",
                Control = true,
                Alt = false,
                Shift = true
            };

            public Key WindowCaptureHotKey = new Key()
            {
                Keys = "X",
                Control = true,
                Alt = false,
                Shift = true
            };

            public Key FullCaptureHotKey = new Key()
            {
                Keys = "Q",
                Control = true,
                Alt = false,
                Shift = true
            };
        }

        public class Mode
        {
            public bool SecurityMode = false;
            public bool PortableMode = false;
        }
    }
}
