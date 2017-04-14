module Program

/// Helper function for generate subsequence
let seqGenerator n = Seq.init n (fun i -> n)

/// Sequence from task
let seqResult = Seq.concat <| Seq.initInfinite (fun n -> seqGenerator n) 

seqResult |> Seq.take 50 |> Seq.iter (fun item -> printf "%A " item)

    