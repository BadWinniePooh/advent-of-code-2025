namespace advent.of.code_2025.day02;

public record IdPair(string FirstId, string SecondId)
{
    public static IEnumerable<IdPair> ParseMany(IEnumerable<string> idPairs)
    {
        return idPairs.Select(idPair => Parse(idPair));
    }

    private static IdPair Parse(string idPair)
    {
        var pairSplitted = idPair.Split('-').ToList();
        return new IdPair(pairSplitted[0], pairSplitted[1]);
    }

    private bool IsInvalidId(long id)
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
                return true;
            }
        }
        return false;
    }

    public long Verify()
    {
        var startId = long.Parse(FirstId);
        var endId = long.Parse(SecondId);
        long sum = 0;
        
        for (var currentId = startId; currentId <= endId; currentId++)
        {
            if (IsInvalidId(currentId))
            {
                sum += currentId;
            }
        }
        
        return sum;
    }
}