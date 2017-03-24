module Program

open System
open System.IO

/// Main function for user input
let rec userInterface dictionary =
    printfn ""
    let input = Console.ReadLine() |> int
    match input with
    | 2 -> 
        printf "Введите имя: "
        let name = Console.ReadLine()
        printf "Введите номер: "
        let number = Console.ReadLine()
        userInterface ((name, number)::dictionary)
    | 3 ->
        printf "Введите имя для поиска: "
        let name = Console.ReadLine()
        printfn "Список его номеров: "
        List.iter (printfn "%s" << snd) <| List.filter (fun x -> fst x = name) dictionary
        userInterface dictionary
    | 4 ->
        printf "Введите номер для поиска: "
        let number = Console.ReadLine()
        printfn "Список его имен: "
        List.iter (printfn "%s" << fst) <| List.filter (fun x -> snd x = number) dictionary
        userInterface dictionary
    | 5 ->
        printfn "Вся база: "
        List.iter (fun x -> printfn "%s: %s" (fst x) (snd x)) dictionary
        userInterface dictionary
    | 6 -> 
        use writer = new StreamWriter(File.OpenWrite("Dictionary.txt"))
        List.iter (fun (x, y) -> writer.WriteLine(x + " " + y)) dictionary
        writer.Close()
        printfn "Сохранено в файл"
        userInterface dictionary     
    | 7 -> 
        use reader = new StreamReader(File.OpenRead("Dictionary.txt"))
        let rec newDictionary acc = 
            if (not reader.EndOfStream) then 
                let pair = reader.ReadLine().Split[| |]
                newDictionary ((pair.[0], pair.[1])::acc)
            else
                acc
        let newDict = newDictionary [] 
        reader.Close()
        printfn "Загружено из файла"
        userInterface newDict
    | _ -> 
        printfn "Заходите ещё"
        
[<EntryPoint>]
userInterface []