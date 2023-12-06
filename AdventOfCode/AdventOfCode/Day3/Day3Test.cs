using Xunit;

namespace AdventOfCode.Day3;

[Trait("Category", "Test")]
[Collection("Collection")]
public class Day3Test
{
    private readonly Day3 _sut;

    public Day3Test()
    {
        _sut = new Day3();
    }

    [Fact]
    public async Task Example()
    {
        var input = """
                    467..114..
                    ...*......
                    ..35...633
                    ......#...
                    617*......
                    .....+.58.
                    ..592.....
                    ......755.
                    ...$.*....
                    .664.598..
                    """;

        var result = _sut.Part1(input.Split('\n'));

        Assert.Equal(4361, result);
    }

    [Fact]
    public void Input1()
    {
        //Arrange
        var input = File.ReadLines("Day3/input.txt");
    
        var result = _sut.Part1(input.ToArray());
    
        Assert.Equal(539590, result);
    }
    //
    [Fact]
    public async Task Example_Day3_Part2()
    {
        var input = """
                    467..114..
                    ...*......
                    ..35...633
                    ......#...
                    617*......
                    .....+.58.
                    ..592.....
                    ......755.
                    ...$.*....
                    .664.598..
                    """;
    
        var result = _sut.Part2(input.Split('\n'));
    
        Assert.Equal(467835, result);
    }
    
    [Fact]
    public async Task Input_Day3()
    {
        var input = File.ReadLines("Day3/input.txt");
    
        var result = _sut.Part2(input.ToArray());
    
        Assert.Equal(80703636, result);
    }
}