module Program

/// Struct for node for tree
type Node<'a> = 
    | Empty 
    | Vertex of 'a * Node<'a> * Node<'a>

/// Helper to delete function
let rec findInOrderPredecessor tree =
    match tree with
    | Empty -> Empty
    | Vertex (_, _, Empty) -> tree
    | Vertex (_, _, right) -> findInOrderPredecessor right 

/// Generic enumerator for tree 
type TreeIterator<'a> (root: Node<'a>) = 
    let mutable index = -1
    let rec listTree tree list = 
        match tree with 
        | Empty -> list
        | Vertex (value, left, right) -> value::((listTree left list)@(listTree right list))
    let mutable list = listTree root []
    interface System.Collections.Generic.IEnumerator<'a> with
        member this.MoveNext() = 
            index <- index + 1
            list.Length > index
        member this.Reset() = 
            index <- -1
        member this.Current = list.[index]
        member this.Dispose() = ()
        member this.get_Current() = (this :> System.Collections.Generic.IEnumerator<'a>).Current :> obj

/// Class for binary tree
type Tree<'a when 'a: comparison> () =
    let mutable root = Empty
    
    let rec insert value = function
        | Empty -> Vertex(value, Empty, Empty)
        | Vertex(v, left, right) when value < v -> Vertex(v, insert value left, right)
        | Vertex(v, left, right) when value > v -> Vertex(v, left, insert value right)
        | Vertex(_, _, _) as n -> n
        
    let rec delete value tree =
      match tree with
      | Empty -> Empty
      | Vertex (value', left, right) when value < value' ->
            let left' = delete value left
            Vertex (value', left', right)
      | Vertex (value', left, right) when value > value' ->
            let right' = delete value right
            Vertex (value', left, right')
      | Vertex (_, Empty, Empty) ->
            Empty
      | Vertex (_, left, Empty) -> 
            left
      | Vertex (_, Empty, right) ->
            right
      | Vertex (_, left, right) ->
            let nodeToDelete = findInOrderPredecessor left
            match nodeToDelete with
            | Empty -> failwith "Такого не может быть!"
            | Vertex(value', _, _) ->
                let left' = delete value' left
                Vertex (value', left', right)

    let rec print = function
        | Empty -> printf "Empty "
        | Vertex(v, left, right) ->
            printf "%A " v
            print(left)
            print(right)
            
    let rec equal value = function
        | Empty -> false
        | Vertex(v, left, right) -> (v = value) || (equal value left) || (equal value right)

    /// Function for print all tree elements
    member this.Print = print root

    /// Checking is element contains in the tree
    member this.Contains value = equal value root

    /// Adding new value to the tree
    member this.Add (value) = 
        root <- insert value root
    
    /// Deleting value from the tree
    member this.Remove value = 
        root <- delete value root
    
    /// Checking is tree is empty
    member this.IsEmpty = root = Empty

    /// Realisation for enumerator interface
    interface System.Collections.Generic.IEnumerable<'a> with
        member this.GetEnumerator() = new TreeIterator<'a>(root):>System.Collections.Generic.IEnumerator<'a>
        member this.GetEnumerator() = (new TreeIterator<'a>(root):>System.Collections.Generic.IEnumerator<'a>) :> System.Collections.IEnumerator
