module Test

open Program
open FsUnit
open NUnit.Framework
open FsCheck

[<Test>]
let ``Test from task`` () =
    WorkflowBuilder 3 {
        let! a = 2.0 / 12.0
        let! b = 3.5
        return a / b
    } |> should equal 0.048
    
[<Test>]
let ``Simple rounding`` () =
    WorkflowBuilder 5 {
        let! a = 1.0 / 3.0
        return a + a
    } |> should equal 0.66666
    
[<Test>]
let ``Division by 0 should return infinity`` () =
    WorkflowBuilder 5 {
        let! a = 1.0 / 0.0
        let! b = 4.4 * 4.0
        return a + b
    } |> should equal <| 4.0 / 0.0

[<Test>]
let ``Complex test without fractions`` () =
    WorkflowBuilder 0 { 
        let! a = 1.0 * 1.0
        let! b = 4.4 / 2.0
        let! c = a + b
        let! d = 1.0 / b
        let! e = d - c
        return e + 1.6
    } |> should equal -1.0