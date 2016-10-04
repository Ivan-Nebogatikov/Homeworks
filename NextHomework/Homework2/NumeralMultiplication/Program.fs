/// Funtion for calculation multiplication of numerals in number
let rec numberalMultiplication n = 
    match n with 
    | _ when (Operators.abs(n) < 10) -> Operators.abs(n)
    | _ ->
        let numeral = Operators.abs(n % 10)
        match numeral with
        | 0 -> 0
        | _ -> numberalMultiplication (n / 10) * numeral

    
[<EntryPoint>]
printfn "%i" (numberalMultiplication -11245)
printfn "%i" (numberalMultiplication 183350)
printfn "%i" (numberalMultiplication 777)
printfn "%i" (numberalMultiplication 0)