﻿module Tests

open Program
open FsUnit
open NUnit.Framework
open FsCheck

[<Test>]
let ``Ascending sequence test`` () = 
    Check.QuickThrowOnFailure (Seq.take 1000 seqResult |> should be ascending)

[<Test>]
let ``Autogenerated test for containing random number from 1 to 15`` () = 
    Check.QuickThrowOnFailure (fun x -> (x < 1) || (x > 15) || Seq.contains x <| Seq.take 2000 seqResult)