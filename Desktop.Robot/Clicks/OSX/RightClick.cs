using System;
using System.Runtime.InteropServices;

namespace Desktop.Robot.Clicks.OSX
{
    internal class RightClick : IClick
    {
        public void ExecuteClick(MouseContext context)
        {
            rightClick((uint)context.Position.X, (uint)context.Position.Y);
        }

        [DllImport("./macos.os", EntryPoint = "rightClick")]
        private static extern void rightClick(uint x, uint y);
    }
}
