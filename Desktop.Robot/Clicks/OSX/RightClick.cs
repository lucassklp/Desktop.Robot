using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Desktop.Robot.Clicks.OSX
{
    internal class RightClick : IClick
    {
        private readonly int delay;
        public RightClick(int delay)
        {
            this.delay = delay;
        }

        public void ExecuteClick(MouseContext context)
        {
            Common.RightClickUp((uint)context.Position.X, (uint)context.Position.Y);
            Thread.Sleep(delay);
            Common.RightClickDown((uint)context.Position.X, (uint)context.Position.Y);
        }


    }
}
