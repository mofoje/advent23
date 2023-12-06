namespace AdventOfCode.Day6;

public class Day6
{
    public int Part1(string[] input)
    {
        var sum = 0;
        var times = input[0].Split(":")[1].Split(" ").Where(x => x != "").ToArray();
        var distances = input[1].Split(":")[1].Split(" ").Where(x => x != "").ToArray();
        for (int i = 0; i < times.Length; i++)
        {
            var succesCount = 0;
            var time = int.Parse(times[i]);
            var distance = int.Parse(distances[i]);
            for (int hold = 0; hold < time; hold++)
            {
                var speed = time - hold;
                var result = speed * hold;
                if (result > distance)
                {
                    succesCount++;
                }
            }

            sum = sum == 0 ? succesCount : sum * succesCount;
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
}