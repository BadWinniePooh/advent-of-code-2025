namespace advent.of.code_2025.tests.day03;

public class TestPowerunit
{
    [Fact]
    public void WhenTwoBatteriesArePresent_ThenTwoBatteriesAreReturned()
    {
        var listOfBanks = new List<Bank>();
        listOfBanks.Add(new Bank("98"));
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
        return int.Parse(batteries);
    }
}