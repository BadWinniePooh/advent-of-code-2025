namespace advent.of.code_2025.day01;

public record RotationCommand(RotationDirection Direction, int Amount)
{
    public static RotationCommand Parse(string input)
    {
        var direction = input[0] switch
        {
            'L' => RotationDirection.Left,
            'R' => RotationDirection.Right,
            _ => throw new ArgumentException($"Invalid direction: '{input[0]}'")
        };

        if (!int.TryParse(input[1..], out var amount) || amount < 0)
            throw new ArgumentException($"Invalid amount: '{input[1..]}'");
        return new RotationCommand(direction, amount);
    }
}