using System.Drawing;
using System.Robot.Clicks;

namespace System.Robot
{
    public interface IRobot
    {
        int AutoDelay { get; set; }
        Image CreateScreenCapture(Rectangle screenRect);
        Color GetPixelColor(int x, int y);
        void KeyPress(char keycode);
        void Click(IClick click);
        void Delay(int ms);
        public void MouseMove(int x, int y);
    }
}
