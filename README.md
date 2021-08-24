<p align="center">
  <img src="Resources/logo.png" width="300px">
</p>
<p align="center">
    <img alt="nuget" src="https://img.shields.io/nuget/dt/Desktop.Robot.svg">
<a href="https://www.codacy.com/gh/lucassklp/Desktop.Robot/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=lucassklp/Desktop.Robot&amp;utm_campaign=Badge_Grade">
        <img src="https://app.codacy.com/project/badge/Grade/985f1cdd1034486cbb00a3fd3e4fff19"/>
    </a>
    <img alt="nuget version" src="https://img.shields.io/nuget/v/Desktop.Robot.svg">
</p>

# Desktop.Robot

This library helps you to automate tasks by simulating inputs (mouse and keyboards) programmatically, inspired in [java.awt.Robot](https://docs.oracle.com/javase/7/docs/api/java/awt/Robot.html)

I made this library because the dotnet SDK doesn't support simulation of mouse and keyboard input. The only way of input simulation in the standard framework is by using Windows.Forms which won't run on Linux or OSX.

## Installation

If you are using Package Manager:

```bash
Install-Package Desktop.Robot -Version 1.2.2
```

If you are using .NET CLI

```bash
dotnet add package Desktop.Robot --version 1.2.2
```


## Advantages
- Multiplatform: works on Windows, Linux and OSX
- Built using the Operating System Native and .NET API, other dependencies needed
- Easy to use


## Example of use

```csharp
using Desktop.Robot;
using Desktop.Robot.Extensions;
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
            robot.Type("A invisible cat is using my PC");
        }
    }
}
```

## Remarks
In order to use the method CreateScreenCapture you will need to install some libraries. This is required by System.Drawing's components

### Installing the requirements on Linux
```
sudo apt install libgdiplus
```

## Current limitations
1. As we are currently developing this tool, multiple monitors are not supported for now.
2. The library is under development, and some methods will throw a NotImplementedException
