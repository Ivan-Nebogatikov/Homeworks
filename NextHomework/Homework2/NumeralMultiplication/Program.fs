/// Funtion for calculation multiplication of numerals in number
let numberalMultiplication x = 
    let rec multiplication n = 
        match n with 
        | _ when n < 10 -> n
        | _ ->
            let numeral = n % 10
            match numeral with
            | 0 -> 0
            | _ -> multiplication (n / 10) * numeral
    multiplication <| Operators.abs(x)

    
[<EntryPoint>]
printfn "%i" (numberalMultiplication -11245)
printfn "%i" (numberalMultiplication 183350)
printfn "%i" (numberalMultiplication 777)
printfn "%i" (numberalMultiplication 0)