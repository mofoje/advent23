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

    public bool IsSymbol(char input)
    {
        return (input > 32 && input < 46) || input == 47 || (input > 57 && input < 97);
    }

    private Symbol GetSymbol(char input)
    {
        var isSymbol = (input > 32 && input < 46) || input == 47 || (input > 57 && input < 97);
        if (isSymbol)
        {
            return input == 42 ? Symbol.Gear : Symbol.Symbol;
        }

        return Symbol.NoSymbol;
    }

    private ReturnValue CheckLineForSymbolPart2(string line, int lowerJ, int higherJ, int i)
    {
        Symbol returnValue = Symbol.NoSymbol;
        for (int j = lowerJ; j <= higherJ; j++)
        {
            var symbol = GetSymbol(line[j]);
            if (symbol != Symbol.NoSymbol)
            {
                return new ReturnValue(symbol, j, i);
            }
        }

        return new ReturnValue(returnValue, 0, 0);
    }

    private enum Symbol
    {
        NoSymbol,
        Symbol,
        Gear
    }

    public int Part2(string[] input)
    {
        var submittedInts = new List<(int, ReturnValue?)>();
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
                        var symbol = CheckLineForSymbolPart2(input[i - 1], tempLowerJ, tempUpperJ, i - 1);
                        if (symbol.Symbol != Symbol.NoSymbol)
                        {
                            submittedInts.Add((returnedInt, symbol));
                            j = j + returned.Length - 1;
                            continue;
                        }
                    }

                    // Check lower
                    if (i != input.Length - 1)
                    {
                        var symbol = CheckLineForSymbolPart2(input[i + 1], tempLowerJ, tempUpperJ, i + 1);
                        if (symbol.Symbol != Symbol.NoSymbol)
                        {
                            submittedInts.Add((returnedInt, symbol));
                            j = j + returned.Length - 1;
                            continue;
                        }
                    }

                    // Check sides
                    if (j != 0)
                    {
                        var symbol = GetSymbol(line[j - 1]);
                        if (symbol != Symbol.NoSymbol)
                        {
                            submittedInts.Add((returnedInt, new ReturnValue(symbol, j - 1, i)));
                            j = j + returned.Length - 1;
                            continue;
                        }
                    }

                    if (tempUpperJ != line.Length - 1)
                    {
                        var symbol = GetSymbol(line[j + returned.Length]);
                        if (symbol != Symbol.NoSymbol)
                        {
                            submittedInts.Add((returnedInt, new ReturnValue(symbol, j + returned.Length, i)));
                            j = j + returned.Length - 1;
                            continue;
                        }
                    }
                }
            }
        }

        var parts = submittedInts
            .GroupBy(x => x.Item2)
            .Select(x => new {x.Key, Parts = x.ToList()});
        return parts.Where(part => part.Key.Symbol == Symbol.Gear && part.Parts.Count > 1).Sum(part => part.Parts[0].Item1 * part.Parts[1].Item1);
    }

    private record ReturnValue(Symbol Symbol, int X, int Y);
}