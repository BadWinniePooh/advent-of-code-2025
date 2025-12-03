namespace advent.of.code_2025.day03;

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

    private (char, int) DetermineHighestJoltage(int index, char highestJoltage, int batteryIndex)
    {
        var currentBatteryJoltage = Batteries[index];
        var isHigher = currentBatteryJoltage > highestJoltage;
        highestJoltage = isHigher ? currentBatteryJoltage : highestJoltage;
        batteryIndex = isHigher ? index : batteryIndex;
        return (highestJoltage, batteryIndex);
    }
}