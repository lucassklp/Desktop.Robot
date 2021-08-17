open Avalonia
open Avalonia.Controls.ApplicationLifetimes
open Avalonia.Controls
open Avalonia.Markup.Xaml.Styling
open Expecto
open System.Threading
open System.Reactive.Linq
open Avalonia.Media
open System
open Avalonia.Threading


type MainWindow() as this =
    inherit Window()
    do
        this.Title <- "Desktop.Robot test app"
        this.Width <- 300.
        this.Height <- 200.
        
        let btn = Button()
        this.Content <- btn
        btn.Content <- "Click to start test"
        btn.Width <- 100.
        btn.Height <- 50.
        let runTests () =
            this.Content <- null
            let cts = new CancellationTokenSource()
            this.Closing.Add(fun _ -> Async.CancelDefaultToken()) // stop tests running if app is closing
            this.Closing.Add(fun _ -> cts.Cancel()) // stop tests running if app is closing
            Expect.defaultDiffPrinter <- Diff.colourisedDiff
            let config = { defaultConfig with runInParallel = false }
            let tests = testSequenced <| testList "Desktop.Robot test app" [
                MouseTests.tests this
            ]
            let uiContext = AvaloniaSynchronizationContext.Current

            let runTestsAsync = async {
                // do in async block in threadpool so that test runner doesn't interfere with gui message loop
                let testResultExitCode = runTests config tests
                do! Async.SwitchToContext uiContext // switch back to ui context to show results
                if testResultExitCode = 0 then
                    this.Background <- Brushes.LimeGreen
                    this.Title <- "All tests suceeded"
                else
                    this.Title <- "Failures :("
                    this.Background <- Brushes.PaleVioletRed

                this.Content <- btn
            }
            this.Background <- Brushes.YellowGreen
            Async.Start(runTestsAsync, cts.Token)

        btn.Click
            // .FirstAsync()
            .Delay(TimeSpan.FromSeconds 0.1)
            .ObserveOn(SynchronizationContext.Current)
            .Subscribe(fun _ -> runTests())
            |> ignore

type App() =
    inherit Application()

    override this.Initialize() =
        this.Styles.AddRange [
            StyleInclude(baseUri = null, Source = System.Uri "avares://Avalonia.Themes.Default/DefaultTheme.xaml")
            StyleInclude(baseUri = null, Source = System.Uri "avares://Avalonia.Themes.Default/Accents/BaseLight.xaml")

        ]

    override this.OnFrameworkInitializationCompleted() =
        match this.ApplicationLifetime with
        | :? IClassicDesktopStyleApplicationLifetime as desktopLifetime ->
            desktopLifetime.MainWindow <- MainWindow()
        | _ -> failwith "Must be desktop app"

module Program =
    [<EntryPoint>]
    let main args =
        AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .UseSkia()
            .StartWithClassicDesktopLifetime(args)