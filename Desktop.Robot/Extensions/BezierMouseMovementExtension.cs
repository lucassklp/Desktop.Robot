using Desktop.Robot.Windows;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Desktop.Robot.Extensions
{
    public static class BezierMouseMovementExtension
    {
        public static void BezierMovement(this IRobot robot, Point ending, TimeSpan duration)
        {
            var random = new Random();
            var currentPosition = robot.GetMousePosition();

            Rectangle size = new Rectangle(0, 0, 700, 700);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                size = MonitorInfo.GetMonitorSize();
            }

            var x = random.Next(0, size.Width);
            var y = random.Next(0, size.Height);

            var randomControlPoint = new Point(x, y);

            BezierMovement(robot, currentPosition, randomControlPoint, ending, duration);
        }


        public static void BezierMovement(this IRobot robot, Point controlPoint, Point ending, TimeSpan duration)
        {
            var currentPosition = robot.GetMousePosition();
            BezierMovement(robot, currentPosition, controlPoint, ending, duration);
        }


        public static void BezierMovement(this IRobot robot, Point initial, Point controlPoint, Point ending, TimeSpan duration)
        {
            var points = new List<Point>();
            var increment = duration.Milliseconds > 1000 ? .001 : .01;

            for (double t = 0; t <= 1; t+=increment)
            {
                points.Add(GetPoint(t, initial, controlPoint, ending));
            }

            var interval = Convert.ToInt32(duration.TotalMilliseconds / points.Count);

            robot.MouseMove(initial);

            //Avoiding AutoDelay
            var currentAutoDelay = robot.AutoDelay;
            robot.AutoDelay = interval;

            foreach (var point in points)
            {
                robot.MouseMove(point);
            }

            robot.MouseMove(ending.X, ending.Y);

            robot.AutoDelay = currentAutoDelay;
        }

        private static Point GetPoint(double t, Point initial, Point controlPoint, Point ending)
        {
            var x = (1 - t) * (1 - t) * initial.X + 2 * (1 - t) * t * controlPoint.X + t * t * ending.X;
            var y = (1 - t) * (1 - t) * initial.Y + 2 * (1 - t) * t * controlPoint.Y + t * t * ending.Y;
            return new Point((int)x, (int)y);
        }
    }
}
