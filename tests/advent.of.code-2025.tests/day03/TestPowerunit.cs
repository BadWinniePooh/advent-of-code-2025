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

}

public class PowerUnit(List<Bank> listOfBanks)
{
    public int TotalJoltage()
    {
        return listOfBanks.First().Joltage();
    }
}

public record Bank (string Batteries)
{
    private const char InvalidBattery = '-';

    public int Joltage()
    {
        var joltageForBatteryBank = FindTwoBatteriesWithHighestVoltage();
        return int.Parse(joltageForBatteryBank);
    }

    private string FindTwoBatteriesWithHighestVoltage()
    {
        var batteryPack = "";
        var batteryIndex = 0;
        var currentHighestBattery = InvalidBattery;
        var prependSecondNumber = false;
        
        (batteryPack, batteryIndex) = FindBatteryWithHighestJoltage(currentHighestBattery, batteryIndex, batteryPack);
        
        // reset highest battery
        currentHighestBattery = InvalidBattery;
        batteryPack = FindBatteryWithSecondHighestJoltage(currentHighestBattery, batteryIndex, prependSecondNumber, batteryPack);

        return batteryPack;
    }

    private string FindBatteryWithSecondHighestJoltage(char currentHighestBattery, int batteryIndex, bool prependSecondNumber,
        string batteryPack)
    {
        // try find highest battery after found battery
        for (var index = batteryIndex + 1; index < Batteries.Length; index++)
        {
            (currentHighestBattery, batteryIndex) = DetermineHighestJoltage(index, currentHighestBattery, batteryIndex);
        }

        // no battery exist after found battery
        if (currentHighestBattery == InvalidBattery)
        {
            prependSecondNumber = true;
            // find highest battery before found battery
            for (var index = batteryIndex - 1; index >= 0; index--)
            {
                (currentHighestBattery, _) = DetermineHighestJoltage(index, currentHighestBattery, batteryIndex);
            }
        }

        // join the two batteries without rearranging
        if (prependSecondNumber)
        {
            batteryPack = currentHighestBattery + batteryPack;
        }
        else
        { 
            batteryPack += currentHighestBattery;
        }

        return batteryPack;
    }

    private (string, int) FindBatteryWithHighestJoltage(char currentHighestBattery, int batteryIndex, string batteryPack)
    {
        for (var index = 0; index < Batteries.Length; index++)
        {
            (currentHighestBattery, batteryIndex) = DetermineHighestJoltage(index, currentHighestBattery, batteryIndex);
        }

        batteryPack += currentHighestBattery;
        return (batteryPack, batteryIndex);
    }

    private (char, int) DetermineHighestJoltage(int index, char highestNumber, int batteryIndex)
    {
        var currentNumber = Batteries[index];
        var isHigher = currentNumber > highestNumber;
        highestNumber = isHigher ? currentNumber : highestNumber;
        batteryIndex = isHigher ? index : batteryIndex;
        return (highestNumber, batteryIndex);
    }
}