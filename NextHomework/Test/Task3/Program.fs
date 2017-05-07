module Program 

/// Class for stack
type Stack<'a>() = 
    let mutable list:List<'a> = []

    /// Returns top element from stack if stack is not empty else throw exception
    member this.Pop = 
        match list with
        | [] -> failwith "Popping from empty stack!"
        | head :: tail -> 
            list <- tail
            head
    
    /// Puts new element to stack
    member this.Push value =  list <- value::list

    /// Check if stack is empty
    member this.IsEmpty = List.isEmpty list
