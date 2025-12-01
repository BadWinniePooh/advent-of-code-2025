namespace advent.of.code_2025.Day01;

public class Dial(int startingPosition)
{
    public void Rotate(string input)
    {
        var rotationAmount = int.Parse(input.Remove(0, 1));
        
        if (input.StartsWith('L'))
        {
            var newPosition = Position - rotationAmount;
            
            if (Position == 0)
            {
                ExpectedPassword += rotationAmount / 100;
            }
            else
            {
                var distanceFromZero = Position;
                if (rotationAmount >= distanceFromZero)
                {
                    var remainingAfterFirstCross = rotationAmount - distanceFromZero;
                    ExpectedPassword += 1 + (remainingAfterFirstCross / 100);
                }
            }
            
            Position = ((newPosition % 100) + 100) % 100;
        }
        else if (input.StartsWith('R'))
        {
            var newPosition = Position + rotationAmount;
            ExpectedPassword += newPosition / 100;
            Position = newPosition % 100;
        }
    }

    public int Position { get; private set; } = startingPosition;
    public int ExpectedPassword { get; private set; }
}