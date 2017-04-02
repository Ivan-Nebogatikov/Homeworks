module Program

/// Class for Operation System
type OS(x) =
    /// Value from 0 to 1 - probability of infection 
    member val probabilityOfInfection = x with get, set

/// Class for computers
type Computer(os:OS, infection, neighbours) = 

    /// Value from 0 to 1 - probability of infection 
    member val IngefectionChance = os.probabilityOfInfection with get, set

    /// Is this computer already infected
    member val Infected = infection with get, set

    /// List of neighbours of this computers
    member val Neighbours = neighbours with get, set

/// Class for network
type Network(computers:list<Computer>) =
    let random = System.Random()

    /// Checking all computers for infections
    let Checking() = 
        let mutable count = 0
        for comp in computers do 
            if (comp.Infected) then
                count <- count + 1
                printfn "Компьтер заражен"
            else
                printfn "Компьтер не заражен"
        System.Console.WriteLine()
        (count = computers.Length) || (count = 0)

    /// Do computers infections
    member this.Infections() = 
        let infectedComputer = computers |> List.filter (fun x -> x.Infected) 
        for comp in infectedComputer do 
            for neighbour in comp.Neighbours do
            if (random.NextDouble() <= computers.[neighbour].IngefectionChance) then 
                computers.[neighbour].Infected <- true
    
    /// Initiate network
    member this.StartNetwork() =
        if (not (Checking())) then
            this.Infections()
            this.StartNetwork()
    
    /// Computers in the network
    member val Computers = computers with get, set