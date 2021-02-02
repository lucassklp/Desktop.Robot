using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Desktop.Robot.Windows
{
    public class Robot : AbstractRobot
    {

        public override Image CreateScreenCapture(Rectangle screenRect)
        {
            throw new NotImplementedException();
        }

        public override Point GetMousePosition()
        {
            PointInter lpPoint;
            GetCursorPos(out lpPoint);
            return (Point)lpPoint;
        }

        public override Color GetPixelColor(uint x, uint y)
        {
            throw new NotImplementedException();
        }

        public override void KeyDown(Key key)
        {
            throw new NotImplementedException();
        }

        public override void KeyDown(char key)
        {
            throw new NotImplementedException();
        }


        public override void KeyPress(Key key)
        {
            throw new NotImplementedException();
        }

        public override void KeyPress(char key)
        {
            throw new NotImplementedException();
        }

        public override void KeyUp(Key key)
        {
            throw new NotImplementedException();
        }

        public override void KeyUp(char key)
        {
            throw new NotImplementedException();
        }

        public override void MouseMove(uint x, uint y)
        {
            ApplyAutoDelay();
            SetCursorPos(x, y);
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetCursorPos(uint x, uint y);


        [StructLayout(LayoutKind.Sequential)]
        public struct PointInter
        {
            public int X;
            public int Y;
            public static explicit operator Point(PointInter point) => new Point(point.X, point.Y);
        }

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out PointInter lpPoint);


        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);


    }
}
