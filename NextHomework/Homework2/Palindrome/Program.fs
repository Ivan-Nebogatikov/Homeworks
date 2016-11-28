/// Handmade list reverse function 
let reverse list =
    let rec listReverse list acc = 
        match list with
        | head :: tail -> listReverse tail (head :: acc)
        | [] -> acc
    listReverse list []

/// Returns bool value: Is string palindorme
let isPalindrome string = 
    (Seq.toList string) = Seq.toList (reverse (Seq.toList string))

[<EntryPoint>]
printfn "%b" (isPalindrome "111")
printfn "%b" (isPalindrome "1121")
printfn "%b" (isPalindrome "55saas55")
printfn "%b" (isPalindrome "55sadas55")
printfn "%b" (isPalindrome "55sadbas55")
