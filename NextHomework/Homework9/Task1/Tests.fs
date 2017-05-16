module Tests

open FsUnit
open NUnit.Framework
open System.Threading
open Program

[<Test>]
let ``Test with simple CountdownEvent should finished corectly`` () = 
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
    Thread.Sleep 200
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
    
[<Test>]
let ``Test with race condition 2`` () = 
    for i in 1..20 do
        let event = new MyCountdownEvent(2)  
        let mutable counter = 0
        let thread1 = 
            async {
                event.Signal()
                event.Wait()
                counter <- counter + 10
            }
        let thread2 = 
            async {
                event.Signal()
                event.Wait()
                counter <- counter + 1
            }
        [thread1; thread2]|> Async.Parallel |> Async.RunSynchronously |> ignore
        Thread.Sleep 200
        counter |> should equal 11