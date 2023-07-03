using System.Drawing;

namespace Desktop.Robot.Clicks
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
