<p align="center">
  <img src="Resources/logo.png" width="300px">
</p>
<p align="center">
    <img alt="nuget" src="https://img.shields.io/nuget/dt/System.Robot.svg">
    <a href="https://www.codacy.com/manual/lucassklp/System.Robot?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=lucassklp/System.Robot&amp;utm_campaign=Badge_Grade">
        <img src="https://api.codacy.com/project/badge/Grade/90ffddf0fe1c4bb89e8e7049784ea190"/>
    </a>
    <img alt="nuget version" src="https://img.shields.io/nuget/v/System.Robot.svg">
</p>

# System.Robot

[![Codacy Badge](https://api.codacy.com/project/badge/Grade/bbf1b61a677643019f2c6ec2610e62cf)](https://app.codacy.com/gh/lucassklp/System.Robot?utm_source=github.com&utm_medium=referral&utm_content=lucassklp/System.Robot&utm_campaign=Badge_Grade)

This library helps you to automate tasks by simulating inputs (mouse and keyboards) programmatically.

## Advantages
    - Multiplatform: works on Windows, Linux and OSX
    - Built using the Operating System Native API, no other dependency needed
    - Easy to use

## Example of use

```csharp
using System.Robot;
using System.Robot.Extensions;
namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var robot = new Robot();
            robot.AutoDelay = 1000;
            robot.MouseMove(100, 100);
            robot.Click();
            robot.Type("A cat is using my PC");
        }
    }
}
```

## Current limitation
As we are currently developing this tool, multiple monitors are not supported for now.