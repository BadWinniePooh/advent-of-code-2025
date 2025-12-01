namespace advent.of.code_2025.day01;

public class LockSolver(IEnumerable<string> dialInput, int startingPosition)
{
    private IEnumerable<string> DialInput { get; set; } = dialInput;
    private Lock Lock { get; set; } = new(startingPosition);

    public int Solve()
    {
       
        foreach (var input in DialInput)
        {
            Lock.Rotate(input);
        }

        return Lock.Password;
    }
}