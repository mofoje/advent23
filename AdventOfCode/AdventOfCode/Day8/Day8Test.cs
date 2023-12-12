using Xunit;

namespace AdventOfCode.Day8;

[Trait("Category", "Test")]
[Collection("Collection")]
public class Day8Test
{
    private readonly Day8 _sut = new();
    private readonly string _inputPath = "Day8/input.txt";

    [Fact]
    public async Task Example()
    {
        var input = """
                    RL

                    AAA = (BBB, CCC)
                    BBB = (DDD, EEE)
                    CCC = (ZZZ, GGG)
                    DDD = (DDD, DDD)
                    EEE = (EEE, EEE)
                    GGG = (GGG, GGG)
                    ZZZ = (ZZZ, ZZZ)
                    """;

        var result = _sut.Part1(input.Split('\n'));

        Assert.Equal(2, result);
    }


    [Fact]
    public async Task Example2()
    {
        var input = """
                    LLR

                    AAA = (BBB, BBB)
                    BBB = (AAA, ZZZ)
                    ZZZ = (ZZZ, ZZZ)
                    """;

        var result = _sut.Part1(input.Split('\n'));

        Assert.Equal(6, result);
    }


    [Fact]
    public void Input1()
    {
        //Arrange
        var input = File.ReadLines(_inputPath);

        var result = _sut.Part1(input.ToArray());

        Assert.Equal(250957639, result);
    }

    [Fact]
    public async Task Example_Part2()
    {
        var input = """
                    Time:      7  15   30
                    Distance:  9  40  200
                    """;

        var result = _sut.Part2(input.Split('\n'));

        Assert.Equal(71503, result);
    }

    [Fact]
    public async Task Input_Part2()
    {
        var input = File.ReadLines(_inputPath);

        var result = _sut.Part2(input.ToArray());

        Assert.Equal(54676, result);
    }
}