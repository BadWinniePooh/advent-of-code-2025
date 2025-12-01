namespace advent.of.code_2025.Day01;

public class Dial(int startingPosition)
{
    public void Rotate(string input)
    {
        var rotationAmount = int.Parse(input.Remove(0, 1));
        if (input.StartsWith('L'))
        {
            Position -= rotationAmount;
            if (Position < 0)
            {
                Position += 100;
            }
        } 
        else if (input.StartsWith('R'))
        {
            Position += rotationAmount;
        }
        Position %= 100;

        if (Position == 0)
        {
            ExpectedPassword++;
        }
    }

    public int Position { get; private set; } = startingPosition;
    public int ExpectedPassword { get; private set; }
}