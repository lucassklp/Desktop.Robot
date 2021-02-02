using System;
using System.Threading;

namespace Desktop.Robot.Clicks.Windows
{
    internal class RightClick : IClick
    {
        private int delay;
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
