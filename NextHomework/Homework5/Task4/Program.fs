module Program

type Variable = string

type Term =
    | Var of Variable
    | Appl of Term * Term
    | Abstr of Variable * Term

/// Support function for applications
let rec applReduction a b = 
    match a with
    | Var (var) ->  Appl(a, b)
    | Abstr (x, l) -> 
        let rec recSubstitution expr = 
            match expr with
            | Var (var) -> 
                if var = x then
                    b
                else
                    expr
            | Appl (f, s) -> Appl ((recSubstitution f), (recSubstitution s))
            | Abstr (f, s) -> Abstr (f, (recSubstitution s))
        recSubstitution l
    | Appl (x, l) -> 
        Appl(applReduction x b, l)

/// Main function for beta reduction
let rec reduction term =
    match term with
    | Var (_) -> term
    | Appl (x, t) -> 
        match x with 
        | Var (v) -> term
        | _ -> reduction <| applReduction x t
    | Abstr (a, b) -> term

/// Расходящийся комбинатор - зависает как и должен
[<EntryPoint>]
printfn "%A" <| reduction (Appl(Abstr("x", Appl(Var("x"), Var("x"))), Abstr("x", Appl(Var("x"), Var("x")))))