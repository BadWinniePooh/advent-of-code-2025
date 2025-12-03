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

        /*
         * A powerunit contains a bank of batteries (string of batteries)
         * A powerunit accepts a list of banks
         * A powerunit can detect the highest combination in any bank
         * The order of batteries may not be changed (8192 -> 92 would be the highest)
         */
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
        
        Assert.Equal(92, actual);
    }

    [Theory]
    [InlineData("525", 55)]
    [InlineData("552", 55)]
    [InlineData("255", 55)]
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
        var listOfBanks = new List<Bank> { new("525"), new("255"), new("552") };
        var powerunit = new PowerUnit(listOfBanks);

        var actual = powerunit.TotalJoltage();
        
        Assert.Equal(165, actual);
    }
}