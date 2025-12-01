namespace Test

open Xunit
open AOC

type Day1Tests() =
    [<Fact>]
    let part1Example () = Assert.Equal(3, Day1.part1Example ())

    [<Fact>]
    let part1Real () = Assert.Equal(1147, Day1.part1 ())

    [<Fact>]
    let part2Example () = Assert.Equal(6, Day1.part2Example ())

    [<Fact>]
    let part2Real () = Assert.Equal(6789, Day1.part2 ())
