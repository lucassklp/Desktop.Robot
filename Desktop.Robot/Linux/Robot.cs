using Desktop.Robot.Clicks.Linux;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace Desktop.Robot.Linux
{
    public class Robot : AbstractRobot
    {
        public override Point GetMousePosition()
        {
            var pos = Marshal.PtrToStringAnsi(getMousePosition());
            var coords = pos.Split("x")
                .Select(x => Convert.ToInt32(x))
                .ToArray();

            return new Point(coords[0], coords[1]);
        }

        public override void KeyDown(Key key)
        {
            ApplyAutoDelay();
            var metadata = key.GetKeycode();
            pressKeyCode(metadata.Keycode, false, metadata.ScanCode);
        }

        public override void KeyDown(char key)
        {
            ApplyAutoDelay();
            var flags = char.IsUpper(key) ? (1 << 0) : 0;
            pressKey(key, true, flags);
        }

        public override void KeyPress(Key key)
        {
            ApplyAutoDelay();
            var metadata = key.GetKeycode();
            pressKeyCode(metadata.Keycode, true, metadata.ScanCode);
            pressKeyCode(metadata.Keycode, false, metadata.ScanCode);
        }

        public override void KeyPress(char key)
        {
            ApplyAutoDelay();
            var flags = char.IsUpper(key) ? (1 << 0) : 0;
            pressKey(key, true, flags);
            pressKey(key, false, flags);
        }

        public override void KeyUp(Key key)
        {
            ApplyAutoDelay();
            var metadata = key.GetKeycode();
            pressKeyCode(metadata.Keycode, false, metadata.ScanCode);
        }

        public override void KeyUp(char key)
        {
            ApplyAutoDelay();
            var flags = char.IsUpper(key) ? (1 << 0) : 0;
            pressKey(key, false, flags);
        }

        public override void MouseMove(int x, int y)
        {
            ApplyAutoDelay();
            moveMouse(x, y);
        }

        public override void MouseScrollVertical(int value)
        {
            do
            {
                if (value < 0)
                {
                    click(true, Common.UP_BUTTON);
                    Thread.Sleep(100);
                    click(false, Common.UP_BUTTON);
                    value++;
                }
                else
                {
                    click(true, Common.DOWN_BUTTON);
                    Thread.Sleep(100);
                    click(false, Common.DOWN_BUTTON);
                    value--;
                }
            }
            while (value != 0);
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
