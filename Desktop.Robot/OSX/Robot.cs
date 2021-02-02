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
        public uint AutoDelay { get; set; }

        public void Click(IClick click)
        {
            ApplyAutoDelay();
            click.ExecuteClick(new MouseContext(GetMousePosition()));
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

        public void KeyPress(int keycode)
        {
            ApplyAutoDelay();
            sendCommand((ushort)keycode);
        }
        public void KeyDown(int keycode)
        {
            ApplyAutoDelay();
            sendCommandDown((ushort)keycode);
        }

        public void KeyUp(int keycode)
        {
            ApplyAutoDelay();
            sendCommandUp((ushort)keycode);
        }

        public void MouseMove(uint x, uint y)
        {
            ApplyAutoDelay();
            setMousePosition(x, y);
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


        private void ApplyAutoDelay()
        {
            if(AutoDelay > 0)
            {
                Thread.Sleep((int)AutoDelay);
            }
        }

        [DllImport("./macos.os", EntryPoint = "setMousePosition")]
        private static extern void setMousePosition(uint x, uint y);

        [DllImport("./macos.os", EntryPoint = "getMousePosition")]
        private static extern IntPtr getMousePosition();

        [DllImport("./macos.os", EntryPoint = "screenResolution")]
        private static extern IntPtr screenResolution();

        [DllImport("./macos.os", EntryPoint = "keyPress")]
        private static extern void keyPress(int ch);

        [DllImport("./macos.os", EntryPoint = "keyUp")]
        private static extern void keyUp(int ch);

        [DllImport("./macos.os", EntryPoint = "keyDown")]
        private static extern void keyDown(int ch);

        [DllImport("./macos.os", EntryPoint = "sendCommand")]
        private static extern void sendCommand(ushort ch);

        [DllImport("./macos.os", EntryPoint = "sendCommandUp")]
        private static extern void sendCommandUp(ushort ch);


        [DllImport("./macos.os", EntryPoint = "sendCommandDown")]
        private static extern void sendCommandDown(ushort ch);
    }
}
