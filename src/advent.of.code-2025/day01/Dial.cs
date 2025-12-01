namespace advent.of.code_2025.day01;

public class Dial(int startingPosition)
{
    public int Position { get; private set; } = startingPosition;
    public int ExpectedPassword { get; private set; }
    
    private const int DialPositions = 100;
    private const int MinPosition = 0;
    
    public void Rotate(string input) => Rotate(RotationCommand.Parse(input));

    
    private void Rotate(RotationCommand command)
    {
        var zeroCrossings = CalculateZeroCrossings(command);
        var newPosition = CalculateNewPosition(command);

        ExpectedPassword += zeroCrossings;
        Position = newPosition;
    }

    private int CalculateNewPosition(RotationCommand command)
    {
        var newPosition = command.Direction switch
        {
            RotationDirection.Left => Position - command.Amount,
            RotationDirection.Right => Position + command.Amount,
            _ => throw new ArgumentOutOfRangeException(nameof(command))
        };
        return ((newPosition % DialPositions) + DialPositions) % DialPositions;
    }

    private int CalculateZeroCrossings(RotationCommand command)
    {
        return command.Direction switch
        {
            RotationDirection.Left => CalculateLeftZeroCrossings(Position, command.Amount),
            RotationDirection.Right => CalculateRightZeroCrossings(Position, command.Amount),
            _ => throw new ArgumentOutOfRangeException(nameof(command))
        };
    }
    
    private static int CalculateRightZeroCrossings(int currentPosition, int amount)
    {
        return (currentPosition + amount) / DialPositions;
    }

    private static int CalculateLeftZeroCrossings(int currentPosition, int amount)
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
}