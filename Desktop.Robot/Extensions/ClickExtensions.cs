using Desktop.Robot.Clicks;

namespace Desktop.Robot.Extensions
{
    public static class ClickExtensions
    {
        public static void Click(this IRobot robot)
        {
            robot.Click(Mouse.LeftButton());
        }
    }
}
