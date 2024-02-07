module KeyboardTests

open Avalonia.Controls
open Expecto
open System.Reactive.Linq
open Desktop.Robot
open Desktop.Robot.Extensions
open UITestingUtils
open System

type AKey = Avalonia.Input.Key

let toAvaloniaKey key =
    let no key = Error (sprintf "(%A) is not actually a key..." key) // or maybe I'm missing something
    match key with
    | Key.A -> Ok AKey.A
    | Key.B -> Ok AKey.B
    | Key.C -> Ok AKey.C
    | Key.D -> Ok AKey.D
    | Key.E -> Ok AKey.E
    | Key.F -> Ok AKey.F
    | Key.G -> Ok AKey.G
    | Key.H -> Ok AKey.H
    | Key.I -> Ok AKey.I
    | Key.J -> Ok AKey.J
    | Key.K -> Ok AKey.K
    | Key.L -> Ok AKey.L
    | Key.M -> Ok AKey.M
    | Key.N -> Ok AKey.N
    | Key.O -> Ok AKey.O
    | Key.P -> Ok AKey.P
    | Key.Q -> Ok AKey.Q
    | Key.R -> Ok AKey.R
    | Key.S -> Ok AKey.S
    | Key.T -> Ok AKey.T
    | Key.U -> Ok AKey.U
    | Key.V -> Ok AKey.V
    | Key.W -> Ok AKey.W
    | Key.X -> Ok AKey.X
    | Key.Y -> Ok AKey.Y
    | Key.Z -> Ok AKey.Z
    //Key. Numbers -> RKey.Numbers
    | Key.Zero -> Ok AKey.D0
    | Key.One -> Ok AKey.D1
    | Key.Two -> Ok AKey.D2
    | Key.Three -> Ok AKey.D3
    | Key.Four -> Ok AKey.D4
    | Key.Five -> Ok AKey.D5
    | Key.Six -> Ok AKey.D6
    | Key.Seven -> Ok AKey.D7
    | Key.Eight -> Ok AKey.D8
    | Key.Nine -> Ok AKey.D9
    //Key. Symbols -> Ok AKey.Symbols
    | Key.Comma -> Ok AKey.OemComma
    | Key.Colon -> no key
    | Key.Semicolon -> Ok AKey.OemSemicolon
    | Key.Dot -> Ok AKey.OemPeriod
    | Key.Dollar -> no key
    | Key.Slash -> no key
    | Key.Backslash -> Ok AKey.OemBackslash
    | Key.Percent -> no key
    | Key.LessThan -> no key
    | Key.Equal -> no key
    | Key.GreaterThan -> no key
    | Key.QuotationMark -> no key
    | Key.OpenParenthesis -> no key
    | Key.CloseParenthesis -> no key
    | Key.OpenBracket -> no key
    | Key.CloseBracket -> no key
    | Key.OpenBrace -> no key
    | Key.CloseBrace -> no key
    | Key.Interrogation -> no key
    // Key. Modifiers -> Ok AKey.Modifiers
    | Key.Command -> no key
    | Key.Shift -> Ok AKey.LeftShift
    | Key.Option -> no key
    | Key.Control -> Ok AKey.LeftCtrl
    | Key.Alt -> Ok AKey.LeftAlt
    | Key.CapsLock -> Ok AKey.CapsLock
    //Key. Other keys -> Ok AKey.keys
    | Key.Enter -> Ok AKey.Enter
    | Key.Tab -> Ok AKey.Tab
    | Key.Delete -> Ok AKey.Delete
    | Key.Esc -> Ok AKey.Escape
    | Key.Insert -> Ok AKey.Insert
    | Key.Home -> Ok AKey.Home
    | Key.End -> Ok AKey.End
    | Key.PageUp -> Ok AKey.PageUp
    | Key.PageDown -> Ok AKey.PageDown
    | Key.Backspace -> Ok AKey.Back
    | Key.Plus -> Ok AKey.OemPlus
    | Key.Minus -> Ok AKey.OemMinus
    | Key.PrintScreen -> Ok AKey.PrintScreen
    | Key.ScrollLock -> no key
    | Key.NumLock -> Ok AKey.NumLock
    | Key.Pause -> Ok AKey.Pause
    //Key. F keys -> Ok AKey.keys
    | Key.F1 -> Ok AKey.F1
    | Key.F2 -> Ok AKey.F2
    | Key.F3 -> Ok AKey.F3
    | Key.F4 -> Ok AKey.F4
    | Key.F5 -> Ok AKey.F5
    | Key.F6 -> Ok AKey.F6
    | Key.F7 -> Ok AKey.F7
    | Key.F8 -> Ok AKey.F8
    | Key.F9 -> Ok AKey.F9
    | Key.F10 -> Ok AKey.F10
    | Key.F11 -> Ok AKey.F11
    | Key.F12 -> Ok AKey.F12
    | _ -> Error <| sprintf "Unhandled key enum (%A)" key

let alphabetKeys = [
    Key.A
    Key.B
    Key.C
    Key.D
    Key.E
    Key.F
    Key.G
    Key.H
    Key.I
    Key.J
    Key.K
    Key.L
    Key.M
    Key.N
    Key.O
    Key.P
    Key.Q
    Key.R
    Key.S
    Key.T
    Key.U
    Key.V
    Key.W
    Key.X
    Key.Y
    Key.Z
]

let digitKeys = [
    Key.Zero
    Key.One
    Key.Two
    Key.Three
    Key.Four
    Key.Five
    Key.Six
    Key.Seven
    Key.Eight
    Key.Nine
]

let commonGameKeys = [
    Key.Esc
    Key.Enter

]

let pressKeyAndWaitForEvent (tb:Control) key = async {
    let avaloniaKey = Expect.wantOk (toAvaloniaKey key) "Must pass in ok key"
    let observation = tb.KeyDown.Where(fun e -> e.Key = avaloniaKey).Select(ignore)
    let! didHandleTypingEvents = attemptUIAction observation <| async { Robot().KeyPress(key) }
    Expect.isSome didHandleTypingEvents "Should get event from the keypress"
}

let tests (window:Window) = testList "Keybard tests" [
    let uiTest = testWithWindow window
    let keyboardTest name testBody =
        // uiTest but with a textbox that's in focus and a button to click
        uiTest name <| async {
            let tb = TextBox()
            window.Content <- tb
            do! waitInitialized tb
            let! gotFocus = attemptUIAction tb.GotFocus <| async { tb.Focus() }
            Expect.isSome gotFocus "Should get focus of textbox"
            do! testBody tb
        }

    let textboxTest name expectedMessage robotAction = keyboardTest name <| fun tb -> async {
        do! robotDoOnThreadpool <| async { do robotAction (Robot()) }
        do! pressKeyAndWaitForEvent tb Key.Esc
        Expect.equal tb.Text expectedMessage "Should get expected key"
    }

    keyboardTest "Simple keypess" <| fun tb -> async {
        do! pressKeyAndWaitForEvent tb Key.A
        Expect.equal tb.Text "a" "Should press A"
    }

    keyboardTest "Can type a simple message" <| fun tb -> async {
        let message = "hello world"
        do! robotDoOnThreadpool <| async { Robot().Type(message) |> ignore }
        do! pressKeyAndWaitForEvent tb Key.Esc

        Expect.equal tb.Text message "Robot should type the message"
    }

    // Todo: Test modifiers
    // Todo: Test KeyDown and KeyUp separately
    // Todo: Test CombineKeys


    testList "Robot KeyCodes" [
        let regularKeyTest key = keyboardTest (sprintf "Key=%A" key) <| fun tb -> async {
            let avaloniaKey = Expect.wantOk (toAvaloniaKey key) "Should be regular ok key"
            let! event = attemptUIAction window.KeyDown <| async { Robot().KeyPress(key) }
            let event = Expect.wantSome event "Keypress should make keydown event"
            Expect.equal event.Key avaloniaKey "Should get expected key"
        }

        testList "Alphabet keys" (List.map regularKeyTest alphabetKeys)
        testList "Digit keys" (List.map regularKeyTest digitKeys)

        testList "Some misc keys" [
            textboxTest "Single quotation mark" "'" (fun rb -> rb.KeyPress(Key.QuotationMark))
            textboxTest "Double quotation mark with shift" "\"" (fun rb -> ignore <| rb.CombineKeys(Key.Shift, Key.QuotationMark))
        ]
        // Todo: Test more testable sets of keycodes

        // don't test all keycodes, a bunch are broken anyway and many have different
        // behavious (eg. PrintScreen, NumLock, Modifiers etc.)
        ptestList "All KeyCodes (will be skipped)" [
            for key in System.Enum.GetValues() do
                keyboardTest (sprintf "Key=%A" key) <| fun tb -> async {
                    match toAvaloniaKey key with
                    | Ok avaloniaKey ->
                        let! event = attemptUIAction window.KeyDown <| async { Robot().KeyPress(key) }
                        let event = Expect.wantSome event "Keypress should make keydown event"
                        Expect.equal event.Key avaloniaKey "Should get expected key"
                    | Error e ->
                        printfn "Skipping test for Key=%A: %s" key e
                }
        ]
    ]

]