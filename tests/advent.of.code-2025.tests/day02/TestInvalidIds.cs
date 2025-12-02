namespace advent.of.code_2025.tests.day02;

public class TestInvalidIds
{
    [Fact]
    public void WhenOnlyValidIds_ThenSumIsZero()
    {
        var sut = new GiftShopComputer();
        var actual = sut.SumInvalidIds("12-34");
        Assert.Equal(0, actual);
    }

    [Fact]
    public void WhenOneInvalidId_ThenSumIsEqualToInvalidId()
    {
        var sut = new GiftShopComputer();
        var actual = sut.SumInvalidIds("11-34");
        Assert.Equal(11, actual);
    }
    
    [Fact]
    public void WhenTwoInvalidIds_ThenSumIsEqualToSumOfInvalidIds()
    {
        var sut = new GiftShopComputer();
        var actual = sut.SumInvalidIds("11-22");
        Assert.Equal(33, actual);
    }

    [Theory]
    [InlineData("11-22,95-115,1212-4567", 1245)]
    public void GiftShopComputerCanAcceptMoreThanOnePairOfIds(string input, int expectedSum)
    {
        var sut = new GiftShopComputer();
        var actual = sut.SumInvalidIds(input);
        Assert.Equal(expectedSum, actual);
    }
}

public class GiftShopComputer
{
    public int SumInvalidIds(string unformattedIds)
    {
        var idPairs = IdPair.ConvertFrom(unformattedIds.Split(','));
        return idPairs.Sum(idPair => idPair.Verify());
    }
}

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
        var sum = EvaluateId(FirstId);
        sum += EvaluateId(SecondId);
        return sum;
    }
}