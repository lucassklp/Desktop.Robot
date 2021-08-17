module UITestingUtils

open Avalonia.Controls
open Expecto
open System.Threading
open System.Reactive.Linq
open System
open Avalonia.Threading
open System.Threading.Tasks
open FSharp.Control.Reactive

[<AutoOpen>]
module Extensions =
    type Async with
        static member WithCancellation (ct:CancellationToken) (a:Async<'a>) : Async<'a> = async {
            let! ct2 = Async.CancellationToken
            use cts = CancellationTokenSource.CreateLinkedTokenSource (ct, ct2)
            let tcs = new TaskCompletionSource<'a>()
            use _reg = cts.Token.Register (fun () -> tcs.TrySetCanceled() |> ignore)
            let a = async {
                try
                  let! a = a
                  tcs.TrySetResult a |> ignore
                with ex ->
                  tcs.TrySetException ex |> ignore
            }
            Async.StartImmediate (a, cts.Token)
            return! tcs.Task |> Async.AwaitTask
        }

        static member AwaitOrTimeout (computation, ?timeout:TimeSpan) = async {
            let timeout = timeout |> Option.defaultValue (TimeSpan.FromSeconds 1.)
            let tcs = TaskCompletionSource<_>()
            let! ct1 = Async.CancellationToken
            let cts = CancellationTokenSource.CreateLinkedTokenSource(ct1)
            cts.CancelAfter(timeout)
            let ca _ = tcs.SetResult (None)
            let er (e:exn) = tcs.SetException(e)
            use _ = cts.Token.Register(fun () -> tcs.SetResult(None))
            Async.StartWithContinuations(computation, Some >> tcs.SetResult, er , ca , cts.Token)
            return! Async.AwaitTask tcs.Task
        }

let testWithWindow (window:Window)  =
    let windowContext = AvaloniaSynchronizationContext.Current

    fun name test -> (async {
            let body = async {
                do! Async.SwitchToContext windowContext
                window.Content <- null //reset window contents from previous tests
                do! test
            }
            let cts = new CancellationTokenSource(TimeSpan.FromSeconds 5.)
            let! res = body |> Async.WithCancellation cts.Token |> Async.Catch
            match res with
            | Choice2Of2 (:? TaskCanceledException) -> failwithf "Timed out doing ui test %s" name
            | Choice2Of2 e -> raise e
            | _ -> ()
        } |> testCaseAsync name)

let waitInitialized (control:Control) = async {
    if not control.IsInitialized then
        let tcs = TaskCompletionSource<_>()
        // use layoutupdated as then control at least has some bounds
        use _ = control.LayoutUpdated.Subscribe(ignore >> tcs.SetResult)
        do! Async.AwaitTask tcs.Task
}

// do an action and return the first element of observation
let attemptUIAction (observation:IObservable<_>) action = async {
    let tcs = TaskCompletionSource<_>()
    use _ = observation.FirstAsync().Subscribe(tcs.SetResult)
    do! action
    return! Async.AwaitOrTimeout(Async.AwaitTask tcs.Task, TimeSpan.FromSeconds 1.)
}

// do action on threadpool then switch back to original context
let robotDoOnThreadpool action = async {
    let context = SynchronizationContext.Current
    do! Async.SwitchToThreadPool() // run robot actions on threadpool so that GUI thread can handle events in message loop
    let! res = action
    do! Async.SwitchToContext context //switch back to GUI context for checking events/results
    return res
}

// collect list of elements from observation that occur while doing action. Does action with robotDoOnThreadpool
let attemptUIActionList (observation:IObservable<_>) action = async {
    let tcs = TaskCompletionSource<_>()
    // in order to wait for events to propagate from UI to collect into list,
    // but without waiting fixed sleep time, we will stop collecting by sending signal to takeUntilOther
    let stop = Observable.result () |> Observable.publish

    let observations =
        observation
        |> Observable.takeUntilOther stop
        |> Observable.fold (fun s e -> e::s) []
        |> Observable.last
        |> Observable.map List.rev // the fold stared at tail

    use _ = observations.Subscribe(tcs.SetResult)
    do! robotDoOnThreadpool action
    use _ = stop.Connect()
    let! observedList = Async.AwaitOrTimeout(Async.AwaitTask tcs.Task, TimeSpan.FromSeconds 5.)
    return observedList |> Option.defaultValue []
}
