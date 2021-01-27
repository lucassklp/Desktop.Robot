using System;
using System.Runtime.InteropServices;

namespace System.Robot.Clicks.OSX
{
    internal class LeftClick : IClick
    {
        public LeftClick()
        {
        }

        public void ExecuteClick(MouseContext context)
        {
            leftClick((uint)context.Position.X, (uint)context.Position.Y);
        }

        [DllImport("./macos.os", EntryPoint = "leftClick")]
        private static extern void leftClick(uint x, uint y);
    }
}
