namespace AOC

open System
open System.Text.RegularExpressions

type Op =
    | Add
    | Mult

module Day6 =
    let private parse (lineSplit: string -> string array) (input: string) =
        let lines = input.Trim().Split "\n" |> Array.rev

        let operators =
            lines
            |> Array.head
            |> fun opLine ->
                opLine
                |> lineSplit
                |> Array.indexed
                |> Array.filter (fun (_, op) -> not <| String.IsNullOrWhiteSpace op)
                |> Array.map (fun (idx, opString) ->
                    match opString with
                    | "+" -> idx, Add
                    | "*" -> idx, Mult
                    | other -> failwith $"Unrecognized operator: {other}")

        let numbers =
            lines
            |> Array.tail
            |> Array.rev
            |> Array.collect (fun nLine ->
                nLine
                |> lineSplit
                |> Array.indexed
                |> Array.filter (fun (_, n) -> String.IsNullOrWhiteSpace n |> not))
            |> Array.groupBy fst
            |> Array.map snd

        operators, numbers

    let private doMath problems =
        problems
        |> Array.map (fun (op, numbers) ->
            match op with
            | Add -> Array.sum numbers
            | Mult -> Seq.reduce (*) numbers)
        |> Array.sum

    let part1 (input: string) =
        let input = Regex.Replace(input, "[ ]+", " ")

        Regex.Replace(input, "\n\s+", "\n")
        |> parse (fun l -> l.Split " ")
        ||> Array.zip
        |> Array.map (fun ((_, op), numbers) -> op, Array.map (snd >> int64) numbers)
        |> doMath

    let part2 (input: string) =
        let operators, numbers =
            input |> parse (fun l -> l.ToCharArray() |> Array.map string)

        numbers
        |> Array.map (fun numbers ->
            let op =
                operators
                |> Array.filter (fun (idx, _) -> idx <= (numbers |> Array.head |> fst))
                |> Seq.maxBy fst

            let x = String.Join(String.Empty, numbers |> Array.map snd) |> int64
            op, x)
        |> Array.groupBy fst
        |> Array.map (fun ((_, op), xs) -> op, Array.map snd xs)
        |> doMath
