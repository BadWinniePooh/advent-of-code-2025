namespace advent.of.code_2025.day01;

public class Lock(int startingPosition)
{
    private readonly Dial _dial = new(startingPosition);

    public void Rotate(string rotation) => _dial.Rotate(rotation);
    public int CurrentPosition => _dial.Position;
    public int Password => _dial.ExpectedPassword;
}