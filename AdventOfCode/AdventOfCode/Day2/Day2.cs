namespace AdventOfCode.Day2;

public class Day2
{
    private class Count
    {
        public Count(int red, int green, int blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
    }

    private readonly Count _config = new Count(12, 13, 14);

    public int Part1(string[] input)
    {
        var sum = 0;
        return sum;
    }
        static int CalculatePartNumberSum(string[] engineSchematic)
        {
            int sum = 0;
    
            for (int i = 0; i < engineSchematic.Length; i++)
            {
                for (int j = 0; j < engineSchematic[i].Length; j++)
                {
                    if (char.IsDigit(engineSchematic[i][j]) && IsAdjacentToSymbol(engineSchematic, i, j))
                    {
                        sum += int.Parse(engineSchematic[i][j].ToString());
                    }
                }
            }
    
            return sum;
        }
    
        static bool IsAdjacentToSymbol(string[] engineSchematic, int row, int col)
        {
            for (int i = Math.Max(0, row - 1); i <= Math.Min(engineSchematic.Length - 1, row + 1); i++)
            {
                for (int j = Math.Max(0, col - 1); j <= Math.Min(engineSchematic[i].Length - 1, col + 1); j++)
                {
                    if (engineSchematic[i][j] == '*' || engineSchematic[i][j] == '#' || engineSchematic[i][j] == '+'
                        || engineSchematic[i][j] == '$')
                    {
                        return true;
                    }
                }
            }
    
            return false;
        }



    public int Part2(string[] input)
    {
        var sum = 0;
        foreach (var line in input)
        {
            var firstSplit = line.Split(":");
            var game = firstSplit[0];
             var cubes = firstSplit[1];
            var sets = cubes.Split(";");
            var counter = new Count(0, 0, 0);
            foreach (var set in sets)
            {
                var individualCubes = set.Trim().Split(",");
                foreach (var cube in individualCubes)
                {
                    var split = cube.Trim().Split();
                    var amount = int.Parse(split[0].Trim());
                    var color = split[1];
                    switch (color)
                    {
                        case "red":
                            counter.Red = counter.Red < amount ? amount : counter.Red;
                            break;
                        case "green":
                            counter.Green = counter.Green < amount ? amount : counter.Green;
                            break;
                        case "blue":
                            counter.Blue = counter.Blue < amount ? amount : counter.Blue;
                            break;
                    }
                }
            }

            sum += counter.Green * counter.Red * counter.Blue;
        }

        return sum;
    }
}