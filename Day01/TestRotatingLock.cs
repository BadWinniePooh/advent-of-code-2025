namespace advent.of.code_2025.Day01;

public class TestRotatingLock
{
    [Fact]
    public void WhenDialIsNotRotated_ThenPositionDoesNotChange()
    {
        var startingPosition = 50;
        var sut = new Lock(startingPosition);

        sut.Dial.Rotate("L0");
        
        Assert.Equal(startingPosition, sut.Dial.Position);
    }

    [Fact]
    public void WhenDialIsRotatedLeft_ThenPositionIsSubtracted()
    {
        var startingPosition = 50;
        var sut = new Lock(startingPosition);
        
        sut.Dial.Rotate("L5");
        
        Assert.Equal(45, sut.Dial.Position);
    }

    [Fact]
    public void WhenDialIsRotatedRight_ThenPositionIsAdded()
    {
        var startingPosition = 50;
        var sut = new Lock(startingPosition);
        
        sut.Dial.Rotate("R5");

        Assert.Equal(55, sut.Dial.Position);
    }

    [Fact]
    public void WhenDialIsRotatedByFullTurn_ThenPositionDoesNotChange()
    {
        var startingPosition = 50;
        var sut = new Lock(startingPosition);
        
        sut.Dial.Rotate("R100");
        
        Assert.Equal(startingPosition, sut.Dial.Position);
    }
}