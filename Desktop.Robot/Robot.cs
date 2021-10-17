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
                robot = new OSX.Robot();
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

        public uint AutoDelay { get => robot.AutoDelay; set => robot.AutoDelay = value; }

        public void Click(IClick click)
        {
            robot.Click(click);
        }

        public Image CreateScreenCapture(Rectangle screenRect)
        {
            return robot.CreateScreenCapture(screenRect);
        }

        public void Delay(uint ms)
        {
            robot.Delay(ms);
        }

        public Point GetMousePosition()
        {
            return robot.GetMousePosition();
        }

        public Color GetPixelColor(uint x, uint y)
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

        public void MouseMove(uint x, uint y)
        {
            robot.MouseMove(x, y);
        }

        public void MouseMove(Point p)
        {
            robot.MouseMove(p);
        }

        public void MouseUp(IClick click)
        {
            robot.MouseUp(click);
        }
    }
}