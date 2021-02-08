using System;
using System.Threading;

namespace Desktop.Robot.Clicks.Windows
{
    internal class LeftClick : IClick
    {
        private readonly int delay;
        public LeftClick(int delay)
        {
            this.delay = delay;
        }
        public void ExecuteClick(MouseContext context)
        {
            Common.LeftClickDown((uint)context.Position.X, (uint)context.Position.Y);
            Thread.Sleep(delay);
            Common.LeftClickUp((uint)context.Position.X, (uint)context.Position.Y);
        }
    }
}
