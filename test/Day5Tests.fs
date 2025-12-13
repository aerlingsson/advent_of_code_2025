namespace Test

open Xunit
open AOC

type Day5Tests() =
    [<Fact>]
    let part1Example () =
        Assert.Equal(3, Day5.part1 Day5Input.example)

    [<Fact>]
    let part1Real () =
        Assert.Equal(664, Day5.part1 Day5Input.input)

//    [<Fact>]
//    let part2Example () =
//        Assert.Equal(43, Day5.part2 Day5Input.example)
//
//    [<Fact>]
//    let part2Real () =
//        Assert.Equal(8739, Day5.part2 Day5Input.input)
