﻿namespace Desktop.Robot.Clicks.Windows
{
    internal record MiddleClick(int delay) : IClick
    {
        public int Delay => delay;

        public void ExecuteMouseDown(MouseContext context)
        {
            Common.MiddleClickDown((uint)context.Position.X, (uint)context.Position.Y);
        }

        public void ExecuteMouseUp(MouseContext context)
        {
            Common.MiddleClickUp((uint)context.Position.X, (uint)context.Position.Y);
        }
    }
}
