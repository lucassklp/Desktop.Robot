using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Desktop.Robot.Clicks.OSX
{
    class Common
    {
        [DllImport("./macos.os", EntryPoint = "rightMouseUp")]
        internal static extern void RightClickUp(uint x, uint y);

        [DllImport("./macos.os", EntryPoint = "rightMouseDown")]
        internal static extern void RightClickDown(uint x, uint y);


        [DllImport("./macos.os", EntryPoint = "leftMouseUp")]
        internal static extern void LeftClickUp(uint x, uint y);

        [DllImport("./macos.os", EntryPoint = "leftMouseDown")]
        internal static extern void LeftClickDown(uint x, uint y);
    }
}
