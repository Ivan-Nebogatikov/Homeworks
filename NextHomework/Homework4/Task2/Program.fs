open FsCheck
open FsUnit

type Tree<'a> = 
    | Node of 'a * Tree<'a> * Tree<'a>
    | Tip of 'a

let rec treeMap func tree =  
    match tree with
    | Tree.Tip a -> Tree.Tip <| func a
    | Tree.Node (a, left, right) -> 
        Tree.Node (func a, treeMap func left, treeMap func right)

[<EntryPoint>]
treeMap ((+) 1) <| Node (12, Node (2, Tip 1, Tip 5), Tip 0) |> should equal <| Node (13, Node (3, Tip 2, Tip 6), Tip 1)
Check.Quick (fun y-> (treeMap (fun x-> x * x) y = treeMap (fun x -> pown x 2) y))
Check.Quick (fun y-> (treeMap (fun x-> x + x) y = treeMap ((*) 2) y))