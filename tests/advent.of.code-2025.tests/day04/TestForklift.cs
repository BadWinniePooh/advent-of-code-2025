namespace advent.of.code_2025.tests.day04;

public class TestForklift
{
    [Fact]
    public void PaperRollInEmptyColumnIsAccessible()
    {
        var expected = true;
        var storage = new StorageUnit();
        var location = new Coordinate(0, 1);
        
        var actual = storage.PaperRollIsAccessible(".@.", location);
        
        Assert.Equal(expected, actual);
    }
}

public record Coordinate(int row, int column);


public class StorageUnit
{
    private const char PaperRoll = '@';
    private const char EmptySpace = '.';

    public bool PaperRollIsAccessible(string s, Coordinate location)
    {
        var adjacentPaperRolls = 0;

        for (var locationIndex = location.column - 1; locationIndex <= location.column + 1; locationIndex++)
        {
            if (s[locationIndex] == PaperRoll)
            {
                adjacentPaperRolls++;
            }
        }

        return adjacentPaperRolls < 4;
    }
}