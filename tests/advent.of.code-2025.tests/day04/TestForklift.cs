using System.Runtime.InteropServices;
using advent.of.code_2025.day04;

namespace advent.of.code_2025.tests.day04;

public class TestForklift
{
    [Theory]
    [InlineData(".@.", 0 , 1)]
    [InlineData("@..", 0 , 0)]
    [InlineData("..@", 0 , 2)]
    public void PaperRollInEmptyRowIsAccessible(string input, int row, int column)
    {
        var expected = false;
        var storage = new StorageUnit();
        var location = new Coordinate(row, column);
        var storageLayout = new StorageLayout { input };
        
        var actual = storage.StorageLocationIsBlocked(storageLayout, location);
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void WhenTestedObjectIsEmptySpace_ThenItIsConsideredAsBlocked()
    {
        var expected = true;
        var storage = new StorageUnit();
        var location = new Coordinate(0,0);
        var storageLayout = new StorageLayout { "..." };
        
        var actual = storage.StorageLocationIsBlocked(storageLayout, location);
        
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("@@@", "@@@", "@@@")]
    [InlineData(".@.", "@@@", ".@.")]
    [InlineData("@.@", ".@.", "@.@")]
    public void PaperRollSurroundedByPaperRollsIsBlocked(string row1, string row2, string row3)
    {
        var expected = true;
        var storage = new StorageUnit();
        var location = new Coordinate(1, 1);
        var storageLayout = new StorageLayout { row1, row2, row3 };

        var actual = storage.StorageLocationIsBlocked(storageLayout, location);
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void PaperRollInTwoByTwoIsAccessible()
    {
        var expected = false;
        var storage = new StorageUnit();
        var location = new Coordinate(0, 0);
        var storageLayout = new StorageLayout { "@@", "@@" };

        var actual = storage.StorageLocationIsBlocked(storageLayout, location);
        
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("@@@@@", 5)]
    [InlineData("..@..", 1)]
    [InlineData(".@.@.", 2)]
    public void CountAccessibleRolesInOneRow(string row, int expected)
    {
        var storage = new StorageUnit();
        var storageLayout = new StorageLayout { row };

        var actual = storage.CountAccessibleRolls(storageLayout);
        
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("@@@", "@@@", "@@@", 9)]
    [InlineData(".@.", "@@@", ".@.", 5)]
    [InlineData("@@@", ".@.", "@@@", 7)]
    public void CountAccessibleRolesInThreeByThreeArrangement(string row1, string row2, string row3, int expected)
    {
        var storage = new StorageUnit();
        var storageLayout = new StorageLayout { row1, row2, row3 };

        var actual = storage.CountAccessibleRolls(storageLayout);
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ApprovalTestByFile()
    {
        var expected = 43;
        var storageLayout = File.ReadAllLines("./Day04/TestInput.txt");
        var sut = new RiddleSolver(storageLayout);

        var actual = sut.SolveDay4();
        
        Assert.Equal(expected, actual);
    }
    
    [Fact(DisplayName = "Solution", Skip = "Skip by default")]
    //[Fact(DisplayName = "Solution")]
    public void RiddleSolution()
    {
        var expected = 0;
        var input = File.ReadAllLines("./Day04/PuzzleInput");
        var sut = new RiddleSolver(input);

        var actual = sut.SolveDay4();
        
        Assert.Equal(expected, actual);
    }
}