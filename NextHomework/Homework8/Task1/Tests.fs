module Tests

open NUnit.Framework
open FsUnit
open Program

[<Test>]
let ``Codeforces test`` () = 
    debugLengthList <- []
    sizeOfAllReferencedPages "http://codeforces.com"
    debugLengthList |> should not' (be Empty)
    for x in debugLengthList do
        x |> should be (greaterThan 0)

        
[<Test>]
let ``E-maxx test`` () = 
    debugLengthList <- []
    sizeOfAllReferencedPages "http://e-maxx.ru/"
    debugLengthList |> should not' (be Empty)
    for x in debugLengthList do
        x |> should be (greaterThan 0)

[<Test>]
let ``Regex site test`` () = 
    debugLengthList <- []
    sizeOfAllReferencedPages "http://www.regular-expressions.info/catastrophic.html"
    debugLengthList |> should not' (be Empty)
    for x in debugLengthList do
        x |> should be (greaterThan 0)