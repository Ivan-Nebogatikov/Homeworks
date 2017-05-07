/// Function for printing square (size n) of stars 
let squarePrint n = 
    let rec linePrint lineNumber = 
        if (lineNumber = n || lineNumber = 1) then
            List.iter (fun _ -> printf "*") <| List.init n (fun _ -> 0)
            printfn ""
        else
            printf "*"
            List.iter (fun _ -> printf " ") <| List.init (n - 2) (fun _ -> 0)
            printf "*"
            printfn ""
        if (lineNumber < n) then
            linePrint <| lineNumber + 1 
    linePrint 1

[<EntryPoint>]
let main argv = 
    squarePrint 9
    0 // return an integer exit code
