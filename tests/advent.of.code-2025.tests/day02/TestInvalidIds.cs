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
}

public class GiftShopComputer
{
    public int SumInvalidIds(string unformattedIds)
    {
        var sum = 0;
        var ids = unformattedIds.Split('-').ToList();

        foreach (var id in ids)
        {
            var middle = id.Length / 2;
            var firstPart = id[..middle];
            var secondPart = id[middle..];
            sum += firstPart == secondPart ? int.Parse(id) : 0;
            
        }
        
        return sum;
    }
}