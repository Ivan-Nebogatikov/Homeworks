module Tests

open FsUnit
open NUnit.Framework
open System.Threading
open Program

[<Test>]
let ``Test with simple CountdownEvent should finished corectly`` () = 
    let event = MyCountdownEvent(2)  
    let mutable counter = 0
    Async.Start(
        async{
            counter <- counter + 1
            event.Wait()
            counter <- counter + 1
        }
    )
    Thread.Sleep 100
    event.Signal()
    Thread.Sleep 100
    event.Signal()
    Thread.Sleep 100
    counter |> should equal 2

    
[<Test>]
let ``Test with simple CountdownEvent should break async thread at Wait`` () = 
    let event = new MyCountdownEvent(2)  
    let mutable counter = 0
    Async.Start(
        async{
            counter <- counter + 1
            event.Wait()
            counter <- counter + 1
        }
    )
    Thread.Sleep 100
    event.Signal()
    Thread.Sleep 100
    counter |> should equal 1

    
[<Test>]
let ``Test with 2 CountdownEvents`` () = 
    let event = new MyCountdownEvent(3)  
    let mutable counter = 0
    Async.Start(
        async{
            event.Wait()
            counter <- counter + 5
        }
    )
    Async.Start(
        async{
            event.Signal()
            event.Wait()
            counter <- counter + 4
        }
    )
    Thread.Sleep 100
    event.Signal()
    Thread.Sleep 100
    event.Signal()
    Thread.Sleep 100
    counter |> should equal 9

    
[<Test>]
let ``Test with race condition`` () = 
    let event = new MyCountdownEvent(3)  
    let mutable counter = 0
    Async.Start(
        async{
            event.Signal()
            event.Wait()
            event.Signal()
            counter <- counter + 5
        }
    )
    Async.Start(
        async{
            event.Signal()
            event.Wait()
            event.Signal()
            counter <- counter + 4
        }
    )
    Thread.Sleep 100
    event.Signal()
    Thread.Sleep 100
    counter |> should equal 9