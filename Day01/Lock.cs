namespace advent.of.code_2025.Day01;

public class Lock(int startingPosition)
{
    public Dial Dial { get; } = new(startingPosition);
}