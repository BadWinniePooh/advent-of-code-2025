namespace advent.of.code_2025.day04;

public class StorageUnit
{
    public int CountAccessibleRolls(StorageLayout storageLayout)
    {
        var accessibleRoles = 0;
        bool atleastOnePaperRollWasRemoved;

        do
        {
            atleastOnePaperRollWasRemoved = false;
            for (var rowIndex = 0; rowIndex < storageLayout.Rows; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < storageLayout.Row(rowIndex).Columns; columnIndex++)
                {
                    var currentLocation = new Coordinate(rowIndex, columnIndex);
                    
                    if(storageLayout.IsBlocked(currentLocation)) continue;
                    
                    atleastOnePaperRollWasRemoved = storageLayout.UnblockAt(currentLocation);
                    accessibleRoles++;
                }
            }
        } while (atleastOnePaperRollWasRemoved);

        return accessibleRoles;
    }
}