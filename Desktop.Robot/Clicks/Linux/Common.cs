using System.Runtime.InteropServices;

namespace Desktop.Robot.Clicks.Linux
{
    static class Common
    {
        internal const int LEFT_BUTTON = 1;
        internal const int CENTER_BUTTON = 2;
        internal const int RIGHT_BUTTON = 3;

        [DllImport("./x11.os", EntryPoint = "click")]
        internal static extern void Click(bool down, int button);
    }
}
