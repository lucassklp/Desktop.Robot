using System;
using System.Drawing;
using System.Threading;

namespace Desktop.Robot.Extensions
{
    public static class LinearMouseMovimentExtension
    {
        /// <summary>
        /// Simulate a mouse linear moviment to a destination point. The default duration of motion is 500ms
        /// </summary>
        /// <param name="x">The Axis-X value of destination</param>
        /// <param name="y">The Axis-Y value of destination</param>
        public static void LinearMoviment(this IRobot robot, int x, int y)
        {
            LinearMoviment(robot, x, y, TimeSpan.FromMilliseconds(500));
        }

        /// <summary>
        /// Simulate a mouse linear moviment to a destination point given a duration.
        /// </summary>
        /// <param name="x">The Axis-X value of destination</param>
        /// <param name="y">The Axis-Y value of destination</param>
        /// <param name="duration">The duration of motion</param>
        public static void LinearMoviment(this IRobot robot, int x, int y, TimeSpan duration)
        {
            LinearMoviment(robot, new Point(x, y), duration);
        }

        /// <summary>
        /// Simulate a mouse linear moviment to a destination point. The default duration of motion is 500ms
        /// </summary>
        /// <param name="destination">The coordinate of destination</param>
        public static void LinearMoviment(this IRobot robot, Point destination)
        {
            LinearMoviment(robot, destination, TimeSpan.FromMilliseconds(500));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="destination">The coordinate of destination</param>
        /// <param name="duration">The duration of motion</param>
        public static void LinearMoviment(this IRobot robot, Point destination, TimeSpan duration)
        {
            var delay = robot.AutoDelay;
            robot.AutoDelay = 0;
            Point start = robot.GetMousePosition();
            PointF iterPoint = start;
            var steps = Convert.ToInt64(duration.TotalMilliseconds / 5);

            PointF slope = new PointF(destination.X - start.X, destination.Y - start.Y);

            slope.X = slope.X / steps;
            slope.Y = slope.Y / steps;

            for (int i = 0; i < steps; i++)
            {
                iterPoint = new PointF(iterPoint.X + slope.X, iterPoint.Y + slope.Y);
                robot.MouseMove(Point.Round(iterPoint));
                Thread.Sleep(5);
            }

            robot.MouseMove(destination);
            robot.AutoDelay = delay;
        }
    }
}
