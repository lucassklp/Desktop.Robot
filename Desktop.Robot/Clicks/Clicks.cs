using System;
using System.Runtime.InteropServices;

namespace Desktop.Robot.Clicks
{
    public static class Mouse
    {
        public static IClick RightButton()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return new OSX.RightClick();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return new Windows.RightClick();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return new Linux.RightClick();
            }
            else
            {
                throw new PlatformNotSupportedException();
            }
        }

        public static IClick LeftButton()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return new OSX.LeftClick();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return new Windows.LeftClick();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return new Linux.LeftClick();
            }
            else
            {
                throw new PlatformNotSupportedException();
            }
        }
    }
}
