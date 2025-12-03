using advent.of.code_2025.day01;
using advent.of.code_2025.day02;
using advent.of.code_2025.day03;

namespace advent.of.code_2025;

public class RiddleSolver(IEnumerable<string> riddleInputs)
{
    private IEnumerable<string> RiddleInputs { get; } = riddleInputs;

    public int SolveDay1(int startingPosition)
    {
        var dial = new Lock(startingPosition);
        foreach (var input in RiddleInputs)
        {
            dial.Rotate(input);
        }

        return dial.Password;
    }

    public long SolveDay2()
    { 
        var computer = new GiftShopComputer();
        return computer.SumInvalidIds(RiddleInputs.ToArray()[0]);
    }

    public long SolveDay3()
    {
        var listOfBanks = new List<Bank>();
        foreach (var riddleInput in RiddleInputs)
        {
            listOfBanks.Add(new(riddleInput));
        }

        var powerUnit = new PowerUnit(listOfBanks);

        return powerUnit.TotalJoltage();
    }
}