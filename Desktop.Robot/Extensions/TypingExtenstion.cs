namespace Desktop.Robot.Extensions
{
    public static class TypingExtenstion
    {
        public static IRobot Type(this IRobot robot, string text)
        {
            foreach (var ch in text)
            {
                robot.KeyPress(ch);
            }
            return robot;
        }

        public static IRobot Type(this IRobot robot, string text, uint delay)
        {
            var currentDelay = robot.AutoDelay;
            robot.AutoDelay = delay;
            foreach (var ch in text)
            {
                robot.KeyPress(ch);
            }
            robot.AutoDelay = currentDelay;
            return robot;
        }

        public static IRobot CombineKeys(this IRobot robot, params char[] keycodes)
        {
            foreach (var keycode in keycodes)
            {
                robot.KeyDown(keycode);
            }
            foreach (var keycode in keycodes)
            {
                robot.KeyUp(keycode);
            }
            return robot;
        }

        public static IRobot CombineKeys(this IRobot robot, params Key[] keycodes)
        {
            foreach (var keycode in keycodes)
            {
                robot.KeyDown(keycode.ToChar());
            }
            foreach (var keycode in keycodes)
            {
                robot.KeyUp(keycode.ToChar());
            }
            return robot;
        }
    }
}
