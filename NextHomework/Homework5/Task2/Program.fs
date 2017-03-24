module Program
    
let func = (*) >> List.map

let funcDefault x l = List.map (fun y -> y * x) l