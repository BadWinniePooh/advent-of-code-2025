using System.Text;

namespace advent.of.code_2025.day03;

public record Bank (string Batteries)
{
    public long Joltage()
    {
        var joltageForBatteryBank = FindTwelveBatteriesWithHighestVoltage();
        return long.Parse(joltageForBatteryBank);
    }

    private string FindTwelveBatteriesWithHighestVoltage()
    {
        var providedBatteriesAmount = Batteries.Length;
        var requiredBatteriesAmount = Math.Min(12, providedBatteriesAmount);

        if (requiredBatteriesAmount == providedBatteriesAmount)
        {
            return Batteries;
        }

        var assembledBatteryPack = new StringBuilder();
        var startIndex = 0;

        for (var collectedBatteries = 0; collectedBatteries < requiredBatteriesAmount; collectedBatteries++)
        {
            var maxBattery = '0';
            var maxIndex = startIndex;
            var remainingPositions = requiredBatteriesAmount - collectedBatteries - 1;
            var searchEnd = providedBatteriesAmount - remainingPositions;

            for (var currentIndex = startIndex; currentIndex < searchEnd; currentIndex++)
            {
                if (Batteries[currentIndex] > maxBattery)
                {
                    maxBattery = Batteries[currentIndex];
                    maxIndex = currentIndex;
                }
            }

            assembledBatteryPack.Append(maxBattery);
            startIndex = maxIndex + 1;
        }

        return assembledBatteryPack.ToString();
    }
}