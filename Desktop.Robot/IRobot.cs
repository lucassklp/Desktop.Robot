using System.Drawing;
using Desktop.Robot.Clicks;

namespace Desktop.Robot
{
    public interface IRobot
    {
        uint AutoDelay { get; set; }
        Image CreateScreenCapture(Rectangle screenRect);
        Color GetPixelColor(int x, int y);
        void KeyPress(char keycode);
        void Click(IClick click);
        void Delay(int ms);
        void MouseMove(uint x, uint y);
        Point GetMousePosition();
    }
}
