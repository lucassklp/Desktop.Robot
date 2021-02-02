using System;
using System.Drawing;

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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
