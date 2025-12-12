namespace AOC

open System

module Day2 =
    let private parse (input: string) =
        input.Split ','
        |> Array.collect (fun range ->
            match range.Split '-' |> Array.toList with
            | [ first; last ] -> [| int64 first .. int64 last |]
            | other -> failwith $"Unexpected range split contained {other.Length} items")

    let private splitNumber (countSplits: int) (n: int64) =
        n
        |> string
        |> _.ToCharArray()
        |> Array.splitInto countSplits
        |> Array.map Int64.Parse

    let private splitsAreValid (countSplits: int) (n: int64) =
        n
        |> splitNumber countSplits
        |> Seq.distinct
        |> Seq.tryExactlyOne
        |> Option.isSome

    let part1 (input: string) =
        input
        |> parse
        |> Seq.filter (fun n -> (string n).Length % 2 = 0)
        |> Seq.filter (splitsAreValid 2)
        |> Seq.sum

    let part2 (input: string) =
        input
        |> parse
        |> Seq.filter (fun n ->
            let maxSplits = (string n).Length
            [| 2..maxSplits |] |> Array.exists (fun splits -> splitsAreValid splits n))
        |> Seq.sum
