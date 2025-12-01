namespace advent.of.code_2025;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        var startingPosition = 50;
        var sut = new Lock(startingPosition);

        sut.Dial.Rotate("L0");
        
        Assert.Equal(50, 
            sut.Dial.Position);
    }

    [Fact]
    public void T2()
    {
        var startingPosition = 50;
        var sut = new Lock(startingPosition);
        
        sut.Dial.Rotate("L5");
        
        Assert.Equal(45,
            sut.Dial.Position);
    }
}

public class Lock
{
    public Lock(int startingPosition)
    {
        Dial = new Dial(startingPosition);
    }

    public Dial Dial { get; }
}

public class Dial
{
    public Dial(int startingPosition)
    {
        Position = startingPosition;
    }

    public void Rotate(string input)
    {
        var rotationAmount = int.Parse(input.Remove(0, 1));
        if (input.StartsWith('L'))
        {
            Position -= rotationAmount;
        }
    }

    public int Position { get; private set; }
}