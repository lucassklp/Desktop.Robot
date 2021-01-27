using System;
using System.Drawing;
using System.IO;
using System.Robot.Clicks;
using System.Runtime.InteropServices;
using System.Threading;

namespace System.Robot
{
    public class OSXRobot : IRobot
    {
        private uint x;
        private uint y;
        public OSXRobot()
        {
        }

        public uint AutoDelay { get; set; }

        public void Click()
        {
            leftClick(x, y);
        }

        public void RightClick()
        {
            rightClick(x, y);
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
            this.x = x;
            this.y = y;
            setMousePosition(x, y);
        }

        [DllImport("./macos.os", EntryPoint="setMousePosition")]
        private static extern void setMousePosition(uint x, uint y);

        [DllImport("./macos.os", EntryPoint="rightClick")]
        private static extern void rightClick(uint x, uint y);

        [DllImport("./macos.os", EntryPoint="leftClick")]
        private static extern void leftClick(uint x, uint y);
    }
}
