open FsCheck

let numberOfEvenMap list = List.sum <| List.map (fun x -> abs(x + 1) % 2) list

let numberOfEvenFilter list = List.length <| List.filter (fun x -> x % 2 = 0) list

let numberOfEvenFold list = List.fold (fun acc x -> acc + abs(x + 1) % 2) 0 list

/// Function for testing
let testFunc list = ((numberOfEvenMap list = numberOfEvenFilter list) && (numberOfEvenMap list = numberOfEvenFold list))

[<EntryPoint>]
Check.Quick testFunc