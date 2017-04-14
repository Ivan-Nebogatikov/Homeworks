open FsCheck

type Tree<'a> = 
    | Node of ('a -> 'a -> 'a) * Tree<'a> * Tree<'a>
    | Tip of 'a

let rec calculate tree = 
    match tree with
    | Tree.Node (f, left, right) -> f (calculate left) (calculate right)
    | Tree.Tip a -> a

[<EntryPoint>]
Check.Quick <| fun x -> calculate (Tip x) = x
Check.Quick <| fun x y -> calculate (Node((+), Tip x, Tip y)) = x + y
Check.Quick <| fun x y -> calculate (Node((-), Tip x, Tip y)) = x - y
Check.Quick <| fun x y -> calculate (Node((*), Tip x, Tip y)) = x * y
Check.Quick <| fun x y -> y = 0 || calculate (Node((/), Tip x, Tip y)) = x / y
Check.Quick <| fun a b c d e f -> f = 0 || (calculate (Node ((-), Node((-), Node((+), Tip a, Tip b), Node ((*), Tip c, Tip d)), Node ((/), Tip e, Tip f))) = a + b - c * d - e / f)