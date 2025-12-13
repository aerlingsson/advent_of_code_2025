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

    let part1 (input: string) =
        input
        |> parse
        |> Array.map (fun bank ->
            let best = bank |> Array.take (bank.Length - 1) |> Array.maxBy snd

            let secondBest =
                bank |> Array.filter (fun (idx, _) -> idx > fst best) |> Array.maxBy snd

            Int32.Parse $"{snd best}{snd secondBest}")
        |> Array.sum
