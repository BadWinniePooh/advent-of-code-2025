namespace advent.of.code_2025.day04;

public class StorageUnit
{
    #region BusinessConstants
    private const int AccessCriterion = 4;
    #endregion


    public int CountAccessibleRolls(StorageLayout storageLayout)
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
                    
                    if (StorageLocationIsBlocked(storageLayout, currentLocation)) continue;
                    
                    atleastOnePaperRollWasRemoved = storageLayout.FreeSpaceAt(currentLocation);
                    accessibleRoles++;
                }
            }
        } while (atleastOnePaperRollWasRemoved);

        return accessibleRoles;
    }

    public bool StorageLocationIsBlocked(StorageLayout storageLayout, Coordinate location)
    {
        if (storageLayout.At(location).IsFree())
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

                var currentLocation = new Coordinate(rowIndex, columnIndex);
                var isAdjacentPosition =  currentLocation != location;
                if (storageLayout.At(currentLocation).IsOccupied() && isAdjacentPosition)
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
}