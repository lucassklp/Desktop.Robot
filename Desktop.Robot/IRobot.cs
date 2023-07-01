using System.Drawing;
using Desktop.Robot.Clicks;

namespace Desktop.Robot
{
    public interface IRobot
    {
        uint AutoDelay { get; set; }
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
        void Delay(uint ms);
        void MouseMove(int x, int y);
        void MouseMove(Point p);
        void MouseScroll(int value);
        void MouseScroll(int value, int duration);
        void MouseScroll(int value, int duration, int steps);
        Point GetMousePosition();
    }
}
