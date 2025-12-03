namespace advent.of.code_2025.day03;

public class PowerUnit(List<Bank> listOfBanks)
{
    public long TotalJoltage()
    {
        return listOfBanks.Sum(b => b.Joltage());
    }
}