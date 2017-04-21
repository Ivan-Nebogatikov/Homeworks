module Program

/// Help function for rounding
let roundHelp (x : float) (n : int) = System.Math.Round(x, n)

/// Workflow for rounded calculations
type WorkflowBuilder (n) = 
    member this.Bind (x, next) = 
        next <| roundHelp x n

    member this.Return x =
        roundHelp x n 