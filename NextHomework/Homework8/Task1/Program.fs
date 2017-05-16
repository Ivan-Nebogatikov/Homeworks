module Program

open System.Net
open System.IO
open System.Text.RegularExpressions

/// Debug list
let mutable debugLengthList = []

/// Function for downloading main page
let getPage (url : string) = 
    async {
        let request = WebRequest.Create(url)
        use! response = request.AsyncGetResponse()
        use stream = response.GetResponseStream()
        use reader = new StreamReader(stream)
        return reader.ReadToEnd()
    }

/// Function for getting all references
let getReferences page = 
    let pattern = "<a href=\"http://(.+?)\">"
    let regex = new Regex(pattern, RegexOptions.IgnoreCase)
    let matchesSeq : seq<Match> = (Seq.cast <| regex.Matches page)
    matchesSeq |> Seq.map (fun x -> x.Value.Substring(9, x.Value.Length - 11)) |> Seq.distinct // Deleting <a href="">

/// Function for printing size of page
let downloadPage (url : string) = 
    async {
        try 
            let! html = getPage url
            debugLengthList <- html.Length::debugLengthList
            do printfn "На странице %A: %A символов" url html.Length
        with
        | exc ->
            printfn "Страница %A недоступна" url 
    }

/// Main function for getting all referenced pages and their size
let sizeOfAllReferencedPages url = 
    url 
    |> getPage
    |> Async.RunSynchronously
    |> getReferences 
    |> Seq.map (downloadPage) 
    |> Async.Parallel
    |> Async.RunSynchronously
    |> ignore