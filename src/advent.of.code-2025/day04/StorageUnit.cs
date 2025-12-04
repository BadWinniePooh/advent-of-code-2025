namespace advent.of.code_2025.day04;

public class StorageUnit
{
    private const char PaperRoll = '@';
    private const char EmptySpace = '.';
    private const int AccessCriterium = 4;
    private List<string> _storageLayout;

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

                var isAdjacentPosition = new Coordinate(rowIndex, columnIndex) != location;
                if (storageLayout[rowIndex][columnIndex] == PaperRoll && isAdjacentPosition)
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
        bool paperRollWasRemoved;

        do
        {
            paperRollWasRemoved = false;
            for (var rowIndex = 0; rowIndex < storageLayout.Count; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < storageLayout[rowIndex].Length; columnIndex++)
                {
                    var currentLocation = new Coordinate(rowIndex, columnIndex);
                    if (PaperRollIsAccessible(storageLayout, currentLocation))
                    {
                        paperRollWasRemoved = RemovePaperRoll(storageLayout, currentLocation);
                        accessibleRoles++;
                    }
                }
            }
        } while (paperRollWasRemoved);

        return accessibleRoles;
    }

    private bool RemovePaperRoll(List<string> storageLayout, Coordinate currentLocation)
    {
        storageLayout[currentLocation.Row] =
            storageLayout[currentLocation.Row].Substring(0, currentLocation.Column) + EmptySpace +
            storageLayout[currentLocation.Row].Substring(currentLocation.Column + 1);
        return true;
    }
}