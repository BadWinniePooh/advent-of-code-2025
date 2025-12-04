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
        var expected = true;
        var storage = new StorageUnit();
        var location = new Coordinate(row, column);
        var storageLayout = new List<string> { input };
        
        var actual = storage.PaperRollIsAccessible(storageLayout, location);
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void WhenTestedObjectIsEmptySpace_ThenItIsCountedAsNotAccessible()
    {
        var expected = false;
        var storage = new StorageUnit();
        var location = new Coordinate(0,0);
        var storageLayout = new List<string> { "..." };
        
        var actual = storage.PaperRollIsAccessible(storageLayout, location);
        
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("@@@", "@@@", "@@@")]
    [InlineData(".@.", "@@@", ".@.")]
    [InlineData("@.@", ".@.", "@.@")]
    public void PaperRollSurroundedByPaperRollsIsNotAccessible(string row1, string row2, string row3)
    {
        var expected = false;
        var storage = new StorageUnit();
        var location = new Coordinate(1, 1);
        var storageLayout = new List<string> { row1, row2, row3 };

        var actual = storage.PaperRollIsAccessible(storageLayout, location);
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void PaperRollInTwoByTwoIsAccessible()
    {
        var expected = true;
        var storage = new StorageUnit();
        var location = new Coordinate(0, 0);
        var storageLayout = new List<string> { "@@", "@@" };

        var actual = storage.PaperRollIsAccessible(storageLayout, location);
        
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("@@@@@", 5)]
    [InlineData("..@..", 1)]
    [InlineData(".@.@.", 2)]
    public void CountAccessibleRolesInOneRow(string row, int expected)
    {
        var storage = new StorageUnit();
        var storageLayout = new List<string> { row };

        var actual = storage.CountAccessibleRolls(storageLayout);
        
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("@@@", "@@@", "@@@", 4)]
    [InlineData(".@.", "@@@", ".@.", 4)]
    [InlineData("@@@", ".@.", "@@@", 6)]
    public void CountAccessibleRolesInThreeByThreeArrangement(string row1, string row2, string row3, int expected)
    {
        var storage = new StorageUnit();
        var storageLayout = new List<string> { row1, row2, row3 };

        var actual = storage.CountAccessibleRolls(storageLayout);
        
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ApprovalTestByFile()
    {
        var expected = 13;
        var storageLayout = File.ReadAllLines("./Day04/TestInput.txt");
        var sut = new RiddleSolver(storageLayout);

        var actual = sut.SolveDay4();
        
        Assert.Equal(expected, actual);
    }
}