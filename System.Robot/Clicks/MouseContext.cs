using System;
using System.Drawing;

namespace System.Robot.Clicks
{
    public class MouseContext
    {
        public Point Position { get; }

        public MouseContext(Point position)
        {
            Position = position;
        }
    }
}
