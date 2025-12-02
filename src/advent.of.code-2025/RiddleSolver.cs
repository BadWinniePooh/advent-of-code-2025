using advent.of.code_2025.day01;

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
}