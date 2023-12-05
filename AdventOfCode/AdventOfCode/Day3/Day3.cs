namespace AdventOfCode.Day3;

public class Day3
{
    public int Part1(string[] input)
    {
        var sum = 0;
        var submittedInts = new List<int>();
        for (int i = 0; i < input.Length; i++)
        {
            var line = input[i];
            for (int j = 0; j < input[i].Length; j++)
            {
                if (char.IsDigit(line[j]))
                {
                    var returned = Probe(line, j, "");
                    var returnedInt = int.Parse(returned);

                    var tempLowerJ = j > 0 ? j - 1 : 0;
                    var tempUpperJ = j + returned.Length >= line.Length ? line.Length - 1 : j + returned.Length;
                    // Check upper
                    if (i != 0)
                    {
                        var hasSymbol = CheckLineForSymbol(input[i - 1], tempLowerJ, tempUpperJ);
                        if (hasSymbol)
                        {
                            sum += returnedInt;
                            submittedInts.Add(returnedInt);
                            j = j + returned.Length - 1;
                            continue;
                        }
                    }

                    // Check lower
                    if (i != input.Length - 1)
                    {
                        var hasSymbol = CheckLineForSymbol(input[i + 1], tempLowerJ, tempUpperJ);
                        if (hasSymbol)
                        {
                            sum += returnedInt;
                            submittedInts.Add(returnedInt);
                            j = j + returned.Length - 1;
                            continue;
                        }
                    }

                    // Check sides
                    if (j != 0)
                    {
                        if (IsSymbol(line[j - 1]))
                        {
                            sum += returnedInt;
                            submittedInts.Add(returnedInt);
                            j = j + returned.Length - 1;
                            continue;
                        }
                    }

                    if (tempUpperJ != line.Length - 1)
                    {
                        if (IsSymbol(line[j + returned.Length]))
                        {
                            sum += returnedInt;
                            submittedInts.Add(returnedInt);
                            j = j + returned.Length - 1;
                            continue;
                        }
                    }
                }
            }
        }

        return sum;
    }

    private string Probe(string line, int j, string output)
    {
        if (char.IsDigit(line[j]))
        {
            output = $"{output}{line[j]}";
            if (j + 1 == line.Length)
            {
                return output;
            }
            return Probe(line, ++j, output);
        }

        return output;
    }

    private bool CheckLineForSymbol(string line, int lowerJ, int higherJ)
    {
        for (int j = lowerJ; j <= higherJ; j++)
        {
            if (IsSymbol(line[j]))
            {
                return true;
            }
        }

        return false;
    }

    private bool IsSymbol(char input)
    {
        return (input > 32 && input < 46) || input == 47 || (input > 57 && input < 97);
    }

    public int Part2(string[] input)
    {
        var sum = 0;
        return sum;
    }
}