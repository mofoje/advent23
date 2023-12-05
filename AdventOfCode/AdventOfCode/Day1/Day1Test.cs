using Xunit;

namespace AdventOfCode.Day1;

[Trait("Category", "Test")]
[Collection("Collection")]
public class Day1Test
{
    private readonly Day1 _sut;

    public Day1Test()
    {
        _sut = new Day1();
    }

    [Fact]
    public async Task Example()
    {
        var input = """
                    1abc2
                    pqr3stu8vwx
                    a1b2c3d4e5f
                    treb7uchet
                    """;

        var result = await _sut.Handle(input.Split('\n'));

        Assert.Equal(142, result);
    }

    [Fact]
    public async Task Input1()
    {
        //Arrange
        var input = File.ReadLines("day1_1.txt");

        var result = await _sut.Handle(input.ToArray());

        Assert.Equal(53921, result);
    }

    [Fact]
    public async Task Example_Day2()
    {
        var input = """
                    two1nine
                    eightwothree
                    abcone2threexyz
                    xtwone3four
                    4nineeightseven2
                    zoneight234
                    7pqrstsixteen
                    """;

        var result = await _sut.Day2(input.Split('\n'));

        Assert.Equal(281, result);
    }
    
    [Fact]
    public async Task Input_Day2()
    {
        var input = File.ReadLines("day1_1.txt");

        var result = await _sut.Day2(input.ToArray());

        Assert.Equal(54676, result);
    }
    
    [Fact]
    public async Task Input_Error()
    {
        var input = new[]
        {
            "67mcmfive1sixonefive"
        };

        var result = await _sut.Day2(input);

        Assert.Equal(65, result);
    }

}