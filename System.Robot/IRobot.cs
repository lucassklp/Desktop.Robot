using System.Drawing;
using System.Robot.Clicks;

namespace System.Robot
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
