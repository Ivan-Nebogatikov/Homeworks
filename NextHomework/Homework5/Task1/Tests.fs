open Program
open FsUnit
open NUnit.Framework

[<Test>]
let ``Incorrect brackets``() = (bracketCheck "ololol()(){}{}}{}{}") |> should not' (be True)

[<Test>]
let ``Correct brackets``() = (bracketCheck "111{ds(deaef)dffe[34]dsad[[]]ok}dw") |> should be True

[<Test>]
let ``Correct brackets 2``() = (bracketCheck "()") |> should be True

[<Test>]
let ``Incorrect brackets 2``() = (bracketCheck "][") |> should not' (be True)

[<Test>]
let ``Correct string with only brackets``() = (bracketCheck "{}{}{}{{{((([[[]]])))}}}([])") |> should be True