module MouseTests

open Avalonia
open Avalonia.Controls
open Expecto
open System.Reactive.Linq
open System
open Desktop.Robot
open Desktop.Robot.Extensions
open FSharp.Control.Reactive
open Desktop.Robot.Clicks
open Avalonia.Input
open UITestingUtils

type MouseButton = | LeftButton | MiddleButton | RightButton
type MouseButtonsState = {
    IsLeftButtonPressed: bool
    IsMiddleButtonPressed: bool
    IsRightButtonPressed: bool
}

let getMouseButtonsState (properties:PointerPointProperties) =
    {
        IsLeftButtonPressed = properties.IsLeftButtonPressed
        IsMiddleButtonPressed = properties.IsMiddleButtonPressed
        IsRightButtonPressed = properties.IsRightButtonPressed
    }

let singleMouseButtonPressed mouseButton = {
    IsLeftButtonPressed = mouseButton = LeftButton
    IsMiddleButtonPressed = mouseButton = MiddleButton
    IsRightButtonPressed = mouseButton = RightButton
}

let noMouseButtonsPressed = {
    IsLeftButtonPressed = false
    IsMiddleButtonPressed = false
    IsRightButtonPressed = false
}

let tests (window:Window) = testList "Mouse tests" [
    let uiTest = testWithWindow window

    // for these mouse tests, it's important they are done in order
    // because the earlier ones like clicking assume the mouse is
    // already over the window

    uiTest "Can click" <| async {
        let btn = Button()
        btn.Content <- "Can left click?"
        window.Content <- btn
        do! waitInitialized btn
        let! clickEvent = attemptUIAction <| btn.Click.FirstAsync() <| async {
            Robot().Click(Mouse.LeftButton())
        }
        Expect.isSome clickEvent "Robot should click the button"
    }

    let testClick mouseButton =
        uiTest (sprintf "Mouse click %A presses and releases" mouseButton) <| async {
            // get properties as soon as press happens to get state at the time of the event
            let pressed = window.PointerPressed.Select(fun e -> e.GetCurrentPoint(window).Properties |> getMouseButtonsState)
            let released = window.PointerReleased.Select(fun e -> e.GetCurrentPoint(window).Properties |> getMouseButtonsState)
            let observation = Observable.zip pressed released
            let! pointerEvents = attemptUIAction <| observation <| async {
                let click =
                    let delay = 10 // millis
                    match mouseButton with
                    | LeftButton -> Mouse.LeftButton(delay)
                    | MiddleButton -> Mouse.MiddleButton(delay)
                    | RightButton -> Mouse.RightButton(delay)
                Robot().Click(click)
            }
            let (whenPressed, whenReleased) = Expect.wantSome pointerEvents "Robot should press and release on window"
            let expectedWhenPressed = singleMouseButtonPressed mouseButton
            Expect.equal whenPressed expectedWhenPressed "Currect mouse button pressed"
            Expect.equal whenReleased noMouseButtonsPressed "Button was released"
        }

    let testMouseDownUp mouseButton =
        uiTest (sprintf "Mouse down then up separately %A" mouseButton) <| async {
            // get properties as soon as press happens to get state at the time of the event
            let pressed = window.PointerPressed.Select(fun e -> e.GetCurrentPoint(window).Properties |> getMouseButtonsState, DateTime.Now)
            let released = window.PointerReleased.Select(fun e -> e.GetCurrentPoint(window).Properties |> getMouseButtonsState, DateTime.Now)
            let observation = Observable.zip pressed released
            let delayBeforeRelease = TimeSpan.FromMilliseconds 100.
            let! pointerEvents = attemptUIAction <| observation <| async {
                let click =
                    match mouseButton with
                    | LeftButton -> Mouse.LeftButton()
                    | MiddleButton -> Mouse.MiddleButton()
                    | RightButton -> Mouse.RightButton()
                Robot().MouseDown(click)
                do! Async.Sleep delayBeforeRelease // wait some time before releasing.
                Robot().MouseUp(click)
            }
            let ((whenPressed, timeWhenPressed), (whenReleased, timeWhenReleased)) = Expect.wantSome pointerEvents "Robot should press and release on window"
            let expectedWhenPressed = singleMouseButtonPressed mouseButton
            Expect.equal whenPressed expectedWhenPressed "Currect mouse button pressed"
            Expect.equal whenReleased noMouseButtonsPressed "Button was released"
            let observedDelay = timeWhenReleased - timeWhenPressed
            Expect.isGreaterThan observedDelay delayBeforeRelease "Should wait before releasing"
            Expect.isLessThan observedDelay (delayBeforeRelease * 1.5) "Should not have that much overhead time"
        }

    testClick LeftButton
    testClick MiddleButton
    testClick RightButton
    testMouseDownUp LeftButton
    testMouseDownUp RightButton
    testMouseDownUp MiddleButton

    uiTest "Can scroll vertical" <| async {
        let wheelDeltas = window.PointerWheelChanged.Select(fun x -> x.Delta)
        let robot = Robot();
        robot.AutoDelay <- 100;
        let! deltaEvents = attemptUIActionList wheelDeltas <| async {
            robot.MouseScroll(100) // scroll down
            robot.MouseScroll(-100) // then scroll up
        }
        Expect.hasLength deltaEvents 2 "Should have a wheel event for each mouse scroll"
        let xDeltas = deltaEvents |> List.map (fun p -> p.X)
        let yDeltas = deltaEvents |> List.map (fun p -> p.Y)
        Expect.allEqual xDeltas 0 "Should not scroll horizontally"
        Expect.isLessThan yDeltas[0] 0 "Should scroll down first"
        Expect.isGreaterThan yDeltas[1] 0 "Should scroll up next"
    }

    uiTest "Can move to point" <| async {
        let toPixelPoint (p:Point) = PixelPoint(int p.X, int p.Y)
        let toDrawingPoint (p:PixelPoint) = Drawing.Point(p.X, p.Y)
        let center = toPixelPoint window.Bounds.Center
        let screenPoint = window.PointToScreen(window.Bounds.Center)

        let pointerMoved = window.PointerMoved.Select(fun x -> x.GetPosition(window) |> toPixelPoint)

        let! movedPositions = attemptUIActionList pointerMoved <| async {
            Robot().MouseMove(toDrawingPoint(screenPoint))
            do! Async.Sleep 1000
        }

        Expect.isNonEmpty movedPositions "Should move mouse"

        // sometimes it emits two events first with the starting position.
        Expect.isLessThanOrEqual movedPositions.Length 2 "Should go directly, without emitting too many moved events"
        let eventPos = movedPositions |> Seq.last
        Expect.equal eventPos center "Should move mouse to center of control"
    }

    uiTest "Can move linear" <| async {
        let toPixelPoint (p:Point) = PixelPoint(int p.X, int p.Y)
        let toScreenPoint (p:Point) =
            let sp = window.PointToScreen(p)
            Drawing.Point(sp.X, sp.Y)

        let pointerMoved = window.PointerMoved.Select(fun x -> x.GetPosition(window) |> toPixelPoint)

        let bottomLeft = toScreenPoint window.Bounds.BottomLeft
        let topRight = toScreenPoint window.Bounds.TopRight

        let duration = TimeSpan.FromMilliseconds 200.
        let! movedEvents = attemptUIActionList pointerMoved <| async {
            Robot().MouseMove(bottomLeft) // goto bottom left at start
            Robot().LinearMovement(topRight, duration) // then move mouse towards the top right
        }
        Expect.isGreaterThan movedEvents.Length 10 "LinearMovement should lead to a many PointerMoved events"
        let xPositions = movedEvents |> Seq.skip 2 |> Seq.map (fun p -> p.X) // skip goto at start
        let yPositions = movedEvents |> Seq.skip 2 |> Seq.map (fun p -> p.Y) // skip goto at start
        Expect.isAscending xPositions "Should move left to right"
        Expect.isDescending yPositions "Should move bottom to top"
    }

    uiTest "TimeSpan for linear movement" <| async {
        let toScreenPoint (p:Point) =
            let sp = window.PointToScreen(p)
            Drawing.Point(sp.X, sp.Y)

        let bottomLeft = toScreenPoint window.Bounds.BottomLeft
        let topRight = toScreenPoint window.Bounds.TopRight

        Robot().MouseMove(bottomLeft) // goto bottom left at start
        let duration = TimeSpan.FromMilliseconds 150.
        let sw = Diagnostics.Stopwatch()
        sw.Start()
        Robot().LinearMovement(topRight, duration) // then move mouse towards the top right
        sw.Stop()

        let actualDuration = sw.Elapsed
        let minAcceptable = duration - TimeSpan.FromMilliseconds 5.
        let maxAcceptable = duration + TimeSpan.FromMilliseconds 50.
        Expect.isGreaterThanOrEqual actualDuration minAcceptable "Should spend approx duration to do the movement"
        Expect.isLessThan actualDuration maxAcceptable "Should not spend too much more time than requested duration"
    }
]