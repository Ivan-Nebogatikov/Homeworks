/// Creation list function
let listCreator m n = List.filter (fun x -> x >= pown 2 m) (List.init (n + 1) (fun i -> pown 2 i))

[<EntryPoint>]
printfn "Созданный список: %A" (listCreator 2 20)