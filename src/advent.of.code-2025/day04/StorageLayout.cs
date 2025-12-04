namespace advent.of.code_2025.day04;

public class StorageLayout : List<string>
{
    public StorageLayout() {}
    public StorageLayout(IEnumerable<string> collection) : base(collection){}
    
    public StoragePlace At(Coordinate location)
    {
        return this[location.Row][location.Column];
    }

    public bool FreeSpaceAt(Coordinate currentLocation)
    {
        var rowPartBeforeCurrentLocation = this[currentLocation.Row][..currentLocation.Column];
        var rowPartAfterCurrentLocation = this[currentLocation.Row][(currentLocation.Column + 1)..];
        
        // replace character at current location with new char
        this[currentLocation.Row] =
            rowPartBeforeCurrentLocation + StoragePlace.FreeStoragePlace +
            rowPartAfterCurrentLocation;
        return true;
    }
}

public static class StorageLayoutExtensions
{
    public static StorageLayout ToStorageLayout(this IEnumerable<string> source)
    {
        return new StorageLayout(source);
    }
}