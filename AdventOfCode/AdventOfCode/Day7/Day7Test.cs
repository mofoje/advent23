using Xunit;

namespace AdventOfCode.Day7;

[Trait("Category", "Test")]
[Collection("Collection")]
public class Day7Test
{
    private readonly Day7 _sut = new();
    private readonly string _inputPath = "Day7/input.txt";

    [Fact]
    public async Task Example()
    {
        var input = """
                    32T3K 765
                    T55J5 684
                    KK677 28
                    KTJJT 220
                    QQQJA 483
                    """;

        var result = _sut.Part1(input.Split('\n'));

        Assert.Equal(6440, result);
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