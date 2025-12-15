namespace Test

open Xunit
open AOC

type Day6Tests() =
    [<Fact>]
    let part1Example () =
        Assert.Equal(4277556L, Day6.part1 Day6Input.example)

    [<Fact>]
    let part1Real () =
        Assert.Equal(4412382293768L, Day6.part1 Day6Input.input)

    [<Fact>]
    let part2Example () =
        Assert.Equal(3263827L, Day6.part2 Day6Input.example)

    [<Fact>]
    let part2Real () =
        Assert.Equal(7858808482092L, Day6.part2 Day6Input.input)
