namespace advent.of.code_2025.day02;

public record IdPair(string FirstId, string SecondId)
{
    public static IEnumerable<IdPair> ConvertFrom(IEnumerable<string> idPairs)
    {
        return idPairs.Select(idPair => Parse(idPair));
    }

    private static IdPair Parse(string idPair)
    {
        var pairSplitted = idPair.Split('-').ToList();
        return new IdPair(pairSplitted.First(), pairSplitted.Last());
    }

    private long EvaluateId(string id)
    {
        for (var patternLength = 1; patternLength <= id.Length / 2; patternLength++)
        {
            if (id.Length % patternLength != 0)
            {
                continue;
            }

            var pattern = id[..patternLength];
            var repetitions = id.Length / patternLength;
            var repeatedPattern = string.Concat(Enumerable.Repeat(pattern, repetitions));
            if (repeatedPattern == id)
            {
                return long.Parse(id);
            }
        }
        return 0;
    }

    public long Verify()
    {
        var lowerDelimiter = long.Parse(FirstId);
        var upperDelimiter = long.Parse(SecondId);
        long sum = 0;
        
        for (var counter = lowerDelimiter; counter <= upperDelimiter; counter++)
        {
            sum += EvaluateId(counter.ToString());
        }
        
        return sum;
    }
}