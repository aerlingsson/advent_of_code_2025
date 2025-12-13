namespace Test

open Xunit
open AOC

type Day3Tests() =
    [<Fact>]
    let part1Example () =
        Assert.Equal(357L, Day3.part1 Day3Input.example)

    [<Fact>]
    let part1Real () =
        Assert.Equal(17452L, Day3.part1 Day3Input.input)

    [<Fact>]
    let part2Example () =
        Assert.Equal(3121910778619L, Day3.part2 Day3Input.example)

    [<Fact>]
    let part2Real () =
        Assert.Equal(173300819005913L, Day3.part2 Day3Input.input)
