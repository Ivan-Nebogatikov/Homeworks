/// Automatic reverse function
let listReverse list = List.rev list

/// Handmade list reverse function 
let rec reverse list =
    match list with
    | [] -> []
    | head :: tail -> reverse tail @ [head]

let list = [7; 4; 6; 8; 3; -1; -2; 44; 654]

[<EntryPoint>]
printfn "Исходный список: %A. Обращенный автоматически: %A" list (listReverse list)
printfn "Обращенный вручную: %A. Совпадение: %b" (reverse list) ((reverse list).Equals(listReverse list)) 