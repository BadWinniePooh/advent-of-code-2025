namespace advent.of.code_2025.tests.day04;

public class TestForklift
{
    [Theory]
    [InlineData(".@.", true, 0 , 1)]
    [InlineData("@..", true, 0 , 0)]
    [InlineData("..@", true, 0 , 2)]
    public void PaperRollInEmptyColumnIsAccessible(string input, bool expected, int row, int column)
    {
        var storage = new StorageUnit();
        var location = new Coordinate(row, column);
        
        var actual = storage.PaperRollIsAccessible(input, location);
        
        Assert.Equal(expected, actual);
    }
}

public record Coordinate(int row, int column);


public class StorageUnit
{
    private const char PaperRoll = '@';
    private const char EmptySpace = '.';

    public bool PaperRollIsAccessible(string storageUnit, Coordinate location)
    {
        var adjacentPaperRolls = 0;

        for (var columnIndex = location.column - 1; columnIndex <= location.column + 1; columnIndex++)
        {
            if (columnIndex < 0 || columnIndex >= storageUnit.Length)
            {
                continue;
            }
            
            if (storageUnit[columnIndex] == PaperRoll)
            {
                adjacentPaperRolls++;
            }
        }

        return adjacentPaperRolls < 4;
    }
}