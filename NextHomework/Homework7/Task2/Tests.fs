module Tests

open Program
open NUnit.Framework
open FsUnit
open FsCheck

[<Test>]
let ``Test from task 1`` () = 
    WorkflowBuilder () {
        let! x = "1"
        let! y = "2"
        let z = x + y
        return z
    } |> should equal <| Some(3)

[<Test>]
let ``Test from task 2`` () = 
    WorkflowBuilder () {
        let! x = "1"
        let! y = "Ъ"
        let z = x + y
        return z
    } |> should equal <| None

[<Test>]
let ``Simple calculator`` () = 
    WorkflowBuilder () {
        return "1"
    }|> should equal <| Some (1)

[<Test>]
let ``Simple error calculator`` () = 
    WorkflowBuilder () {
        return "o"
    }|> should equal <| None

[<Test>]
let ``Error calculator`` () = 
    WorkflowBuilder () {
        let! x = "1"
        let! y = "1323.2331r"
        let z = x / y
        return z
    }|> should equal <| None

[<Test>]
let ``Complex calculator`` () = 
    WorkflowBuilder () {
        let! x = "0"
        let! y = "22"
        let! z = "2"
        let b = x + y
        let a = b - z
        let c = a / z
        let d = -c
        return -d
    }|> should equal <| Some(10)