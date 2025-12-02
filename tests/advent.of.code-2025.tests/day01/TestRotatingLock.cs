using advent.of.code_2025.day01;

namespace advent.of.code_2025.tests.day01;

public class TestRotatingLock
{
    [Fact]
    public void WhenDialIsNotRotated_ThenPositionDoesNotChange()
    {
        var startingPosition = 50;
        var sut = new Lock(startingPosition);

        sut.Rotate("L0");
        
        Assert.Equal(startingPosition, sut.CurrentPosition);
        Assert.Equal(0, sut.Password);
    }

    [Fact]
    public void WhenDialIsRotatedLeft_ThenPositionIsSubtracted()
    {
        var startingPosition = 50;
        var sut = new Lock(startingPosition);
        
        sut.Rotate("L5");
        
        Assert.Equal(45, sut.CurrentPosition);
        Assert.Equal(0, sut.Password);
    }

    [Fact]
    public void WhenDialIsRotatedRight_ThenPositionIsAdded()
    {
        var startingPosition = 50;
        var sut = new Lock(startingPosition);
        
        sut.Rotate("R5");

        Assert.Equal(55, sut.CurrentPosition);
        Assert.Equal(0, sut.Password);
    }

    [Fact]
    public void WhenDialIsRotatedByFullTurn_ThenForEveryPassOfZeroExpectedPasswordIsIncreasedByOne()
    {
        var startingPosition = 50;
        var sut = new Lock(startingPosition);
        
        sut.Rotate("R100");
        sut.Rotate("L100");
        
        Assert.Equal(startingPosition, sut.CurrentPosition);
        Assert.Equal(2, sut.Password);
    }

    [Fact]
    public void WhenDialIsTurnedToLandOnZero_ThenExpectedPasswordIsIncreasedByOne()
    {
        var startingPosition = 50;
        var sut = new Lock(startingPosition);
        
        sut.Rotate("L50");
        
        Assert.Equal(0, sut.CurrentPosition);
        Assert.Equal(1, sut.Password);
    }

    [Fact]
    public void WhenDialIsTurnedLeftOverZero_ThenExpectedPasswordIsSubtractedBy100()
    {
        var startingPosition = 50;
        var sut = new Lock(startingPosition);
        
        sut.Rotate("L51");
        
        Assert.Equal(99, sut.CurrentPosition);
        Assert.Equal(1, sut.Password);
    }

    [Fact]
    public void ApprovalTestByCode()
    {
        var startingPosition = 50;
        var expectedPasswordInRiddle = 6;
        var sut = new Lock(startingPosition);
        
        sut.Rotate("L68");
        sut.Rotate("L30");
        sut.Rotate("R48");
        sut.Rotate("L5");
        sut.Rotate("R60");
        sut.Rotate("L55");
        sut.Rotate("L1");
        sut.Rotate("L99");
        sut.Rotate("R14");
        sut.Rotate("L82");
        
        Assert.Equal(expectedPasswordInRiddle, sut.Password);
    }

    [Fact]
    public void ApprovalTestByFile()
    {
        var expected = 6;
        var startingPosition = 50;
        var dialInput = File.ReadLines("./Day01/TestInput.txt");
        var sut = new LockSolver(dialInput, startingPosition);
        
        var actual = sut.Solve();
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ASingleRightRotationOf1000WouldCauseTheDialToPointAtZero_TenTimes()
    {
        var expected = 10;
        var startingPosition = 50;
        var sut = new Lock(startingPosition);
        
        sut.Rotate("R1000");
        
        Assert.Equal(startingPosition, sut.CurrentPosition);
        Assert.Equal(expected, sut.Password);
    }
    
    [Fact]
    public void ASingleRightRotationOf1001WouldCauseTheDialToPointAtZero_TenTimes()
    {
        var expected = 10;
        var startingPosition = 50;
        var sut = new Lock(startingPosition);
        
        sut.Rotate("R1001");
        
        Assert.Equal(51, sut.CurrentPosition);
        Assert.Equal(expected, sut.Password);
    }
    
    [Fact]
    public void ASingleLeftRotationOf1000WouldCauseTheDialToPointAtZero_TenTimes()
    {
        var expected = 10;
        var startingPosition = 50;
        var sut = new Lock(startingPosition);
        
        sut.Rotate("L1000");
        
        Assert.Equal(startingPosition, sut.CurrentPosition);
        Assert.Equal(expected, sut.Password);
    }
    
    [Fact]
    public void ASingleLeftRotationOf1001WouldCauseTheDialToPointAtZero_TenTimes()
    {
        var expected = 10;
        var startingPosition = 50;
        var sut = new Lock(startingPosition);
        
        sut.Rotate("L1001");
        
        Assert.Equal(49, sut.CurrentPosition);
        Assert.Equal(expected, sut.Password);
    }

    [Fact(DisplayName = "Solution", Skip = "Skip by default")]
    //[Fact(DisplayName = "Solution")]
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