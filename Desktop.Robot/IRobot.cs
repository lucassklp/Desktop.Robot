using System;
using System.Drawing;
using Desktop.Robot.Clicks;

namespace Desktop.Robot
{
    public interface IRobot
    {
        int AutoDelay { get; set; }
        Image CreateScreenCapture(Rectangle screenRect);
        Color GetPixelColor(int x, int y);
        void KeyPress(Key key);
        void KeyPress(char key);
        void KeyDown(Key key);
        void KeyDown(char key);
        void KeyUp(Key key);
        void KeyUp(char key);
        void Click(IClick click);
        void MouseDown(IClick click);
        void MouseUp(IClick click);
        void Delay(int ms);
        void MouseMove(int x, int y);
        void MouseMove(Point p);
        void MouseScroll(int value);
        void MouseScroll(int value, TimeSpan duration);
        void MouseScroll(int value, TimeSpan duration, int steps);
        Point GetMousePosition();

        /// <summary>
        /// Moves the mouse by a given amount from the current position.
        /// The <paramref name="x"/> and <paramref name="y"/> values are added to the current coordinates.
        /// </summary>
        /// <param name="x">X value added to the current X position.</param>
        /// <param name="y">Y value added to the current Y position.</param>
        void MouseMoveRelative(int x, int y)
        {
            Point currentPoint = GetMousePosition();
            currentPoint.X += x;
            currentPoint.Y += y;
            MouseMove(currentPoint);
        }
    }
}
