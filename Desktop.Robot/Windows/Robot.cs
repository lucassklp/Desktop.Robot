using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;

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

		public override void MouseMove(int x, int y)
		{
			ApplyAutoDelay();
			SetCursorPos(x, y);
		}

        public override void MouseScroll(int value)
        {
            ApplyAutoDelay();
			DoMouseScroll(value * 100);
        }

        public override void MouseScroll(int value, TimeSpan duration)
        {
			MouseScroll(value, duration, 10);
        }

        public override void MouseScroll(int value, TimeSpan duration, int steps)
        {
            ApplyAutoDelay();
            for (int i = 0; i < steps; i++)
            {
                Thread.Sleep(duration / steps);
				DoMouseScroll(value * 100 / steps);
            }
        }

        private void DoMouseScroll(int value)
		{
			var inputs = new[]
			{
				new Input
				{
					Type = InputType.Mouse,
					MouseInputWithUnion = new MouseInput(value / 10, MouseState.MouseWheelUpDown)
				}
			};

            SendInput(1, inputs, Marshal.SizeOf(inputs[0]));
        }

        [DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool SetCursorPos(int x, int y);


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
		private struct Input : IEquatable<Input>
		{
			public InputType Type { get; set; }
			public MouseInput MouseInputWithUnion { get; set; }

			public bool Equals(Input other)
			{
				return this.Type == other.Type
					? this.MouseInputWithUnion.Equals(other.MouseInputWithUnion)
					: false;
			}
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct MouseInput : IEquatable<MouseInput>
		{
			readonly int dx;
			readonly int dy;
			readonly int mouseData;
			readonly MouseState dwFlags;
			readonly int time;
			readonly nint dwExtraInfo;
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

			public MouseInput(int scroll, MouseState dwFlags, int duration)
			{
				dx = 0;
				dy = 0;
				mouseData = scroll;
				this.dwFlags = dwFlags;
				time = duration;
				dwExtraInfo = 0;
			}


        public bool Equals(MouseInput other)
			{
				return this.dwFlags == other.dwFlags
					? this.mouseData == other.mouseData
					: false;
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
	}
}
