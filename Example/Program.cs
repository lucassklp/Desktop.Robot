using System;
using System.Robot;
namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var robot = new Robot();
            robot.CreateScreenCapture(new System.Drawing.Rectangle(0, 0, 200, 200));
        }
    }
}
