namespace Test

open Xunit
open AOC

type Day3Tests() =
    [<Fact>]
    let part1Example () =
        Assert.Equal(357, Day3.part1 Day3Input.example)

    [<Fact>]
    let part1Real () =
        Assert.Equal(17452, Day3.part1 Day3Input.input)

//    [<Fact>]
//    let part2Example () =
//        Assert.Equal(4174379265L, Day3.part2 Day3Input.example)
//
//    [<Fact>]
//    let part2Real () =
//        Assert.Equal(46270373595L, Day3.part2 Day3Input.input)
