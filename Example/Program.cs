using System.Robot;
using System.Robot.Extensions;
namespace Example
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var robot = new Robot();
            robot.AutoDelay = 1000;
            robot.MouseMove(100, 100);
            robot.MouseMove(700, 500);
            robot.Click();
            robot.Type("A cat is using my PC", 250);
        }
    }
}
