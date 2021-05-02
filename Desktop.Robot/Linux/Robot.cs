using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;

namespace Desktop.Robot.Linux
{
    public class Robot : AbstractRobot
    {
        public override Image CreateScreenCapture(Rectangle screenRect)
        {
            throw new NotImplementedException();
        }

        public override Point GetMousePosition()
        {
            var pos = Marshal.PtrToStringAnsi(getMousePosition());
            var coords = pos.Split("x")
                .Select(x => Convert.ToInt32(x))
                .ToArray();

            return new Point(coords[0], coords[1]);
        }

        public override Color GetPixelColor(uint x, uint y)
        {
            throw new NotImplementedException();
        }

        public override void KeyDown(Key key)
        {
            ApplyAutoDelay();
            pressKeyCode((int)key.GetKeycode(), false, key.GetScanCode());
        }

        public override void KeyDown(char key)
        {
            ApplyAutoDelay();
            var flags = Char.IsUpper(key) ? (1 << 0) : 0;
            pressKey(key, true, flags);
        }

        public override void KeyPress(Key key)
        {
            ApplyAutoDelay();
            pressKeyCode((int)key.GetKeycode(), true, key.GetScanCode());
            pressKeyCode((int)key.GetKeycode(), false, key.GetScanCode());
        }

        public override void KeyPress(char key)
        {
            ApplyAutoDelay();
            var flags = Char.IsUpper(key) ? (1 << 0) : 0;
            pressKey(key, true, flags);
            pressKey(key, false, flags);
        }

        public override void KeyUp(Key key)
        {
            ApplyAutoDelay();
            pressKeyCode((int)key.GetKeycode(), false, key.GetScanCode());
        }

        public override void KeyUp(char key)
        {
            ApplyAutoDelay();
            var flags = Char.IsUpper(key) ? (1 << 0) : 0;
            pressKey(key, false, flags);
        }
        public override void MouseMove(uint x, uint y)
        {
            ApplyAutoDelay();
            moveMouse((int)x, (int)y);
        }


        [DllImport("./x11.os", EntryPoint = "moveMouse")]
        private static extern IntPtr moveMouse(int x, int y);

        [DllImport("./x11.os", EntryPoint = "click")]
        private static extern IntPtr click(bool down, int button);


        [DllImport("./x11.os", EntryPoint = "getMousePosition")]
        private static extern IntPtr getMousePosition();


        [DllImport("./x11.os", EntryPoint = "pressKey")]
        private static extern IntPtr pressKey(char c, bool down, int flags);


        [DllImport("./x11.os", EntryPoint = "pressKeyCode")]
        private static extern IntPtr pressKeyCode(int code, bool down, int flags);


    }
}
