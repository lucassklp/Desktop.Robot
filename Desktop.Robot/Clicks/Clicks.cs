using System;
using System.Runtime.InteropServices;

namespace Desktop.Robot.Clicks
{
    public static class Mouse
    {
        public static IClick RightButton()
        {
            return RightButton(150);
        }

        public static IClick LeftButton()
        {
            return LeftButton(150);
        }

        public static IClick RightButton(int delay)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return new OSX.RightClick(delay);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return new Windows.RightClick(delay);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return new Linux.RightClick(delay);
            }
            else
            {
                throw new PlatformNotSupportedException();
            }
        }

        public static IClick LeftButton(int delay)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return new OSX.LeftClick(delay);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return new Windows.LeftClick(delay);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return new Linux.LeftClick(delay);
            }
            else
            {
                throw new PlatformNotSupportedException();
            }
        }
    }
}
