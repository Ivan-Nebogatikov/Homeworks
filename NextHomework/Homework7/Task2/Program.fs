module Program

/// Helper function for parsing strings
let parse s =
    let success, result = System.Int32.TryParse(s)
    if success then
        Some(result)
    else
        None

/// Workflow for string calculations
type WorkflowBuilder () =
    member this.Bind (str, next) =
        let result = parse str
        match result with
        | Some(y) -> next y
        | None -> None
    
    member this.Return (x:obj) =
        match x with
        | :? int as value -> Some(value)
        | :? string as str -> parse str
        | _ -> None