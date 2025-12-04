namespace advent.of.code_2025.day04;

public class StorageUnit
{
    #region BusinessConstants
    private const char PaperRoll = '@';
    private const char EmptySpace = '.';
    private const int AccessCriterion = 4;
    #endregion


    public int CountAccessibleRolls(List<string> storageLayout)
    {
        var accessibleRoles = 0;
        bool atleastOnePaperRollWasRemoved;

        do
        {
            atleastOnePaperRollWasRemoved = false;
            for (var rowIndex = 0; rowIndex < storageLayout.Count; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < storageLayout[rowIndex].Length; columnIndex++)
                {
                    var currentLocation = new Coordinate(rowIndex, columnIndex);
                    
                    if (PaperRollIsBlocked(storageLayout, currentLocation)) continue;
                    
                    atleastOnePaperRollWasRemoved = RemovePaperRoll(storageLayout, currentLocation);
                    accessibleRoles++;
                }
            }
        } while (atleastOnePaperRollWasRemoved);

        return accessibleRoles;
    }

    public bool PaperRollIsBlocked(List<string> storageLayout, Coordinate location)
    {
        if (storageLayout[location.Row][location.Column] == EmptySpace)
        {
            return true;
        }
        
        var adjacentPaperRolls = 0;
        
        for (var columnIndex = location.Column - 1; columnIndex <= location.Column + 1; columnIndex++)
        {
            if (IsColumnOutOfBounds(storageLayout[location.Row], columnIndex))
            {
                continue;
            }

            for (var rowIndex = location.Row - 1; rowIndex <= location.Row + 1; rowIndex++)
            {
                if (IsRowOutOfBounds(storageLayout.Count, rowIndex))
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
        
        return adjacentPaperRolls >= AccessCriterion;
    }

    private static bool IsColumnOutOfBounds(string storageRow, int columnIndex)
    {
        return columnIndex < 0 || columnIndex >= storageRow.Length;
    }

    private static bool IsRowOutOfBounds(int storageRowCount, int rowIndex)
    {
        return rowIndex < 0 || rowIndex >= storageRowCount;
    }

    private bool RemovePaperRoll(List<string> storageLayout, Coordinate currentLocation)
    {
        var rowPartBeforeCurrentLocation = storageLayout[currentLocation.Row][..currentLocation.Column];
        var rowPartAfterCurrentLocation = storageLayout[currentLocation.Row][(currentLocation.Column + 1)..];
        
        // replace character at current location with EmptySpace
        storageLayout[currentLocation.Row] =
            rowPartBeforeCurrentLocation + EmptySpace +
            rowPartAfterCurrentLocation;
        return true;
    }
}