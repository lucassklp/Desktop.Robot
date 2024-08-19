using System.Runtime.InteropServices;

namespace Desktop.Robot.Clicks.OSX.ARM
{
    static class Common
    {
        [DllImport("./osx_arm.os", EntryPoint = "rightMouseUp")]
        internal static extern void RightClickUp(uint x, uint y);

        [DllImport("./osx_arm.os", EntryPoint = "rightMouseDown")]
        internal static extern void RightClickDown(uint x, uint y);


        [DllImport("./osx_arm.os", EntryPoint = "leftMouseUp")]
        internal static extern void LeftClickUp(uint x, uint y);

        [DllImport("./osx_arm.os", EntryPoint = "leftMouseDown")]
        internal static extern void LeftClickDown(uint x, uint y);


        [DllImport("./osx_arm.os", EntryPoint = "otherMouseUp")]
        internal static extern void OtherClickUp(uint x, uint y);

        [DllImport("./osx_arm.os", EntryPoint = "otherMouseDown")]
        internal static extern void OtherClickDown(uint x, uint y);
    }
}
