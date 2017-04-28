module Program

open System
open System.IO

/// Main function for user input
let rec userInterface dictionary =
    printfn ""
    printfn "2 - добавить запись (имя и телефон)"
    printfn "3 - найти телефон по имени"
    printfn "4 - найти имя по телефону"
    printfn "5 - вывести всё текущее содержимое базы"
    printfn "6 - сохранить текущие данные в файл"
    printfn "7 - считать данные из файла"
    let input = Console.ReadLine()
    let success, result = System.Int32.TryParse(input)
    if not success then
        printfn "Неверный ввод!"
        userInterface dictionary
    else
        match result with
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
            try
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
            with
            | :? FileNotFoundException ->
                printfn "Файл не найден"
                userInterface dictionary 
            | _ ->
                printfn "Ошибка чтения"
                userInterface dictionary
        | _ -> 
            printfn "Заходите ещё"
        
[<EntryPoint>]
userInterface []