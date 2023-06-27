using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Desktop.Robot.Windows
{
    public class Robot : AbstractRobot
    {
        public override Point GetMousePosition()
        {
            PointInter lpPoint;
            GetCursorPos(out lpPoint);
            return (Point)lpPoint;
        }

        public override void KeyDown(Key key)
        {
            ApplyAutoDelay();
            var metadata = key.GetKeycode();
            var keycode = (byte)metadata.Keycode;
            var scancode = (byte)metadata.ScanCode;
            keybd_event(keycode, scancode, 0, 0);
        }

        public override void KeyDown(char key)
        {
            ApplyAutoDelay();
            var keycode = (byte)VkKeyScan(key);
            keybd_event(keycode, 0, 0, 0);
        }

        public override void KeyPress(Key key)
        {
            ApplyAutoDelay();
            var metadata = key.GetKeycode();
            var keycode = (byte)metadata.Keycode;
            var scancode = (byte)metadata.ScanCode;
            keybd_event(keycode, scancode, 0, 0);
            keybd_event(keycode, scancode, 2, 0);
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
            var metadata = key.GetKeycode();
            var keycode = (byte)metadata.Keycode;
            var scancode = (byte)metadata.ScanCode;
            keybd_event(keycode, scancode, 2, 0);
        }

        public override void KeyUp(char key)
        {
            ApplyAutoDelay();
            var keycode = (byte)VkKeyScan(key);
            keybd_event(keycode, 0, 2, 0);
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

		[DllImport("user32.dll", SetLastError = true)]
		private static extern uint SendInput(uint inputCount, Input[] input, int size);

		[StructLayout(LayoutKind.Sequential)]
		private struct Input
		{
			public InputType Type { get; set; }
			public MouseInput MouseInputWithUnion { get; set; }
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct MouseInput
		{
			int dx;
			int dy;
			int mouseData;
			MouseState dwFlags;
			int time;
			nint dwExtraInfo;
			public MouseInput(MouseState dwFlags)
			{
                dx = 0;
                dy = 0;
				mouseData = 0;
				this.dwFlags = dwFlags;
                time = 0;
                dwExtraInfo = 0;
			}

			public MouseInput(int scroll, MouseState dwFlags)
			{
				dx = 0;
                dy = 0;
				mouseData = scroll;
				this.dwFlags = dwFlags;
                time = 0;
                dwExtraInfo = 0;
			}
		}

		[Flags]
		public enum MouseState : uint
		{
			LeftDown = 2,
			LeftUp = 4,
			MiddleDown = 32,
			MiddleUp = 64,
			Move = 1,
			Absolute = 32768,
			RightDown = 8,
			RightUp = 16,
			MouseWheelUpDown = 2048,
			MouseWheelLeftRight = 4096
		}

		public enum InputType : uint
		{
			Mouse = 0,
			Keyboard = 1,
			Hardware = 3
		}

		public override void MouseScrollVertical(int value)
		{
			var input = new Input
			{
				Type = InputType.Mouse,
				MouseInputWithUnion = new MouseInput(value, MouseState.MouseWheelUpDown)
			};
            var responce = SendInput(1, new Input[] { input }, Marshal.SizeOf(input));
			if (responce == 0)
				throw new Exception();
		}
	}
}
