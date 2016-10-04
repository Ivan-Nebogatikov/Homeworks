/// Handmade list reverse function 
let rec reverse list =
    match list with
    | [] -> []
    | head :: tail -> reverse tail @ [head]

/// Returns bool value: Is string palindorme
let isPalindrome string = 
    (Seq.toList string) = Seq.toList (reverse (Seq.toList string))

[<EntryPoint>]
printfn "%b" (isPalindrome "111")
printfn "%b" (isPalindrome "1121")
printfn "%b" (isPalindrome "55saas55")