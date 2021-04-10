using System.Collections.Generic;

namespace Desktop.Robot.Extensions
{
    public static class TypingExtension
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

        public static IRobot CombineKeys(this IRobot robot, params Key[] keys)
        {
            var stack = new Stack<Key>();
            foreach (var key in keys)
            {
                robot.KeyDown(key);
                stack.Push(key);
            }

            while (stack.Count != 0)
            {
                var key = stack.Pop();
                robot.KeyUp(key);
            }

            return robot;
        }
    }
}