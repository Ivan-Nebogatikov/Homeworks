/// Returns first index of number in list or -1 if element does not exist
let rec firstIndex list number = 
    let rec listFinder list index = 
        match list with
        | [] -> -1
        | head :: tail when head = number -> index
        | head :: tail -> listFinder tail (index + 1)
    listFinder list 0


[<EntryPoint>]
printfn "%i" (firstIndex [1; 2; 2] 3)
printfn "%i" (firstIndex [4..100] 10)
printfn "%i" (firstIndex [11] 11)
printfn "%i" (firstIndex [] -431)