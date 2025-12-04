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

    [Fact]
    public void PaperRollSurroundedByPaperRollsIsNotAccessible()
    {
        var expected = false;
        var storage = new StorageUnit();
        var location = new Coordinate(1, 1);
        var storageLayout = new List<string> { "@@@", "@@@", "@@@" };

        var actual = storage.PaperRollIsAccessible(storageLayout, location);
        
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
                
                if (storageLayout[rowIndex][columnIndex] == PaperRoll)
                {
                    adjacentPaperRolls++;
                }   
            }
        }

        return adjacentPaperRolls < AccessCriterium;
    }
}