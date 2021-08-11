namespace Desktop.Robot.Clicks.Windows
{
    internal record RightClick(int delay) : IClick
    {
        public int Delay => delay;

        public void ExecuteMouseDown(MouseContext context)
        {
            Common.RightClickDown((uint)context.Position.X, (uint)context.Position.Y);
        }

        public void ExecuteMouseUp(MouseContext context)
        {
            Common.RightClickUp((uint)context.Position.X, (uint)context.Position.Y);
        }
    }
}
