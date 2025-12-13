namespace Test

open Xunit
open AOC

type Day4Tests() =
    [<Fact>]
    let part1Example () =
        Assert.Equal(13, Day4.part1 Day4Input.example)

    [<Fact>]
    let part1Real () =
        Assert.Equal(1419, Day4.part1 Day4Input.input)

    [<Fact>]
    let part2Example () =
        Assert.Equal(43, Day4.part2 Day4Input.example)

    [<Fact>]
    let part2Real () =
        Assert.Equal(8739, Day4.part2 Day4Input.input)
