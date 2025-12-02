using advent.of.code_2025.day01;
using advent.of.code_2025.day02;

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
        if (RiddleInputs.Count() > 1)
        {
            throw new ArgumentException("Riddle input contains more than one line of text.", nameof(RiddleInputs));
        }
        
        var computer = new GiftShopComputer();
        return computer.SumInvalidIds(RiddleInputs.First());
    }
}