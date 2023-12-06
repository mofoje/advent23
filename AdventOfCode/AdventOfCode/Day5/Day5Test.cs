using Xunit;

namespace AdventOfCode.Day5;

[Trait("Category", "Test")]
[Collection("Collection")]
public class Day5Test
{
    private readonly Day5 _sut = new();
    private readonly string _inputPath = "Day5/input.txt";

    [Fact]
    public async Task Example()
    {
        var input = """
                    seeds: 79 14 55 13

                    seed-to-soil map:
                    50 98 2
                    52 50 48

                    soil-to-fertilizer map:
                    0 15 37
                    37 52 2
                    39 0 15

                    fertilizer-to-water map:
                    49 53 8
                    0 11 42
                    42 0 7
                    57 7 4

                    water-to-light map:
                    88 18 7
                    18 25 70

                    light-to-temperature map:
                    45 77 23
                    81 45 19
                    68 64 13

                    temperature-to-humidity map:
                    0 69 1
                    1 0 69

                    humidity-to-location map:
                    60 56 37
                    56 93 4
                    """;

        var result = _sut.Part1(input.Split('\n'));

        Assert.Equal(13, result);
    }

    [Fact]
    public void Input1()
    {
        //Arrange
        var input = File.ReadLines(_inputPath);

        var result = _sut.Part1(input.ToArray());

        Assert.Equal(25004, result);
    }

    [Fact]
    public async Task Example_Part2()
    {
        var input = """
                    Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
                    Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
                    Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
                    Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
                    Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
                    Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11
                    """;

        var result = _sut.Part2(input.Split('\n'));

        Assert.Equal(30, result);
    }

    [Fact]
    public async Task Input_Part2()
    {
        var input = File.ReadLines(_inputPath);

        var result = _sut.Part2(input.ToArray());

        Assert.Equal(54676, result);
    }
}