module Program

open System.Threading
open System

/// Class for CountdownEvent. Takes positive integer
type MyCountdownEvent(cnt) = 
    do if cnt <= 0 then
        raise (ArgumentOutOfRangeException("Аргумент должен быть положительным!"))
    let event = new ManualResetEvent(false)
    let mutable count = cnt

    /// Locking the thread
    member this.Wait () = 
        if count <= 0 then
            raise (ArgumentOutOfRangeException("Нельзя остановить поток, если значение = 0"))
        event.WaitOne() |> ignore

    /// Decreasing counter and realising thread if counter = 0
    member this.Signal () = 
        count <- max (count - 1) 0
        if count = 0 then
            event.Set() |> ignore
     
    interface IDisposable with
        member this.Dispose () =
            event.Dispose()
    