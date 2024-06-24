namespace Desktop.Robot.Clicks.OSX.ARM
{
    internal record MiddleClick(int delay) : IClick
    {
        public int Delay => delay;

        public void ExecuteMouseDown(MouseContext context)
        {
            Common.OtherClickDown((uint)context.Position.X, (uint)context.Position.Y);
        }

        public void ExecuteMouseUp(MouseContext context)
        {
            Common.OtherClickUp((uint)context.Position.X, (uint)context.Position.Y);
        }
    }
}
