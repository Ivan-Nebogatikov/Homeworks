﻿module Tests

open Program
open FsUnit
open NUnit.Framework
open FsCheck

let pushingAndPopping (stack:Stack<'a>) x =
    stack.Push x
    stack.Pop |> should equal x

[<Test>]
let ``Adding one element test`` () = 
    let stack = Stack<int>()
    Check.QuickThrowOnFailure (fun x -> pushingAndPopping stack x)

    
[<Test>]
let ``Popping from empty stack test`` () = 
    let stack = Stack<obj>()
    (fun () -> stack.Pop |> ignore) |> should throw typeof<System.Exception>

[<Test>]
let ``Complex stack test`` () = 
    let stack = Stack<float>()
    stack.IsEmpty |> should be True
    stack.Push 10.1
    stack.IsEmpty |> should be False
    stack.Push -1.0
    stack.Push 444.3
    stack.Pop |> should equal 444.3
    stack.IsEmpty |> should be False
    stack.Pop |> should not' (equal -1.1)
    stack.IsEmpty |> should be False
    stack.Pop |> should equal 10.1
    stack.IsEmpty |> should be True

let testHelpFunction (stack:Stack<'a>) list =
    List.iter (fun x -> stack.Push x) list
    List.iter (fun x -> stack.Pop |> should equal x) <| List.rev list

[<Test>]
let ``Autogenerated stack test`` () = 
    let stack = Stack<int>()
    Check.QuickThrowOnFailure (fun list -> testHelpFunction stack list)

