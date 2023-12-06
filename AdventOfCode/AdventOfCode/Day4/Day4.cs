namespace AdventOfCode.Day4;

public class Day4
{
    public int Part1(string[] input)
    {
        var sum = 0;
        foreach (var card in input)
        {
            var cardSplit = card.Split(":");
            var numbers = cardSplit[1].Trim().Split("|");
            var winningNumbers = numbers[0].Trim().Replace("  ", " ").Split(" ");
            var cardNumbers = numbers[1].Trim().Replace("  ", " ").Split(" ");
            var intersection = winningNumbers.Intersect(cardNumbers);
            var matchingCount = intersection.Count();
            sum += (int) Math.Pow(2, matchingCount - 1);
        }

        return sum;
    }

    public long Part2(string[] input)
    {
        var list = new List<CardEntity>();
        foreach (var card in input)
        {
            var cardSplit = card.Split(":");
            var cardNumber = int.Parse(cardSplit[0].Split(" ").Where(x => x != "").ToArray()[1]);
            var numbers = cardSplit[1].Trim().Split("|");
            var winningNumbers = numbers[0].Trim().Replace("  ", " ").Split(" ");
            var cardNumbers = numbers[1].Trim().Replace("  ", " ").Split(" ");
            var parsedCard = new Card(cardNumber, winningNumbers, cardNumbers);
            list.Add(new CardEntity(parsedCard) {Count = 1});
        }

        foreach (var cardEntry in list)
        {
            var card = cardEntry.Card;
            var matching = card.CardNumbers.Intersect(card.WinningNumbers);
            var winningCount = matching.Count();
            for (int i = 1; i <= winningCount; i++)
            {
                if (card.Number + i > list.Count)
                {
                    continue;
                }

                var cardToIncrement = list.Single(x => x.Card.Number == card.Number + i);
                cardToIncrement.Count += cardEntry.Count;
            }
        }

        return list.Sum(x => x.Count);
    }

    private record CardEntity(Card Card)
    {
        public long Count { get; set; }

        public int WinningCount => Card.WinningNumbers.Intersect(Card.CardNumbers).Count();
    };
    private record Card(int Number, string[] WinningNumbers, string[] CardNumbers);
}