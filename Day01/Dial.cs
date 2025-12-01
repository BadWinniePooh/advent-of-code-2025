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
            var newPosition = Position - rotationAmount;
            
            if (Position == MinPosition)
            {
                ExpectedPassword += rotationAmount / DialPositions;
            }
            else
            {
                var distanceFromZero = Position;
                if (rotationAmount >= distanceFromZero)
                {
                    var remainingAfterFirstCross = rotationAmount - distanceFromZero;
                    ExpectedPassword += 1 + (remainingAfterFirstCross / DialPositions);
                }
            }
            
            Position = ((newPosition % DialPositions) + DialPositions) % DialPositions;
        }
        else if (input.StartsWith('R'))
        {
            var newPosition = Position + rotationAmount;
            ExpectedPassword += newPosition / DialPositions;
            Position = newPosition % DialPositions;
        }
    }

    public int Position { get; private set; } = startingPosition;
    public int ExpectedPassword { get; private set; }
}