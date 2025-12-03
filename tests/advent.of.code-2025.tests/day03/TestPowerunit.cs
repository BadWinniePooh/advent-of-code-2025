using advent.of.code_2025.day03;

namespace advent.of.code_2025.tests.day03;

public class TestPowerunit
{
    [Fact]
    public void WhenTwoBatteriesArePresent_ThenTwoBatteriesAreReturned()
    {
        var listOfBanks = new List<Bank> { new("98") };
        var powerunit = new PowerUnit(listOfBanks);

        var actual = powerunit.TotalJoltage();
        
        Assert.Equal(98, actual);
    }

    [Fact]
    public void WhenTheHigherBatteryIsOnTheRight_ThenBatteriesAreNotRearranged()
    {
        var listOfBanks = new List<Bank> { new("19") };
        var powerunit = new PowerUnit(listOfBanks);

        var actual = powerunit.TotalJoltage();
        
        Assert.Equal(19, actual);
    }

    [Fact]
    public void WhenMultipleBatteriesInSingleBank_ThenTwoDigitBatteryCombinationIsResult()
    {
        var listOfBanks = new List<Bank> { new("192") };
        var powerunit = new PowerUnit(listOfBanks);

        var actual = powerunit.TotalJoltage();
        
        Assert.Equal(192, actual);
    }

    [Theory]
    [InlineData("525", 525)]
    [InlineData("552", 552)]
    [InlineData("255", 255)]
    public void WhenDuplicatesExist_ThenCorrectBatteryCombinationIsFound(string batteryBank, int expected)
    {
        var listOfBanks = new List<Bank> { new(batteryBank) };
        var powerunit = new PowerUnit(listOfBanks);

        var actual = powerunit.TotalJoltage();
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void WhenMultiplePacksAreProvided_ThenPowerUnitSumsTotalJoltage()
    {
        var listOfBanks = new List<Bank> { new("525111111111"), new("111111255111"), new("111111111552") };
        var powerunit = new PowerUnit(listOfBanks);

        var actual = powerunit.TotalJoltage();
        
        Assert.Equal(747333477774, actual);
    }

    [Fact(Skip = "")]
    public void ApprovalTestByCode()
    {
        var listOfBanks = new List<Bank>
        {
            new("987654321111111"), 
            new("811111111111119"), 
            new("234234234234278"), 
            new("818181911112111")
        };
        var expectedJoltage = 3121910778619;
        var powerunit = new PowerUnit(listOfBanks);

        var actual = powerunit.TotalJoltage();
        
        Assert.Equal(expectedJoltage, actual);
    }

    [Fact(Skip = "")]
    public void ApprovalTestByFile()
    {
        var expectedJoltage = 3121910778619;
        var input = File.ReadAllLines("./Day03/TestInput.txt");
        var sut = new RiddleSolver(input);

        var actual = sut.SolveDay3();
        
        Assert.Equal(expectedJoltage, actual);
    }
    
    [Fact(DisplayName = "Solution", Skip = "Skip by default")]
    //[Fact(DisplayName = "Solution")]
    public void RiddleSolution()
    {
        var expectedJoltage = 0;
        var input = File.ReadAllLines("./Day03/PuzzleInput");
        var sut = new RiddleSolver(input);

        var actual = sut.SolveDay3();
        
        Assert.Equal(expectedJoltage, actual);
    }
}