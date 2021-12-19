using System;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Threading;

namespace Desktop.Robot.Extensions
{
    public static class LinearMouseMovementExtension
    {
        /// <summary>
        /// Simulate a mouse linear movement to a destination point. The default duration of motion is 500ms
        /// </summary>
        /// <param name="x">The Axis-X value of destination</param>
        /// <param name="y">The Axis-Y value of destination</param>
        public static void LinearMovement(this IRobot robot, int x, int y)
        {
            LinearMovement(robot, x, y, TimeSpan.FromMilliseconds(500));
        }

        /// <summary>
        /// Simulate a mouse linear movement to a destination point given a duration.
        /// </summary>
        /// <param name="x">The Axis-X value of destination</param>
        /// <param name="y">The Axis-Y value of destination</param>
        /// <param name="duration">The duration of motion</param>
        public static void LinearMovement(this IRobot robot, int x, int y, TimeSpan duration)
        {
            LinearMovement(robot, new Point(x, y), duration);
        }

        /// <summary>
        /// Simulate a mouse linear movement to a destination point. The default duration of motion is 500ms
        /// </summary>
        /// <param name="destination">The coordinate of destination</param>
        public static void LinearMovement(this IRobot robot, Point destination)
        {
            LinearMovement(robot, destination, TimeSpan.FromMilliseconds(500));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="destination">The coordinate of destination</param>
        /// <param name="duration">The duration of motion</param>
        public static void LinearMovement(this IRobot robot, Point destination, TimeSpan duration)
        {
            var delay = robot.AutoDelay; // save to restore after
            robot.AutoDelay = 0;
            Point start = robot.GetMousePosition();
            var sw = new Stopwatch();
            sw.Start();
            const int animTime = 5; // animate movement in 5ms increments
            var total = (float)duration.TotalMilliseconds;
            var from = new Vector2(start.X, start.Y);
            var to = new Vector2(destination.X, destination.Y);
            while(sw.ElapsedMilliseconds < total - animTime) {
                // lerp between start and end
                var iterPoint = from + (to - from) * (sw.ElapsedMilliseconds / total);
                robot.MouseMove(Point.Round(new PointF(iterPoint.X, iterPoint.Y)));
                Thread.Sleep(animTime);
            }

            sw.Stop();
            robot.MouseMove(destination);
            robot.AutoDelay = delay;
        }
    }
}
