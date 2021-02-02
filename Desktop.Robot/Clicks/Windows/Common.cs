using System.Runtime.InteropServices;

namespace Desktop.Robot.Clicks.Windows
{
    internal static class Common
    {
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        internal static void RightClickUp(uint x, uint y)
        {
            mouse_event(MOUSEEVENTF_RIGHTUP, x, y, 0, 0);
        }

        internal static void RightClickDown(uint x, uint y)
        {
            mouse_event(MOUSEEVENTF_RIGHTDOWN, x, y, 0, 0);
        }

        internal static void LeftClickUp(uint x, uint y)
        {
            mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }

        internal static void LeftClickDown(uint x, uint y)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
        }
    }
}
