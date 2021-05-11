using System;
namespace Desktop.Robot.Clicks.Linux
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
            Common.Click(true, Common.RIGHT_BUTTON);
            Common.Click(false, Common.RIGHT_BUTTON);
        }
    }
}
