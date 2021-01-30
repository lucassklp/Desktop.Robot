namespace Desktop.Robot.Extensions
{
    public static class TypingExtenstion
    {
        public static void Type(this IRobot robot, string text)
        {
            foreach (var ch in text)
            {
                robot.KeyPress(ch);
            }
        }

        public static void Type(this IRobot robot, string text, uint delay)
        {
            var currentDelay = robot.AutoDelay;
            robot.AutoDelay = delay;
            foreach (var ch in text)
            {
                robot.KeyPress(ch);
            }
            robot.AutoDelay = currentDelay;
        }
    }
}
