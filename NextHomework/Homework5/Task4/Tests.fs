open Program
open FsUnit
open FsCheck
open NUnit.Framework

[<Test>]
let ``Test without reduction``() = reduction (Appl(Var("f"), Var("+"))) |> should equal (Appl(Var("f"), Var("+")))

[<Test>]
let ``Single var substitution``() = reduction (Appl(Abstr("x", Var("x")), Var("+"))) |> should equal (Var("+"))

[<Test>]
let ``Комбинатор самоприменимости``() = reduction (Appl(Abstr("x", Var("x")), Abstr("x", Var("x")))) |> should equal (Abstr("x", Var("x")))

[<Test>]
let ``Канцелятор``() = reduction (Appl(Appl(Abstr("x", Abstr("y", Var("y"))), Var("ololo")), Var("phph"))) |> should equal (Var("ololo"))

[<Test>]
let ``Второй элемент пары``() = reduction (Appl(Appl(Abstr("x", Abstr("y", Var("x"))), Var("ololo")), Var("phph"))) |> should equal (Var("phph"))

[<Test>]
let ``Plus substitution``() = reduction (Appl(Abstr("f", Abstr("x", Appl(Appl(Var("f"), Var("x")), Var("x")))), Var("+"))) |> should equal (Abstr("x", Appl(Appl(Var("+"), Var("x")), Var("x"))))

[<Test>]
let ``Correct strategy test``() = reduction (Appl(Abstr("x", Var("y")), Appl(Abstr("x", Appl(Appl(Var("x"), Var("x")), Var("x"))), Abstr("x", Appl(Appl(Var("x"), Var("x")), Var("x")))))) |> should equal (Var("y"))