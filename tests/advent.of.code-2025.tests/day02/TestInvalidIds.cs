using advent.of.code_2025.day02;

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
    [InlineData("11-22,95-115", 33)]
    public void GiftShopComputerCanAcceptMoreThanOnePairOfIds(string input, int expectedSum)
    {
        var sut = new GiftShopComputer();
        var actual = sut.SumInvalidIds(input);
        Assert.Equal(expectedSum, actual);
    }
}