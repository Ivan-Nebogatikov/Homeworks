/// Creation list function
let listCreator = List.init 5(fun i -> pown 2 i)

[<EntryPoint>]
printfn "Созданный список: %A" listCreator