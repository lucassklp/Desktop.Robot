﻿using Desktop.Robot;
using Desktop.Robot.Extensions;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;


namespace Example
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var robot = new Robot();
            robot.OnMouseMove().Subscribe(position => Console.WriteLine(position));
            robot.AutoDelay = 1000;
            robot.MouseMove(700, 500);
            robot.BezierMovement(new Point(0, 0), TimeSpan.FromMilliseconds(1000));
            robot.Click();
            robot.Type("A invisible cat is using my PC", 125);
            robot.CombineKeys(Key.Alt, Key.Tab);

            // Code available only on Windows. Need improvement.
            using var screenshot = robot.CreateScreenCapture(new Rectangle(100, 100, 200, 200));
            var path = Path.Combine(Directory.GetCurrentDirectory(), $"image-{Guid.NewGuid()}.bmp");
            screenshot.Save(path, ImageFormat.Bmp);

            robot.LinearMovement(300, 300);
            robot.Click();
            robot.MouseScroll(value: -1000, duration: TimeSpan.FromSeconds(5), steps: 500);
        }
    }
}
