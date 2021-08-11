namespace Desktop.Robot.Clicks.Linux
{
    internal record RightClick(int delay) : IClick
    {
        public int Delay => delay;

        public void ExecuteMouseDown(MouseContext context)
        {
            Common.Click(true, Common.RIGHT_BUTTON);
        }

        public void ExecuteMouseUp(MouseContext context)
        {
            Common.Click(false, Common.RIGHT_BUTTON);
        }
    }
}
