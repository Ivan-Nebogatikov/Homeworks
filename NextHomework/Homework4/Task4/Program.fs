let isPrime x = 
    let devisors = seq { 2 .. int(sqrt <| float(x))}
    Seq.forall (fun y -> x % y <> 0) devisors

let primes =
    Seq.initInfinite (fun i -> i + 2) // Need to skip 0 and 1 for isPrime
    |> Seq.map (fun i -> i)
    |> Seq.filter isPrime

[<EntryPoint>]
printfn "%A" (Seq.toList (Seq.take 1000 primes))