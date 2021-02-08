using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;

namespace Desktop.Robot.OSX
{
    public class Robot : AbstractRobot
    {

        public override Image CreateScreenCapture(Rectangle screenRect)
        {
            throw new NotImplementedException();
        }


        public override Color GetPixelColor(uint x, uint y)
        {
            throw new NotImplementedException();
        }

        public override void KeyDown(Key key)
        {
            ApplyAutoDelay();
            sendCommandDown(key.GetKeycode());
        }

        public override void KeyDown(char key)
        {
            ApplyAutoDelay();
            keyDown(key);
        }

        public override void KeyPress(Key key)
        {
            ApplyAutoDelay();
            sendCommand(key.GetKeycode());
        }

        public override void KeyPress(char key)
        {
            ApplyAutoDelay();
            keyPress(key);
        }

        public override void KeyUp(Key key)
        {
            ApplyAutoDelay();
            sendCommandUp(key.GetKeycode());
        }

        public override void KeyUp(char key)
        {
            ApplyAutoDelay();
            keyUp(key);
        }

        public override void MouseMove(uint x, uint y)
        {
            ApplyAutoDelay();
            setMousePosition(x, y);
        }

        public override Point GetMousePosition()
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

        [DllImport("./macos.os", EntryPoint = "keyPress")]
        private static extern void keyPress(char ch);

        [DllImport("./macos.os", EntryPoint = "keyUp")]
        private static extern void keyUp(char ch);

        [DllImport("./macos.os", EntryPoint = "keyDown")]
        private static extern void keyDown(char ch);

        [DllImport("./macos.os", EntryPoint = "sendCommand")]
        private static extern void sendCommand(ushort ch);

        [DllImport("./macos.os", EntryPoint = "sendCommandUp")]
        private static extern void sendCommandUp(ushort ch);

        [DllImport("./macos.os", EntryPoint = "sendCommandDown")]
        private static extern void sendCommandDown(ushort ch);
    }
}
