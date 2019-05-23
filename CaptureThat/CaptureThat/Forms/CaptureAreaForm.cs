/*
 * Copyright (c) 2016-2019 Russ 'trdwll' Treadwell. All rights reserved.
 * Licensed under the MIT License. See LICENSE.md file in the project root for full license information.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CaptureThat
{
    public partial class CaptureAreaForm : Form
    {
        public Point lastLoc;
        public Size lastSize;

        bool mouseDown = false;
        Point mouseDownPoint = Point.Empty;
        Point mousePoint = Point.Empty;
        MainForm mainform;
        Pen pen;
        Pen pen2;
        Rectangle bounds = new Rectangle();

        public CaptureAreaForm(MainForm mainform)
        {
            this.mainform = mainform;
            InitializeComponent();

            TopMost = true;
            Opacity = .30;
            TransparencyKey = Color.White;
            Location = new Point(0, 0);
            DoubleBuffered = true;

            if (Config.conf.ShowPenBeforeCapture)
            {
                pen = new Pen(Color.FromName(Config.conf.PenColor), 3);
                pen.DashStyle = Config.conf.PenStyle;
            }

            if (Config.conf.ShowPenToBorderSelection)
            {
                pen2 = new Pen(Color.FromName(Config.conf.PenColor), 2);
                pen2.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            }

            int maxX = 0;
            int maxY = 0;

            foreach (Screen screen in Screen.AllScreens)
            {
                int x = screen.Bounds.X + screen.Bounds.Width;
                if (x > maxX)
                {
                    maxX = x;
                }

                int y = screen.Bounds.Y + screen.Bounds.Height;
                if (y > maxY)
                {
                    maxY = y;
                }
            }

            bounds.X = 0;
            bounds.Y = 0;
            bounds.Width = maxX;
            bounds.Height = maxY;

            Size = new Size(bounds.Width, bounds.Height);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            mouseDown = true;
            mousePoint = mouseDownPoint = e.Location;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            mouseDown = false;

            lastLoc = new Point(Math.Min(mouseDownPoint.X, mousePoint.X), Math.Min(mouseDownPoint.Y, mousePoint.Y));
            lastSize = new Size(Math.Abs(mouseDownPoint.X - mousePoint.X), Math.Abs(mouseDownPoint.Y - mousePoint.Y));

            if (e.Button == MouseButtons.Right)
            {
                mainform.Show();
            }

            Close();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            mousePoint = e.Location;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Region region = new Region(bounds);

            if (mouseDown)
            {
                Rectangle selectionWindow = new Rectangle(
                    Math.Min(mouseDownPoint.X, mousePoint.X), Math.Min(mouseDownPoint.Y, mousePoint.Y),
                    Math.Abs(mouseDownPoint.X - mousePoint.X), Math.Abs(mouseDownPoint.Y - mousePoint.Y));

                region.Xor(selectionWindow);
                
                e.Graphics.FillRegion(new SolidBrush(Color.FromName(Config.conf.BeforeCaptureColor)), region);

                if (Config.conf.ShowPenToBorderSelection)
                {
                    pen2.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                    e.Graphics.DrawRectangle(pen2, selectionWindow);
                }

                Font font = new Font(new FontFamily(Config.conf.FontFamily), Config.conf.FontSize);

                // TODO: Make the size of the image display where the mouse isn't 
                // so it's always viewable and out of the selectionWindow
                Rectangle rightRect = new Rectangle(Screen.PrimaryScreen.WorkingArea.Width - 64, 0, 64, bounds.Height);
                string size = $"W: {selectionWindow.Width}\nH: {selectionWindow.Height}";

                SolidBrush fontcolor = new SolidBrush(Color.FromName(Config.conf.FontColor));

                if (rightRect.Contains(Cursor.Position))
                {
                    e.Graphics.DrawString(size, font, fontcolor, new Point(mousePoint.X - 100, mousePoint.Y + 64));
                }
                else
                {
                    e.Graphics.DrawString(size, font, fontcolor, new Point(mousePoint.X + 10, mousePoint.Y + 64));
                }
            }
            else
            {
                e.Graphics.FillRegion(new SolidBrush(Color.FromName(Config.conf.WhileCaptureColor)), region);
                if (Config.conf.ShowPenBeforeCapture)
                {
                    e.Graphics.DrawLine(pen, mousePoint.X, 0, mousePoint.X, Size.Height);
                    e.Graphics.DrawLine(pen, 0, mousePoint.Y, Size.Width, mousePoint.Y);
                }
            }
        }
    }
}
