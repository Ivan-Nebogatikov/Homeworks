module Program

let isBracket char =
    match char with
    | '{' | '}' | '(' | ')' | '[' | ']' -> true
    | _ -> false

/// Function for checking brackets in string
let bracketCheck str = 
    let brackets = List.ofSeq <| String.filter isBracket str
    let rec listCheck list stack = 
        match list with
        | [] -> List.isEmpty stack
        | head::tail -> 
            match head with
            | '{' | '[' | '(' as x -> listCheck tail (x::stack)
            | _ -> 
                match stack with
                | [] -> false
                | headStack::tailStack -> 
                    if ((headStack = '{' && head = '}') || (headStack = '(' && head = ')') || (headStack = '[' && head = ']')) then
                        listCheck tail tailStack
                    else
                        false
    listCheck brackets []