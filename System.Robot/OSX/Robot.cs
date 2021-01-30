﻿using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Robot.Clicks;
using System.Runtime.InteropServices;
using System.Threading;

namespace System.Robot.OSX
{
    public class Robot : IRobot
    {
        private Point position;
        public Robot()
        {
            position = new Point();
        }

        public uint AutoDelay { get; set; } = 0;

        public void Click(IClick click)
        {
            ApplyAutoDelay();
            click.ExecuteClick(new MouseContext(this.position));
        }

        public Image CreateScreenCapture(Rectangle screenRect)
        {
            using var bitmap = new Bitmap(screenRect.Width, screenRect.Height);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(0, 0, 0, 0, bitmap.Size, CopyPixelOperation.SourceCopy);
            }
            return bitmap;
        }

        public void Delay(int ms)
        {
            Thread.Sleep(ms);
        }

        public Color GetPixelColor(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void KeyPress(char keycode)
        {
            throw new NotImplementedException();
        }

        public void MouseMove(uint x, uint y)
        {
            this.position.X = (int)x;
            this.position.Y = (int)y;
            ApplyAutoDelay();
            setMousePosition(x, y);
        }

        private void ApplyAutoDelay()
        {
            if(AutoDelay > 0)
            {
                Thread.Sleep((int)AutoDelay);
            }
        }

        public Point GetMousePosition()
        {
            var pos = getMousePosition();
            var str = Marshal.PtrToStringAnsi(pos);
            var coords = str.Split(";")
                .Select(x => Convert.ToInt32(x))
                .ToArray();
            return new Point(coords[0], coords[1]);
        }

        [DllImport("./macos.os", EntryPoint = "setMousePosition")]
        private static extern void setMousePosition(uint x, uint y);

        [DllImport("./macos.os", EntryPoint = "getMousePosition")]
        private static extern IntPtr getMousePosition();


    }
}