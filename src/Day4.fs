namespace AOC

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
        |> set

    let private adjacentPositions =
        List.allPairs [ -1 .. 1 ] [ -1 .. 1 ] |> List.except [ 0, 0 ]

    let private accessibleRolls (positions: Pos Set) =
        positions
        |> Set.filter (fun pos ->
            adjacentPositions
            |> List.filter (fun (ro, co) ->
                { Row = pos.Row + ro
                  Col = pos.Col + co }
                |> positions.Contains)
            |> List.length < 4)

    let part1 (input: string) =
        input |> parse |> accessibleRolls |> Set.count

    let part2 (input: string) =
        let rec removeAccessibleRolls countRemoved positions =
            let accesible = positions |> accessibleRolls

            if accesible.Count = 0 then
                countRemoved
            else
                removeAccessibleRolls (countRemoved + accesible.Count) (Set.difference positions accesible)

        input |> parse |> removeAccessibleRolls 0
