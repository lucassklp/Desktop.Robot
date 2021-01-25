using System;
using System.Drawing;
using System.IO;
using System.Robot.Clicks;
using System.Runtime.InteropServices;

namespace System.Robot
{
    public class Robot : IRobot
    {
        public Robot()
        {
        }

        public int AutoDelay { get; set; }

        public void Click(IClick click)
        {
            throw new NotImplementedException();
        }

        public void Click()
        {
        }

        public Image CreateScreenCapture(Rectangle screenRect)
        {
            using var bitmap = new Bitmap(screenRect.Width, screenRect.Height);
            using (var g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(0, 0, 0, 0, bitmap.Size, CopyPixelOperation.SourceCopy);
            }
            return bitmap;
        }
// #if OSX
//         [DllImport("./wrapper.so", EntryPoint="main")]
//         private static extern int Main();
// #endif

// #if Linux
//         [DllImport("./wrapper_linux.so", EntryPoint="invokeJava")]
//         private static extern int Main();
// #endif

// #if Windows
//         [DllImport("./wrapper_win.so", EntryPoint="invokeJava")]
//         private static extern int Main();
// #endif
        public void Delay(int ms)
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

        public void MouseMove(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
