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
        var middle = id.Length / 2;
        var firstPart = id[..middle];
        var secondPart = id[middle..];
        return firstPart == secondPart ? long.Parse(id) : 0;
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