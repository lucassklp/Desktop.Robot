namespace Desktop.Robot.Clicks.Linux
{
    internal record LeftClick(int delay) : IClick
    {
        public int Delay => delay;

        public void ExecuteMouseDown(MouseContext context)
        {
            Common.Click(true, Common.LEFT_BUTTON);
        }

        public void ExecuteMouseUp(MouseContext context)
        {
            Common.Click(false, Common.LEFT_BUTTON);
        }
    }
}
