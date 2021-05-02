﻿using System.Runtime.InteropServices;

namespace Desktop.Robot.Clicks.OSX
{
    static class Common
    {
        [DllImport("./osx.os", EntryPoint = "rightMouseUp")]
        internal static extern void RightClickUp(uint x, uint y);

        [DllImport("./osx.os", EntryPoint = "rightMouseDown")]
        internal static extern void RightClickDown(uint x, uint y);


        [DllImport("./osx.os", EntryPoint = "leftMouseUp")]
        internal static extern void LeftClickUp(uint x, uint y);

        [DllImport("./osx.os", EntryPoint = "leftMouseDown")]
        internal static extern void LeftClickDown(uint x, uint y);
    }
}
