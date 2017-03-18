/// Index of max pair sum. None if list contains less then 2 elements
let indexOfMaxSum list = 
    let rec sum listTail index maxIndex elem maxSum = 
        match listTail with
        | [] -> maxIndex
        | head::tail when (head + elem > maxSum)->  sum tail (index + 1) index head (head + elem)
        | head::tail ->  sum tail (index + 1) maxIndex head maxSum
    match list with
    | [] -> None
    | [a] -> None
    | _ -> Some(sum (List.tail list) 0 -1 (List.head list) System.Int32.MinValue + 1)

[<EntryPoint>]
printfn "%A" <| indexOfMaxSum [7; 3; 4]
printfn "%A" <| indexOfMaxSum [1; 5; 6; 2]
let bigList = List.init 100000 (fun i -> i)
printfn "%A" <| indexOfMaxSum bigList
printfn "%A" <| indexOfMaxSum [1]
printfn "%A" <| indexOfMaxSum []