using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Desktop.Robot.Extensions
{
    public static class BezierMouseMovimentExtension
    {

        public static void QuadraticBezierMoviment(this IRobot robot, Point ending, TimeSpan duration)
        {
            var randomFactor = new Random();
            var currentPosition = robot.GetMousePosition();

            var x = randomFactor.Next(1, 500);
            var y = randomFactor.Next(1, 500);

            var calculatedControlPoint = new Point(x, y);
            Console.WriteLine(calculatedControlPoint);

            QuadraticBezierMoviment(robot, currentPosition, calculatedControlPoint, ending, duration);
        }

        public static void QuadraticBezierMoviment(this IRobot robot, Point initial, Point controlPoint, Point ending, TimeSpan duration)
        {
            var points = new List<Point>();
            var increment = duration.Milliseconds > 1000 ? .001 : .01;

            for (double t = 0; t <= 1; t+=increment)
            {
                points.Add(GetPoint(t, initial, controlPoint, ending));
            }

            var interval = duration.TotalMilliseconds / points.Count;

            foreach (var item in points)
            {
                Thread.Sleep((int)interval);
                robot.MouseMove((uint)item.X, (uint)item.Y);
            }
        }

        private static Point GetPoint(double t, Point initial, Point controlPoint, Point ending)
        {
            var x = (1 - t) * (1 - t) * initial.X + 2 * (1 - t) * t * controlPoint.X + t * t * ending.X;
            var y = (1 - t) * (1 - t) * initial.Y + 2 * (1 - t) * t * controlPoint.Y + t * t * ending.Y;
            return new Point((int)x, (int)y);
        }
    }
}
