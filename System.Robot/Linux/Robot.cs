using System;
using System.Drawing;
using System.Robot.Clicks;

namespace System.Robot.Linux
{
    public class Robot : IRobot
    {
        public uint AutoDelay { get; set; }

        public void Click(IClick click)
        {
            throw new NotImplementedException();
        }

        public Image CreateScreenCapture(Rectangle screenRect)
        {
            throw new NotImplementedException();
        }

        public void Delay(int ms)
        {
            throw new NotImplementedException();
        }

        public Point GetMousePosition()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
