namespace AdventOfCode.Day7;

public class Day7
{
    public long Part1(string[] input)
    {
        var sum = 0L;
        var rank = 1;
        var hands = input.Select(x =>
                new Hand(x)
            )
            .OrderBy(x => x.HandResult)
            .ThenBy(x => GetCardValue(x.Cards[0]))
            .ThenBy(x => GetCardValue(x.Cards[1]))
            .ThenBy(x => GetCardValue(x.Cards[2]))
            .ThenBy(x => GetCardValue(x.Cards[3]))
            .ThenBy(x => GetCardValue(x.Cards[4]));
        foreach (var hand in hands)
        {
            sum += hand.Bet * rank;
            rank++;
        }

        return sum;
    }

    public long Part2(string[] input)
    {
        var sum = 0;
        var times = input[0].Split(":")[1].Replace(" ", "");
        var distances = input[1].Split(":")[1].Replace(" ", "");
        var time = long.Parse(times);
        var distance = long.Parse(distances);
        for (int hold = 0; hold < time; hold++)
        {
            long speed = time - hold;
            long result = speed * hold;
            if (result > distance)
            {
                sum++;
            }
        }

        return sum;
    }

    private class Hand
    {
        public Hand(string input)
        {
            var split = input.Split(" ");
            Cards = new[]
            {
                split[0][0],
                split[0][1],
                split[0][2],
                split[0][3],
                split[0][4]
            };
            Bet = int.Parse(split[1]);
        }

        public char[] Cards { get; set; }

        public int Bet { get; set; }


        public HandResult HandResult
        {
            get
            {
                var groupBy = Cards
                    .GroupBy(x => x)
                    .Select(x => new {x.Key, Cards = x.ToList()})
                    .OrderByDescending(x => x.Cards.Count).ToArray();
                if (groupBy[0].Cards.Count == 5)
                {
                    return HandResult.FiveOfAKind;
                }
                else if (groupBy[0].Cards.Count == 4)
                {
                    return HandResult.FourOfAKind;
                }
                else if (groupBy[0].Cards.Count == 3 && groupBy[1].Cards.Count == 2)
                {
                    return HandResult.FullHouse;
                }
                else if (groupBy[0].Cards.Count == 3)
                {
                    return HandResult.ThreeOfAKind;
                }
                else if (groupBy[0].Cards.Count == 2 && groupBy[1].Cards.Count == 2)
                {
                    return HandResult.TwoPairs;
                }
                else if (groupBy[0].Cards.Count == 2)
                {
                    return HandResult.Pair;
                }


                return HandResult.HighCard;
            }
        }
    }

    private int GetCardValue(char c)
    {
        if (c == 'J')
        {
            return 0;
        }
        if (c > 48 && c < 58)
        {
            return int.Parse(c.ToString());
        }

        if (c == 'T')
        {
            return 10;
        }
        else if (c == 'J')
        {
            return 11;
        }

        if (c == 'Q')
        {
            return 12;
        }

        if (c == 'K')
        {
            return 13;
        }

        return 14;
    }

    private enum HandResult
    {
        HighCard = 0,
        Pair = 1,
        TwoPairs = 2,
        ThreeOfAKind = 3,
        FullHouse = 4,
        FourOfAKind = 5,
        FiveOfAKind = 6
    }
}