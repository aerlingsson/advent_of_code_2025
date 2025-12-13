namespace AOC

open System

type Pos = { Row: int; Col: int }

module Day4 =
    let private parse (input: string) =
        input.Split "\n"
        |> Array.indexed
        |> Array.collect (fun (rowNumber, row) ->
            row.ToCharArray()
            |> Array.indexed
            |> Array.filter (fun (_, c) -> c = '@')
            |> Array.map (fun (col, _) -> { Row = rowNumber; Col = col }))

    let private adjacentPositions =
        [ -1, -1; -1, 0; -1, 1; 0, -1; 0, 1; 1, -1; 1, 0; 1, 1 ]

    let part1 (input: string) =
        let positions = input |> parse |> set

        positions
        |> Set.filter (fun pos ->
            adjacentPositions
            |> List.filter (fun (ro, co) ->
                { Row = pos.Row + ro
                  Col = pos.Col + co }
                |> positions.Contains)
            |> List.length < 4)
        |> Set.count
