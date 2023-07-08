using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Desktop.Robot.OSX
{
    public class Robot : AbstractRobot
    {
        private readonly AbstractRobot _delegate;
        public Robot()
        {
            _delegate = RuntimeInformation.ProcessArchitecture == Architecture.Arm64 ? 
                new Arm.Robot() : 
                new Intel.Robot();
        }
        
        public override void KeyDown(Key key) => _delegate.KeyDown(key);

        public override void KeyDown(char key) => _delegate.KeyDown(key);

        public override void KeyPress(Key key) => _delegate.KeyPress(key);

        public override void KeyPress(char key) => _delegate.KeyPress(key);

        public override void KeyUp(Key key) => _delegate.KeyUp(key);

        public override void KeyUp(char key) => _delegate.KeyUp(key);

        public override void MouseMove(int x, int y) => _delegate.MouseMove(x, y);

        public override Point GetMousePosition() => _delegate.GetMousePosition();

        public override void MouseScroll(int value) => _delegate.MouseScroll(value);

        public override void MouseScroll(int value, TimeSpan duration) => _delegate.MouseScroll(value, duration);

        public override void MouseScroll(int value, TimeSpan duration, int steps) => _delegate.MouseScroll(value, duration, steps);
	}
}
