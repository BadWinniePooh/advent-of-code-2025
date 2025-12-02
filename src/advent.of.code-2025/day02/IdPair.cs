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
        return new IdPair(pairSplitted[0], pairSplitted[1]);
    }

    private long EvaluateId(long id)
    {
        var idString = id.ToString();
        
        for (var patternLength = 1; patternLength <= idString.Length / 2; patternLength++)
        {
            if (idString.Length % patternLength != 0)
            {
                continue;
            }

            var pattern = idString[..patternLength];
            var repetitions = idString.Length / patternLength;
            var repeatedPattern = string.Concat(Enumerable.Repeat(pattern, repetitions));
            if (repeatedPattern == idString)
            {
                return id;
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
            sum += EvaluateId(counter);
        }
        
        return sum;
    }
}