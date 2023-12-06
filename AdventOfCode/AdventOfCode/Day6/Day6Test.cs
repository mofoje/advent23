using Xunit;

namespace AdventOfCode.Day6;

[Trait("Category", "Test")]
[Collection("Collection")]
public class Day6Test
{
    private readonly Day6 _sut = new();
    private readonly string _inputPath = "Day6/input.txt";

    [Fact]
    public async Task Example()
    {
        var input = """
                    Time:      7  15   30
                    Distance:  9  40  200
                    """;

        var result = _sut.Part1(input.Split('\n'));

        Assert.Equal(288, result);
    }

    [Fact]
    public void Input1()
    {
        //Arrange
        var input = File.ReadLines(_inputPath);

        var result = _sut.Part1(input.ToArray());

        Assert.Equal(6209190, result);
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