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
}

public class PowerUnit(List<Bank> listOfBanks)
{
    public int TotalJoltage()
    {
        return listOfBanks.First().Joltage();
    }
}

public record Bank (string batteries)
{
    public int Joltage()
    {
        var (batteryPack, index) = HighestBattery(0);
        return int.Parse(batteryPack);
    }

    private (string batteryPack, int index) HighestBattery(int startIndex)
    {
        var batteryPack = "";
        var batteryIndex = 0;
        var batteryIndex2 = 0;
        var highestNumber = '-';
        var prependNumber = false;

        if (startIndex != 0)
        {
            startIndex += 1;
        }
        
        for (var index = startIndex; index < batteries.Length; index++)
        {
            var currentNumber = batteries[index];
            var isHigher = currentNumber > highestNumber;
            highestNumber = isHigher ? currentNumber : highestNumber;
            batteryIndex = isHigher ? index : batteryIndex;
        }
        batteryPack += highestNumber;
        
        highestNumber = '-';
        for (var index = batteryIndex+1; index < batteries.Length; index++)
        {
            var currentNumber = batteries[index];
            var isHigher = currentNumber > highestNumber;
            highestNumber = isHigher ? currentNumber : highestNumber;
            batteryIndex = isHigher ? index : batteryIndex;
        }

        if (highestNumber == '-')
        {
            prependNumber = true;
            for (var index = batteryIndex - 1; index >= 0; index--)
            {
                var currentNumber = batteries[index];
                var isHigher = currentNumber > highestNumber;
                highestNumber = isHigher ? currentNumber : highestNumber;
                batteryIndex = isHigher ? index : batteryIndex;
            }
        }

        if (prependNumber)
        {
            batteryPack = highestNumber + batteryPack;
        }
        else
        { 
            batteryPack += highestNumber;
        }
        
        return (batteryPack, batteryIndex);
    }
}