using Desktop.Robot;
using Desktop.Robot.Extensions;
namespace Example
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var robot = new Robot();
            robot.AutoDelay = 1000;
            robot.MouseMove(1000, 1000);
            robot.Click();
            robot.Type("A cat is using my PC", 25);
            robot.CombineKeys(Key.Alt, Key.Tab);
        }
    }
}