namespace advent.of.code_2025.Day01;

public class Dial(int startingPosition)
{
    public void Rotate(string input)
    {
        var rotationAmount = int.Parse(input.Remove(0, 1));
        var PreviousPosition = Position;
        if (input.StartsWith('L'))
        {
            Position -= rotationAmount;
            if (Position < 0)
            {
                Position += 100;
                if (PreviousPosition != 0)
                {
                    ExpectedPassword++;
                }
            }
            else if (Position == 0)
            {
                ExpectedPassword++;
            }
        } 
        else if (input.StartsWith('R'))
        {
            Position += rotationAmount;
            if (Position > 99)
            {
                Position -= 100;
                ExpectedPassword++;
            }
        }
    }

    private int PreviousPosition { get; set; }
    public int Position { get; private set; } = startingPosition;
    public int ExpectedPassword { get; private set; }
}