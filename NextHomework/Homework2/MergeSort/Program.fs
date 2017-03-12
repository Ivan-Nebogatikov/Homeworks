/// Merge sort function
let rec mergeSort list = 
    let rec merge firstList secondList acc = 
        match firstList, secondList with
        | [], [] -> List.rev acc
        | head::tail, [] | [], head::tail -> merge tail [] (head :: acc)
        | fHead::fTail, sHead::sTail when fHead < sHead -> merge fTail  secondList (fHead :: acc)
        | fHead::fTail, sHead::sTail -> merge firstList  sTail (sHead :: acc)
    match list with
    | [] -> list
    | [a] -> list
    | _ ->
        let first, second = List.splitAt(List.length list / 2) list
        merge (mergeSort first) (mergeSort second) []

[<EntryPoint>]
printfn "%A" (mergeSort [1; 3; 2; 4])
printfn "%A" (mergeSort [-5; 10; 0; 7; 6; -8; 7804])
let bigList = List.init 20000 (fun i -> -i)
printfn "%A" <| ((mergeSort bigList) = (List.rev bigList))