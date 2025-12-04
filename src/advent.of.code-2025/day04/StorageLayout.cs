using System.Data.Common;

namespace advent.of.code_2025.day04;

public class StorageLayout : List<string>
{
    private const int AccessCriterion = 4;
    
    public StorageLayout() {}
    public StorageLayout(IEnumerable<string> collection) : base(collection){}
    public int Rows => Count;

    private StoragePlace At(Coordinate location)
    {
        return this[location.Row][location.Column];
    }

    public bool UnblockAt(Coordinate currentLocation)
    {
        var rowPartBeforeCurrentLocation = this[currentLocation.Row][..currentLocation.Column];
        var rowPartAfterCurrentLocation = this[currentLocation.Row][(currentLocation.NextColumn)..];
        
        // replace character at current location with new char
        this[currentLocation.Row] =
            rowPartBeforeCurrentLocation + StoragePlace.FreeStoragePlace +
            rowPartAfterCurrentLocation;
        return true;
    }

    public bool IsBlocked(Coordinate currentLocation)
    {
        if (At(currentLocation).IsFree())
        {
            return true;
        }
        
        var adjacentPaperRolls = 0;
        
        for (var columnIndex = currentLocation.PreviousColumn; columnIndex <= currentLocation.NextColumn; columnIndex++)
        {
            if(IsColumnOutOfBounds(Row(currentLocation), columnIndex))
                continue;

            for (var rowIndex = currentLocation.PreviousRow; rowIndex <= currentLocation.NextRow; rowIndex++)
            {
                if (IsRowOutOfBounds(rowIndex))
                {
                    continue;
                }

                var location = new Coordinate(rowIndex, columnIndex);
                if (At(location).IsOccupied() && location.IsAdjacent(currentLocation))
                {
                    adjacentPaperRolls++;
                }   
            }
        }
        
        return adjacentPaperRolls >= AccessCriterion;
    }

    public string Row(int row)
    {
        return this[row];
    }
    
    private string Row(Coordinate currentLocation)
    {
        return Row(currentLocation.Row);
    }

    private static bool IsColumnOutOfBounds(string storageRow, int columnIndex)
    {
        return columnIndex < 0 || columnIndex >= storageRow.Columns();
    }

    private bool IsRowOutOfBounds(int rowIndex)
    {
        return rowIndex < 0 || rowIndex >= Rows;
    }
}

public static class StorageLayoutExtensions
{
    public static StorageLayout ToStorageLayout(this IEnumerable<string> source)
    {
        return new StorageLayout(source);
    }

    public static int Columns(this string row) => row.Length;
}