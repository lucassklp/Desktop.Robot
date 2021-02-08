using Desktop.Robot;
using Desktop.Robot.Extensions;
namespace Example
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var robot = new Robot();
            robot.AutoDelay = 2000;
            robot.MouseMove(700, 500);
            robot.Click();
            robot.Type("A cat is using my PC", 250);
            robot.CombineKeys(Key.Shift, Key.D);
        }
    }
}