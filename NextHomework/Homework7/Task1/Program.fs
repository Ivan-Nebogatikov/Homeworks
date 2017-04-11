let roundHelp (x : float) (n : int) = System.Math.Round(x, n)

type WorkflowBuilder (n) = 
    member this.Bind (x, next) = 
        next <| roundHelp x n

    member this.Return x =
        roundHelp x n 

let test =
    WorkflowBuilder 3 {
        let! a = 2.0 / 12.0
        let! b = 3.5
        return a / b
    }

printfn "%A" test