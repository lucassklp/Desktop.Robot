using System;
using System.Robot;
using System.Threading;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var robot = Robot.Create();
            robot.MouseMove(100, 100);
            robot.AutoDelay = 1000;
            robot.MouseMove(700, 500);
            robot.RightClick();
        }
    }
}
