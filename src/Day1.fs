namespace AOC

open System
open System.Text.RegularExpressions

module Day1 =
    let private parse (input: string) =
        input.Split "\n"
        |> Array.filter (String.IsNullOrWhiteSpace >> not)
        |> Array.map (fun l ->
            let m = Regex.Match(l, "(\w)(\d*)")
            let leftOrRight, count = m.Groups[1].Value, int m.Groups[2].Value
            if leftOrRight = "L" then -count else count)

    let private calcDialPos oldDialPos rot =
        let sum = oldDialPos + rot
        if sum < 0 then (100 - abs (sum % 100)) % 100 else sum % 100

    let part1 (input: string) =
        input
        |> parse
        |> Array.fold
            (fun (dialPos, zeros) n ->
                let newDialPos = calcDialPos dialPos n
                newDialPos, (if newDialPos = 0 then zeros + 1 else zeros))
            (50, 0)
        |> snd

    let part2 (input: string) =
        input
        |> parse
        |> Array.fold
            (fun (dialPos, zeros) rot ->
                let sum = dialPos + rot
                let res = if sum <= 0 && dialPos > 0 then abs sum + 100 else abs sum
                let newZeros = res / 100
                calcDialPos dialPos rot, zeros + newZeros)
            (50, 0)
        |> snd
