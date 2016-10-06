/// Returns option with value of element index or None option if element does not exist in list
let rec firstIndex list number = 
    let rec listFinder list index = 
        match list with
        | [] -> None
        | head :: tail when head = number -> Some(index)
        | head :: tail -> listFinder tail (index + 1)
    listFinder list 0

[<EntryPoint>]
printfn "%A" (firstIndex [1; 2; 2] 3)
printfn "%A" (firstIndex [4..100] 10)
printfn "%A" (firstIndex [11] 11)
printfn "%A" (firstIndex [] -431)