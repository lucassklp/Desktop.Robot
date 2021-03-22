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
            ApplyAutoDelay();
            var keycode = (byte)key.GetKeycode();
            keybd_event(keycode, (byte)key.GetScanCode(), 0, 0);
            Console.WriteLine($"Down -> {key}");
        }

        public override void KeyDown(char key)
        {
            ApplyAutoDelay();
            var keycode = (byte)VkKeyScan(key);
            keybd_event(keycode, 0, 0, 0);
            Console.WriteLine($"Down -> {key}");
        }

        public override void KeyPress(Key key)
        {
            ApplyAutoDelay();
            var keycode = (byte)key.GetKeycode();
            keybd_event(keycode, (byte)key.GetScanCode(), 0, 0);
            keybd_event(keycode, (byte)key.GetScanCode(), 2, 0);
        }

        public override void KeyPress(char key)
        {
            ApplyAutoDelay();
            var keycode = (byte)VkKeyScan(key);
            keybd_event(keycode, 0, 0, 0);
            keybd_event(keycode, 0, 2, 0);
        }

        public override void KeyUp(Key key)
        {
            ApplyAutoDelay();
            var keycode = (byte)key.GetKeycode();
            keybd_event(keycode, (byte)key.GetScanCode(), 2, 0);
            Console.WriteLine($"Up -> {key}");
        }

        public override void KeyUp(char key)
        {
            ApplyAutoDelay();
            var keycode = (byte)VkKeyScan(key);
            keybd_event(keycode, 0, 2, 0);
            Console.WriteLine($"Up -> {key}");
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

        [DllImport("user32.dll")]
        private static extern short VkKeyScan(char ch);


    }
}
