open NUnit.Framework
open FsUnit

type Tree<'a> = 
    | Node of 'a * Tree<'a> * Tree<'a>
    | Tip of 'a

let rec treeMap func tree =  
    match tree with
    | Tree.Tip a -> Tree.Tip <| func a
    | Tree.Node (a, left, right) -> 
        Tree.Node (func a, treeMap func left, treeMap func right)

[<Test>]
let ``Adding 1 to all nodes`` () = treeMap ((+) 1) <| Node (12, Node (2, Tip 1, Tip 5), Tip 0) |> should equal <| Node (13, Node (3, Tip 2, Tip 6), Tip 1)

[<Test>]
let ``Set 0 to all nodes`` () = treeMap ((*) 0) <| Node (12, Tip 4, Tip -79) |> should equal <| Node (0, Tip 0, Tip 0)

[<Test>]
let ``Id func`` () = treeMap (fun x -> x) <| Node (2, Tip 4, Node(0, Tip 1, Tip 3)) |> should equal <| Node (2, Tip 4, Node(0, Tip 1, Tip 3))

[<Test>]
let ``Tip tree`` () = treeMap (fun x -> x * x) <| Tip 4 |> should equal <| Tip 16