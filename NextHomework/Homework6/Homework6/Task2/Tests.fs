open FsUnit
open NUnit.Framework
open Program

[<Test>]
let ``Add test`` () = 
    let tree = Tree<int>()
    tree.IsEmpty |> should be True
    tree.Add 3
    tree.IsEmpty |> should be False
    tree.Add 1
    tree.Add 4
    tree.Contains 3 |> should be True
    tree.Contains 1 |> should be True
    tree.Contains 4 |> should be True
    tree.Contains 2 |> should be False
    tree.IsEmpty |> should be False

[<Test>]
let ``Delete test`` () = 
    let tree = Tree<float>()
    tree.Add 4.21
    tree.Add <| float 421
    tree.Add <| float 42
    tree.Add <| float 1
    tree.Add 1000.500
    tree.Remove 4.21
    tree.Contains 4.21 |> should be False
    tree.Contains <| float 421 |> should be True
    tree.Contains <| float 42 |> should be True
    tree.Contains <| float 1 |> should be True
    tree.Remove <| float 421
    tree.Contains <| float 421 |> should be False
    tree.Contains <| float 1 |> should be True
    tree.Remove <| float 1
    tree.Contains <| float 421 |> should be False
    tree.Contains <| float 1 |> should be False
    tree.Contains <| float 42 |> should be True
    tree.Remove <| float 42
    tree.Contains <| float 42 |> should be False
    tree.Contains 1000.500 |> should be True
    tree.Remove 1000.500
    tree.Contains 1000.500 |> should be False
    tree.IsEmpty |> should be True

[<Test>]
let ``Delete test 2`` () = 
    let tree = Tree<int>()
    tree.Add 4
    tree.Add 1
    tree.Add 3
    tree.Add 2
    tree.Add 5
    tree.Remove 4
    tree.Contains 3 |> should be True

[<Test>]
let ``Enumerator test`` () = 
    let tree = Tree<string>()
    tree.Add "lalal"
    tree.Add "dsa"
    tree.Add "ololo"
    tree.Add "tree.Add"
    tree.Add "a"
    tree.Add "zzzzz"
    let mutable count = 0
    for str in tree do
        count <- count + 1
        tree.Contains str |> should be True
    count |> should equal 6
    
[<Test>]
let ``Enumerator test 2`` () = 
    let tree = Tree<int>()
    tree.Add 2
    tree.Add 1
    tree.Add 4
    tree.Add 3
    tree.Add 5
    let mutable count = 0
    let mutable list = []
    for value in tree do
        count <- count + 1
        tree.Contains value |> should be True
        list <- value::list
    list |> should equal <| List.rev [2; 1; 4; 3; 5]
    count |> should equal 5