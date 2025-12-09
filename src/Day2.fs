namespace AOC

type Range = { FirstId: int64; LastId: int64 }

module Day2 =
    let private parse (input: string) =
        input.Split ','
        |> Array.map (fun range ->
            match range.Split '-' |> Array.toList with
            | [ first; last ] ->
                { FirstId = int64 first
                  LastId = int64 last }
            | other -> failwith $"Unexpected range split contained ${other.Length} items")

    let part1 (input: string) =
        input
        |> parse
        |> Seq.collect (fun r ->
            seq {
                for x in [ r.FirstId .. r.LastId ] do
                    yield x
            })
        |> Seq.filter (fun x -> (string x).Length % 2 = 0)
        |> Seq.filter (fun x ->
            let s = string x
            let firstHalf, secondHalf = s.ToCharArray() |> Array.splitAt (s.Length / 2)
            firstHalf = secondHalf)
        |> Seq.sum
