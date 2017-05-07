open Program
open FsUnit
open NUnit.Framework

[<Test>]
let ``Test with 3 connected computers``() = 
    let windows = OS(0.5)
    let linux = OS(0.9)
    let mac = OS(0.3)
    let computers = [Computer(windows, false, [1; 2]); Computer(linux, false, [0; 2]); Computer(mac, true, [0; 1])]
    let network = Network(computers)

    network.StartNetwork()
    // Network finished. All computers are infectioned

    
[<Test>]
let ``Test with 4 connected computers``() = 
    let bestOsEver = OS(0.01)
    let computers = [Computer(bestOsEver, false, [1; 2; 3]); Computer(bestOsEver, false, [0; 2]); Computer(bestOsEver, true, [0; 1; 3]); Computer(bestOsEver, true, [0; 3])]
    let network = Network(computers)

    network.StartNetwork()
    // Network finished. All computers are infectioned
    
[<Test>]
let ``Test with 5 connected computers``() = 
    let virusOs  = OS(0.99)
    let pro = OS(0.100500)
    let русскаяОсь = OS(0.005)
    let computers = [Computer(pro, false, [5]); 
                     Computer(virusOs, false, [5]); 
                     Computer(virusOs, false, [5]); 
                     Computer(pro, false, [5]); 
                     Computer(virusOs, true, [5]); 
                     Computer(русскаяОсь, false, [0; 1; 2; 3; 4])]
    let network = Network(computers)

    network.StartNetwork()
    // Network finished. All computers are infectioned
    
[<Test>]
let ``Test with 5 connected computers and without viruses``() = 
    let virusOs  = OS(0.99)
    let pro = OS(0.100500)
    let русскаяОсь = OS(0.005)
    let computers = [Computer(pro, false, [5]); 
                     Computer(virusOs, false, [5]); 
                     Computer(virusOs, false, [5]); 
                     Computer(pro, false, [5]); 
                     Computer(virusOs, false, [5]); 
                     Computer(русскаяОсь, false, [0; 1; 2; 3; 4])]
    let network = Network(computers)

    network.StartNetwork()
    // Network finished. There are no viruses in the system

[<Test>]
let ``Test for neightbours infections``() = 
    let windows = OS(float 1)
    let linux = OS(float 1)
    let mac = OS(float 1)
    let computers = [Computer(windows, true, [1]); 
                     Computer(linux, false, [0; 2]); 
                     Computer(mac, false, [1])]
    let network = Network(computers)
    network.Computers.[0].Infected |> should be True
    network.Computers.[1].Infected |> should be False
    network.Computers.[2].Infected |> should be False
    network.Infections()
    network.Computers.[0].Infected |> should be True
    network.Computers.[1].Infected |> should be True
    network.Computers.[2].Infected |> should be False

[<Test>]
let ``Test for not infected system``() = 
    let windows = OS(float 1)
    let linux = OS(float 1)
    let mac = OS(float 1)
    let computers = [Computer(windows, false, [1]); 
                     Computer(linux, false, [0; 2]); 
                     Computer(mac, false, [1])]
    let network = Network(computers)
    network.Computers.[0].Infected |> should be False
    network.Computers.[1].Infected |> should be False
    network.Computers.[2].Infected |> should be False
    network.Infections()
    network.Computers.[0].Infected |> should be False
    network.Computers.[1].Infected |> should be False
    network.Computers.[2].Infected |> should be False