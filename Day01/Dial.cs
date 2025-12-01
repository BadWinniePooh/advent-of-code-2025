namespace advent.of.code_2025.Day01;

public class Dial(int startingPosition)
{
    private const int DialPositions = 100;
    private const int MinPosition = 0;

    public void Rotate(string input)
    {
        var rotationAmount = int.Parse(input.Remove(0, 1));
        
        if (input.StartsWith('L'))
        {
            ExpectedPassword += CalculateLeftZeroCrossings(Position, rotationAmount);
            var newPosition = Position - rotationAmount;
            Position = ((newPosition % DialPositions) + DialPositions) % DialPositions;
        }
        else if (input.StartsWith('R'))
        {
            var newPosition = Position + rotationAmount;
            ExpectedPassword += newPosition / DialPositions;
            Position = newPosition % DialPositions;
        }
    }

    private int CalculateLeftZeroCrossings(int currentPosition, int amount)
    {
        if (currentPosition == MinPosition)
        {
            return amount / DialPositions;
        }

        if (amount < currentPosition)
        {
            return 0;
        }
        
        var remainingAfterCrossing = amount - currentPosition;
        return 1 + (remainingAfterCrossing / DialPositions);
    }

    public int Position { get; private set; } = startingPosition;
    public int ExpectedPassword { get; private set; }
}