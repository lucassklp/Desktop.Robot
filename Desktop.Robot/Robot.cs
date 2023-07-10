using System.Drawing;
using Desktop.Robot.Clicks;
using System.Runtime.InteropServices;
using System;

namespace Desktop.Robot
{
    public class Robot : IRobot
    {
        private readonly IRobot robot;

        public Robot()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                robot = RuntimeInformation.ProcessArchitecture == Architecture.Arm64 ? 
                    new OSX.Arm.Robot() : new OSX.Intel.Robot();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                robot = new Windows.Robot();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                robot = new Linux.Robot();
            }
            else
            {
                throw new PlatformNotSupportedException();
            }
        }

        public int AutoDelay { get => robot.AutoDelay; set => robot.AutoDelay = value; }

        public void Click(IClick click)
        {
            robot.Click(click);
        }

        public Image CreateScreenCapture(Rectangle screenRect)
        {
            return robot.CreateScreenCapture(screenRect);
        }

        public void Delay(int ms)
        {
            robot.Delay(ms);
        }

        public Point GetMousePosition()
        {
            return robot.GetMousePosition();
        }

        public Color GetPixelColor(int x, int y)
        {
            return robot.GetPixelColor(x, y);
        }

        public void KeyDown(Key key)
        {
            robot.KeyDown(key);
        }

        public void KeyDown(char key)
        {
            robot.KeyDown(key);
        }


        public void KeyPress(Key key)
        {
            robot.KeyPress(key);
        }

        public void KeyPress(char key)
        {
            robot.KeyPress(key);
        }

        public void KeyUp(Key key)
        {
            robot.KeyUp(key);
        }

        public void KeyUp(char key)
        {
            robot.KeyUp(key);
        }

        public void MouseDown(IClick click)
        {
            robot.MouseDown(click);
        }

        public void MouseMove(int x, int y)
        {
            robot.MouseMove(x, y);
        }

        public void MouseMove(Point p)
        {
            robot.MouseMove(p);
        }

        public void MouseScroll(int value)
        {
            robot.MouseScroll(-1 * value);
        }

        public void MouseScroll(int value, TimeSpan duration)
        {
            robot.MouseScroll(-1 * value, duration);
        }

        public void MouseScroll(int value, TimeSpan duration, int steps)
        {
            robot.MouseScroll(-1 * value, duration, steps); 
        }

        public void MouseUp(IClick click)
        {
            robot.MouseUp(click);
        }
    }
}