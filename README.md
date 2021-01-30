<p align="center">
  <img src="Resources/logo.png" width="300px">
</p>
<p align="center">
    <img alt="nuget" src="https://img.shields.io/nuget/dt/System.Robot.svg">
<a href="https://www.codacy.com/gh/lucassklp/System.Robot/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=lucassklp/System.Robot&amp;utm_campaign=Badge_Grade">
        <img src="https://app.codacy.com/project/badge/Grade/985f1cdd1034486cbb00a3fd3e4fff19"/>
    </a>
    <img alt="nuget version" src="https://img.shields.io/nuget/v/System.Robot.svg">
</p>

# System.Robot

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