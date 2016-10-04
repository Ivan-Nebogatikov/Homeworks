/// Checks are all list elements different
let areDifferent list = 
    let sortedList = List.sort list
    let rec hasEqual list = 
        match list with 
        | [] -> false
        | head :: tail when (not tail.IsEmpty && tail.Head = head) -> true
        | head :: tail -> hasEqual tail
    not (hasEqual sortedList)

[<EntryPoint>]
printfn "%b" (areDifferent [1; 2; 4; 2])
printfn "%b" (areDifferent [1; 2; 4; 10; 20])
printfn "%b" (areDifferent [])
printfn "%b" (areDifferent [-10; 0; 10])
printfn "%b" (areDifferent [-10; -10])