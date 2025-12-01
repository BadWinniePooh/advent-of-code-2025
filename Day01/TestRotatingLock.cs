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
        Assert.Equal(0, sut.Dial.ExpectedPassword);
    }

    [Fact]
    public void WhenDialIsRotatedLeft_ThenPositionIsSubtracted()
    {
        var startingPosition = 50;
        var sut = new Lock(startingPosition);
        
        sut.Dial.Rotate("L5");
        
        Assert.Equal(45, sut.Dial.Position);
        Assert.Equal(0, sut.Dial.ExpectedPassword);
    }

    [Fact]
    public void WhenDialIsRotatedRight_ThenPositionIsAdded()
    {
        var startingPosition = 50;
        var sut = new Lock(startingPosition);
        
        sut.Dial.Rotate("R5");

        Assert.Equal(55, sut.Dial.Position);
        Assert.Equal(0, sut.Dial.ExpectedPassword);
    }

    [Fact]
    public void WhenDialIsRotatedByFullTurn_ThenForEveryPassOfZeroExpectedPasswordIsIncreasedByOne()
    {
        var startingPosition = 50;
        var sut = new Lock(startingPosition);
        
        sut.Dial.Rotate("R100");
        sut.Dial.Rotate("L100");
        
        Assert.Equal(startingPosition, sut.Dial.Position);
        Assert.Equal(2, sut.Dial.ExpectedPassword);
    }

    [Fact]
    public void WhenDialIsTurnedToLandOnZero_ThenExpectedPasswordIsIncreasedByOne()
    {
        var startingPosition = 50;
        var sut = new Lock(startingPosition);
        
        sut.Dial.Rotate("L50");
        
        Assert.Equal(0, sut.Dial.Position);
        Assert.Equal(1, sut.Dial.ExpectedPassword);
    }

    [Fact]
    public void WhenDialIsTurnedLeftOverZero_ThenExpectedPasswordIsSubtractedBy100()
    {
        var startingPosition = 50;
        var sut = new Lock(startingPosition);
        
        sut.Dial.Rotate("L51");
        
        Assert.Equal(99, sut.Dial.Position);
        Assert.Equal(1, sut.Dial.ExpectedPassword);
    }

    [Fact]
    public void RiddleExample()
    {
        var startingPosition = 50;
        var expectedPasswordInRiddle = 6;
        var sut = new Lock(startingPosition);
        
        sut.Dial.Rotate("L68");
        sut.Dial.Rotate("L30");
        sut.Dial.Rotate("R48");
        sut.Dial.Rotate("L5");
        sut.Dial.Rotate("R60");
        sut.Dial.Rotate("L55");
        sut.Dial.Rotate("L1");
        sut.Dial.Rotate("L99");
        sut.Dial.Rotate("R14");
        sut.Dial.Rotate("L82");
        
        Assert.Equal(expectedPasswordInRiddle, sut.Dial.ExpectedPassword);
    }

    [Fact]
    public void LockSolver()
    {
        var expected = 6;
        var startingPosition = 50;
        var dialInput = File.ReadLines("./Day01/TestInput.txt");
        var sut = new LockSolver(dialInput, startingPosition);
        
        var actual = sut.Solve();
        
        Assert.Equal(expected, actual);
    }

    [Fact(DisplayName = "Solution", Skip = "Skip by default")]
    public void LockSolver2()
    {
        var expected = 0;
        var startingPosition = 50;
        var dialInput = File.ReadLines("./Day01/PuzzleInput");
        var sut = new LockSolver(dialInput, startingPosition);
        
        var actual = sut.Solve();
        
        Assert.Equal(expected, actual);
    }
}