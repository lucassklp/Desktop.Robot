using Desktop.Robot.Clicks;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Desktop.Robot
{
    public abstract class AbstractRobot : IRobot
    {
        public uint AutoDelay { get; set; }

        public abstract Image CreateScreenCapture(Rectangle screenRect);

        public abstract Point GetMousePosition();

        public abstract Color GetPixelColor(uint x, uint y);

        public abstract void KeyPress(Key key);

        public abstract void KeyPress(char key);

        public abstract void KeyDown(Key key);

        public abstract void KeyDown(char key);

        public abstract void KeyUp(Key key);

        public abstract void KeyUp(char key);

        public abstract void MouseMove(uint x, uint y);


        public void Click(IClick click)
        {
            ApplyAutoDelay();
            click.ExecuteClick(new MouseContext(GetMousePosition()));
        }

        public void Delay(uint ms)
        {
            Thread.Sleep((int)ms);
        }

        protected void ApplyAutoDelay()
        {
            if (AutoDelay > 0)
            {
                Thread.Sleep((int)AutoDelay);
            }
        }

    }
}
