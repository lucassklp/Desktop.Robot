using System.Drawing;
using Desktop.Robot.Clicks;

namespace Desktop.Robot
{
    public interface IRobot
    {
        uint AutoDelay { get; set; }
        Image CreateScreenCapture(Rectangle screenRect);
        Color GetPixelColor(uint x, uint y);
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
        void MouseMove(uint x, uint y);
        void MouseMove(Point p);
        void MouseScrollVertical(int value);
        Point GetMousePosition();
    }
}
