namespace AOC

open System

module Day3 =
    let private parse (input: string) =
        input.Trim().Split "\n"
        |> Array.filter (String.IsNullOrEmpty >> not)
        |> Array.map (
            _.ToCharArray()
            >> Array.map (fun battery -> int battery - int '0')
            >> Array.indexed
        )

    let rec private chooseBatteries (chosenBatteries: (int * int) array) (chooseCount: int) (bank: (int * int) array) =
        if chosenBatteries.Length = chooseCount then
            chosenBatteries
        else
            let leftToChoose = chooseCount - chosenBatteries.Length
            let takeFirst = (bank.Length - leftToChoose) + 1

            let best = bank |> Array.take takeFirst |> Array.maxBy snd

            let remainingBank = bank |> Array.filter (fun (idx, _) -> idx > fst best)
            chooseBatteries (Array.append chosenBatteries [| best |]) chooseCount remainingBank

    let private batteriesToInt batteries =
        batteries
        |> Array.map (snd >> string)
        |> String.concat String.Empty
        |> Int64.Parse

    let combineBatteries chosenBatteries chooseCount =
        chooseBatteries chosenBatteries chooseCount >> batteriesToInt

    let part1 (input: string) =
        input |> parse |> Array.map (combineBatteries [||] 2) |> Array.sum

    let part2 (input: string) =
        input |> parse |> Array.map (combineBatteries [||] 12) |> Array.sum
