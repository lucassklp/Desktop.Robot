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
        void Click();
        void RightClick();
        
        void Delay(int ms);
        public void MouseMove(uint x, uint y);
    }
}
