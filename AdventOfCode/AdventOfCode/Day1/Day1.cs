namespace AdventOfCode.Day1;

public class Day1
{
    private record Digit(string DigitString, char Value);

    private readonly Digit[] _digits =
    {
        new("one", '1'),
        new("two", '2'),
        new("three", '3'),
        new("four", '4'),
        new("five", '5'),
        new("six", '6'),
        new("seven", '7'),
        new("eight", '8'),
        new("nine", '9'),
    };

    public async Task<int> Handle(string[] input)
    {
        var sum = 0;
        foreach (var line in input)
        {
            char? first = null;
            char? second = null;

            foreach (var ch in line.Where(char.IsDigit))
            {
                first ??= ch;

                second = ch;
            }

            var number = $"{first}{second}";
            sum += int.Parse(number);
        }

        return sum;
    }
    

    public async Task<int> Day2(string[] input)
    {
        var sum = 0;
        foreach (var line in input)
        {
            var trimmedLine = line.Replace("\n", "").Trim();
            int? first = null;
            int? second = null;
    
            var strings = _digits.Where(x => trimmedLine.Contains(x.DigitString));
            int firstOccurance = 999999999;
            Digit? firstOccuranceDigit = null; 
            int lastOccurance = -1;
            Digit? lastOccuranceDigit = null; 
            foreach (var digit in strings)
            {
                var lastindex = trimmedLine.LastIndexOf(digit.DigitString);
                var firstIndex = trimmedLine.IndexOf(digit.DigitString);
    
                if (lastindex != -1 && lastindex > lastOccurance)
                {
                    lastOccurance = lastindex;
                    lastOccuranceDigit = digit;
                }
    
                if (firstIndex != -1 && firstIndex < firstOccurance)
                {
                    firstOccurance = firstIndex;
                    firstOccuranceDigit = digit;
                }
            }
            var firstDigit = trimmedLine.FirstOrDefault(char.IsDigit);
            var lastDigit = trimmedLine.LastOrDefault(char.IsDigit);
    
            char firstValue;
            var firstDigitIndex = trimmedLine.IndexOf(firstDigit);
            if (firstDigitIndex == -1)
            {
                firstValue = firstOccuranceDigit.Value;
            } else if (firstOccurance == 999999999)
            {
                firstValue = firstDigit;
            }
            else
            {
                firstValue = firstOccurance > firstDigitIndex ? firstDigit : firstOccuranceDigit.Value;
            }
    
            char lastValue;
            var lastDigitIndex = trimmedLine.LastIndexOf(lastDigit);
            
            if (lastDigitIndex == -1)
            {
                lastValue = lastOccuranceDigit.Value;
            } else if (lastOccurance == -1)
            {
                lastValue = lastDigit;
            }
            else
            {
                lastValue = lastOccurance < lastDigitIndex ? lastDigit : lastOccuranceDigit.Value;
            }
            var output = $"{firstValue}{lastValue}";
            Console.WriteLine(output);
            sum += int.Parse(output);
        }
    
        return sum;
    }
}