using System;
namespace Desktop.Robot.Clicks.Linux
{
    internal record MiddleClick(int delay) : IClick
    {
        public int Delay => delay;

        public void ExecuteMouseDown(MouseContext context)
        {
            Common.Click(true, Common.CENTER_BUTTON);
        }

        public void ExecuteMouseUp(MouseContext context)
        {
            Common.Click(false, Common.CENTER_BUTTON);
        }
    }
}
