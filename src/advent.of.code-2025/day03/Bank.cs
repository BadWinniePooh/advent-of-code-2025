namespace advent.of.code_2025.day03;

public record Bank (string Batteries)
{
    private const char InvalidBattery = '-';
    private List<int> selectedBatteries = new List<int>();

    public long Joltage()
    {
        var joltageForBatteryBank = FindTwoBatteriesWithHighestVoltage();
        return long.Parse(joltageForBatteryBank);
    }

    private string FindTwoBatteriesWithHighestVoltage()
    {
        var batteryPack = "";
        var batteryIndex = 0;
        var currentHighestBattery = InvalidBattery;
        var prependSecondNumber = false;
        
        (batteryPack, batteryIndex) = FindBatteryWithHighestJoltage(currentHighestBattery, batteryIndex, batteryPack);
        
        // reset highest battery
        while (batteryPack.Length < Batteries.Length && batteryPack.Length < 12)
        {
            currentHighestBattery = InvalidBattery;
            batteryPack = FindBatteryWithSecondHighestJoltage(currentHighestBattery, batteryIndex, prependSecondNumber, batteryPack);            
        }
        
        batteryPack = SortBatteryPack();
        
        return batteryPack;
    }

    private string SortBatteryPack()
    {
        var sortedBatteryPack = "";
        selectedBatteries.Sort();
        foreach (var selectedBattery in selectedBatteries)
        {
            sortedBatteryPack += Batteries[selectedBattery];
        }

        return sortedBatteryPack;
    }

    private string FindBatteryWithSecondHighestJoltage(char currentHighestBattery, int batteryIndex, bool prependSecondNumber,
        string batteryPack)
    {
        // try find highest battery after found battery
        for (var index = batteryIndex + 1; index < Batteries.Length; index++)
        {
            if (selectedBatteries.Contains(index))
            {
                continue;
            }
            (currentHighestBattery, batteryIndex) = DetermineHighestJoltage(index, currentHighestBattery, batteryIndex);
        }

        // no battery exist after found battery
        if (currentHighestBattery == InvalidBattery)
        {
            prependSecondNumber = true;
            // find highest battery before found battery
            for (var index = batteryIndex - 1; index >= 0; index--)
            {
                if (selectedBatteries.Contains(index))
                {
                    continue;
                }
                (currentHighestBattery, batteryIndex) = DetermineHighestJoltage(index, currentHighestBattery, batteryIndex);
            }
        }

        // join the two batteries without rearranging
        batteryPack += currentHighestBattery;
        selectedBatteries.Add(batteryIndex);
        return batteryPack;
    }

    private (string, int) FindBatteryWithHighestJoltage(char currentHighestBattery, int batteryIndex, string batteryPack)
    {
        for (var index = 0; index < Batteries.Length; index++)
        {
            (currentHighestBattery, batteryIndex) = DetermineHighestJoltage(index, currentHighestBattery, batteryIndex);
        }

        batteryPack += currentHighestBattery;
        selectedBatteries.Add(batteryIndex);
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