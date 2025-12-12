namespace Test

open Xunit
open AOC

type Day2Tests() =
    [<Fact>]
    let part1Example () =
        Assert.Equal(1227775554L, Day2.part1 Day2Input.example)

    [<Fact>]
    let part1Real () =
        Assert.Equal(30599400849L, Day2.part1 Day2Input.input)

    [<Fact>]
    let part2Example () =
        Assert.Equal(4174379265L, Day2.part2 Day2Input.example)

    [<Fact>]
    let part2Real () =
        Assert.Equal(46270373595L, Day2.part2 Day2Input.input)
