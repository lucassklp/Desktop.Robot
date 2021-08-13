namespace Desktop.Robot.Clicks.Windows
{
    internal record LeftClick(int delay) : IClick
    {
        public int Delay => delay;

        public void ExecuteMouseDown(MouseContext context)
        {
            Common.LeftClickDown((uint)context.Position.X, (uint)context.Position.Y);
        }

        public void ExecuteMouseUp(MouseContext context)
        {
            Common.LeftClickUp((uint)context.Position.X, (uint)context.Position.Y);
        }
    }
}
