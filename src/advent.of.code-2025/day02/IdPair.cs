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

    private int EvaluateId(string id)
    {
        var middle = id.Length / 2;
        var firstPart = id[..middle];
        var secondPart = id[middle..];
        return firstPart == secondPart ? int.Parse(id) : 0;
    }

    public int Verify()
    {
        var lowerDelimiter = int.Parse(FirstId);
        var upperDelimiter = int.Parse(SecondId);
        var sum = 0;
        
        for (var counter = lowerDelimiter; counter <= upperDelimiter; counter++)
        {
            sum += EvaluateId(counter.ToString());
        }
        
        return sum;
    }
}