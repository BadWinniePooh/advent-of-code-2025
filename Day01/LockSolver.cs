namespace advent.of.code_2025.Day01;

public class LockSolver(IEnumerable<string> dialInput, int startingPosition)
{
    private IEnumerable<string> DialInput { get; set; } = dialInput;
    private Lock Lock { get; set; } = new(startingPosition);

    public int Solve()
    {
        var dial = Lock.Dial;
        foreach (var input in DialInput)
        {
            dial.Rotate(input);
        }

        return dial.ExpectedPassword;
    }
}