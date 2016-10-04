/// Factorial number calculation
let rec factorial n = 
    match n with 
    | _ when n < 1 -> 1
    | _ -> factorial(n - 1) * n

/// Output for testing
let rec output n = 
    if n >= 1 then 
        printfn "Факториал числа %i это %i" n (factorial n)
        output(n - 1)

let list = List.init 5(fun i -> pown 2 i)
[<EntryPoint>]
output 11
    