using Xunit;

namespace AdventOfCode.Day2;

[Trait("Category", "Test")]
[Collection("Collection")]
public class Day2Test
{
    private readonly Day2 _sut;

    public Day2Test()
    {
        _sut = new Day2();
    }

    [Fact]
    public async Task Example()
    {
        var input = """
                    Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
                    Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
                    Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
                    Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
                    Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
                    """;

        var result = _sut.Part1(input.Split('\n'));

        Assert.Equal(8, result);
    }

    [Fact]
    public void Input1()
    {
        //Arrange
        var input = File.ReadLines("Day2/input.txt");
    
        var result = _sut.Part1(input.ToArray());
    
        Assert.Equal(2727, result);
    }
    
    [Fact]
    public async Task Example_Day2()
    {
        var input = """
                    Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
                    Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
                    Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
                    Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
                    Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
                    """;
    
        var result = _sut.Part2(input.Split('\n'));
    
        Assert.Equal(2286, result);
    }
    
    [Fact]
    public async Task Input_Day2()
    {
        var input = File.ReadLines("Day2/input.txt");
    
        var result = _sut.Part2(input.ToArray());
    
        Assert.Equal(56580, result);
    }
}