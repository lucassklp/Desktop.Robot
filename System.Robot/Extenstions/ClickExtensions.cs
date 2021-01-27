using System;
using System.Robot.Clicks;

namespace System.Robot.Extenstions
{
    public static class ClickExtensions
    {
        public static void Click(this IRobot robot)
        {
            robot.Click(Mouse.LeftButton());
        }
    }
}
