open NUnit.Framework
open FsUnit
open FsCheck

let isPrime x = 
    let divisors = seq { 2 .. int(sqrt <| float(x)) }
    Seq.forall (fun y -> x % y <> 0) divisors

let primes =
    Seq.initInfinite (fun i -> i + 2) |> Seq.filter isPrime

let listOfPrimes x =  Seq.toList <| Seq.take (int x) primes
    
Check.Quick (fun (x:uint32) -> listOfPrimes x |> should be unique)
Check.Quick (fun (x:uint32) -> listOfPrimes x |> should be ascending)
Check.Quick (fun (x:uint32) -> listOfPrimes x |> should not' (contain 6))
Check.Quick (fun (x:uint32) -> listOfPrimes x |> should not' (contain 12))
Check.Quick (fun (x:uint32) -> listOfPrimes x |> should not' (contain 100))
Check.Quick (fun (x:uint32) -> listOfPrimes x |> should not' (contain 4))
Check.Quick (fun (x:uint32) -> listOfPrimes x |> should not' (contain 26))
Check.Quick (fun (x:uint32) -> listOfPrimes x |> should not' (contain 49))

[<EntryPoint>]
printfn "%A" (Seq.toList (Seq.take 1000 primes))