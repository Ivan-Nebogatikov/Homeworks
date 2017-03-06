/// Merge sort function
let rec mergeSort list = 
    let rec merge firstList secondList acc = 
        match firstList, secondList with
        | [], [] -> acc
        | head::tail, [] | [], head::tail -> merge tail [] (acc @ [head])
        | fHead::fTail, sHead::sTail when fHead < sHead -> merge fTail  secondList (acc @ [fHead])
        | fHead::fTail, sHead::sTail -> merge firstList  sTail (acc @ [sHead])
    match list with
    | [] -> list
    | [a] -> list
    | _ ->
        let first, second = List.splitAt(List.length list / 2) list
        merge (mergeSort first) (mergeSort second) []

[<EntryPoint>]
printfn "%A" (mergeSort [1; 3; 2; 4])
printfn "%A" (mergeSort [-5; 10; 0; 7; 6; -8; 7804])
let bigList = List.init 10000 (fun i -> -i)
printfn "%A" <| ((mergeSort bigList) = (List.rev bigList))