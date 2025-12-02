using advent.of.code_2025.day02;

namespace advent.of.code_2025.tests.day02;

public class TestInvalidIds
{
    [Fact]
    public void WhenOnlyValidIds_ThenSumIsZero()
    {
        var sut = new GiftShopComputer();
        var actual = sut.SumInvalidIds("12-20");
        Assert.Equal(0, actual);
    }

    [Fact]
    public void WhenOneInvalidId_ThenSumIsEqualToInvalidId()
    {
        var sut = new GiftShopComputer();
        var actual = sut.SumInvalidIds("11-20");
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
    [InlineData("11-22,95-115", 132)]
    [InlineData("11-22,95-115,998-1012", 1142)]
    public void GiftShopComputerCanAcceptMoreThanOnePairOfIds(string input, int expectedSum)
    {
        var sut = new GiftShopComputer();
        var actual = sut.SumInvalidIds(input);
        Assert.Equal(expectedSum, actual);
    }

    [Fact]
    public void ApprovalTestByCode()
    {
        var input =
            "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";
        var expectedSum = 1227775554;

        var sut = new GiftShopComputer();

        var actual = sut.SumInvalidIds(input);
        
        Assert.Equal(expectedSum, actual);
    }

    [Fact]
    public void ApprovalTestByFile()
    {
        var expectedSum = 1227775554;
        var input = File.ReadAllLines("./Day02/TestInput.txt");
        //var sut = new RiddleSolver(input);

        //var actual = sut.SolveDay2();

        //Assert.Equal(expectedSum, actual);
    }
}