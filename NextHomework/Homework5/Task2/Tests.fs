open Program
open FsUnit
open FsCheck
open NUnit.Framework

[<Test>]
let ``Single random test``() = Check.QuickThrowOnFailure (fun x l -> func x l = funcDefault x l)