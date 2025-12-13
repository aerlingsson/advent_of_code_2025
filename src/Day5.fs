namespace AOC

open System

type Range = { From: int64; To: int64 }

module Day5 =
    let private parse (input: string) =
        let ranges, ids =
            match input.Split "\n\n" with
            | x when x.Length = 2 -> x[0], x[1]
            | other -> failwith $"Unexpected amount of splits: {other.Length}"

        let ranges =
            ranges.Trim().Split "\n"
            |> Array.map (fun r ->
                match r.Split "-" with
                | x when x.Length = 2 -> { From = int64 x[0]; To = int64 x[1] }
                | other -> failwith $"Unexpected amount of splits: {other.Length}")

        let ids = ids.Trim().Split "\n" |> Array.map int64

        ranges, ids

    let part1 (input: string) =
        let ranges, ids = parse input

        ids
        |> Array.filter (fun id -> Array.exists (fun range -> id >= range.From && id <= range.To) ranges)
        |> Array.length

    let part2 (input: string) =
        let ranges = input |> parse |> fst |> set

        ranges
        |> Set.fold
            (fun ranges range ->
                let haveOverlap =
                    ranges |> Seq.filter (fun r -> r.From <= range.To && r.To >= range.From) |> set

                let minFrom = haveOverlap |> Seq.map _.From |> Seq.min
                let maxTo = haveOverlap |> Seq.map _.To |> Seq.max

                Set.difference ranges haveOverlap |> Set.add { From = minFrom; To = maxTo })
            ranges
        |> Seq.map (fun r -> r.To - r.From + 1L)
        |> Seq.sum
