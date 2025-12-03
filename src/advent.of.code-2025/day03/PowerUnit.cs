namespace advent.of.code_2025.day03;

public class PowerUnit(List<Bank> listOfBanks)
{
    public int TotalJoltage()
    {
        return listOfBanks[0].Joltage();
    }
}