/// Fibonacci number calculation
let rec fibonacci n = 
    match n with 
    | 0 | 1 -> 1
    | _ -> fibonacci(n - 1) + fibonacci(n - 2)

/// Output for testing
let rec output n = 
    if n >= 0 then 
        printfn "%i - е число Фибоначчи это %i" n (fibonacci n)
        output(n - 1)
        
[<EntryPoint>]
output 40
    