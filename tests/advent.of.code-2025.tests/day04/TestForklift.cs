using System.Runtime.InteropServices;

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

    
}

public record Coordinate(int Row, int Column);


public class StorageUnit
{
    private const char PaperRoll = '@';
    private const char EmptySpace = '.';
    private const int AccessCriterium = 4;

    public bool PaperRollIsAccessible(List<string> storageLayout, Coordinate location)
    {
        if (storageLayout[location.Row][location.Column] == EmptySpace)
        {
            return false;
        }
        
        var adjacentPaperRolls = 0;
        
        for (var columnIndex = location.Column - 1; columnIndex <= location.Column + 1; columnIndex++)
        {
            if (columnIndex < 0 || columnIndex >= storageLayout[location.Row].Length)
            {
                continue;
            }

            for (var rowIndex = location.Row - 1; rowIndex <= location.Row + 1; rowIndex++)
            {
                if (rowIndex < 0 || rowIndex >= storageLayout.Count)
                {
                    continue;
                }
                
                if (storageLayout[rowIndex][columnIndex] == PaperRoll && new Coordinate(rowIndex, columnIndex) != location)
                {
                    adjacentPaperRolls++;
                }   
            }
        }

        return adjacentPaperRolls < AccessCriterium;
    }

    public int CountAccessibleRolls(List<string> storageLayout)
    {
        var accessibleRoles = 0;
        for (var rowIndex = 0; rowIndex < storageLayout.Count; rowIndex++)
        {
            for (var columnIndex = 0; columnIndex < storageLayout[rowIndex].Length; columnIndex++)
            {
                if (PaperRollIsAccessible(storageLayout, new Coordinate(rowIndex, columnIndex)))
                {
                    accessibleRoles++;
                }
            }
        }

        return accessibleRoles;
    }
}