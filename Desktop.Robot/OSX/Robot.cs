using System;
using System.Drawing;
using System.IO;
using System.Linq;
using Desktop.Robot.Clicks;
using System.Runtime.InteropServices;
using System.Threading;

namespace Desktop.Robot.OSX
{
    public class Robot : IRobot
    {
        private Point position;
        public Robot()
        {
            position = new Point();
        }

        public uint AutoDelay { get; set; }

        public void Click(IClick click)
        {
            ApplyAutoDelay();
            click.ExecuteClick(new MouseContext(this.position));
        }

        public Image CreateScreenCapture(Rectangle screenRect)
        {
            throw new NotImplementedException();
        }

        public void Delay(int ms)
        {
            Thread.Sleep(ms);
        }

        public Color GetPixelColor(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void KeyPress(char keycode)
        {
            ApplyAutoDelay();
            type(keycode);
        }

        public void MouseMove(uint x, uint y)
        {
            this.position.X = (int)x;
            this.position.Y = (int)y;
            ApplyAutoDelay();
            setMousePosition(x, y);
        }

        private void ApplyAutoDelay()
        {
            if(AutoDelay > 0)
            {
                Thread.Sleep((int)AutoDelay);
            }
        }

        public Point GetMousePosition()
        {
            var pos = Marshal.PtrToStringAnsi(getMousePosition());
            var coords = pos.Split(";")
                .Select(x => Convert.ToInt32(x))
                .ToArray();

            var res = Marshal.PtrToStringAnsi(screenResolution());
            var screenRes = res.Split("x")
                .Select(x => Convert.ToInt32(x))
                .ToArray();

            return new Point(coords[0], screenRes[1] - coords[1]);
        }

        [DllImport("./macos.os", EntryPoint = "setMousePosition")]
        private static extern void setMousePosition(uint x, uint y);

        [DllImport("./macos.os", EntryPoint = "getMousePosition")]
        private static extern IntPtr getMousePosition();

        [DllImport("./macos.os", EntryPoint = "screenResolution")]
        private static extern IntPtr screenResolution();

        [DllImport("./macos.os", EntryPoint = "type")]
        private static extern void type(char ch);

    }
}
