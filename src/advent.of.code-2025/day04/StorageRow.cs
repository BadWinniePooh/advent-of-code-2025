using System.Collections;

namespace advent.of.code_2025.day04;

public readonly struct StorageRow(StoragePlace[] places) : IEnumerable<StoragePlace>, IEquatable<StorageRow>
{
    private readonly StoragePlace[] _places = places;

    public int Columns => _places?.Length ?? 0;

    // Existing int indexer (keeps mutation semantics if underlying array is mutable).
    public StoragePlace this[int index] => _places[index];

    // Support Range slicing: row[..5], row[1..4] -> returns a new StorageRow wrapping the sliced array.
    // Requires C# 8 / .NET Core 3.0+ or netstandard2.1 because it uses System.Range/System.Index array slicing.
    public StorageRow this[Range range]
    {
        get
        {
            var slice = places[range]; // returns new array
            return new StorageRow(slice);
        }
    }

    public IEnumerator<StoragePlace> GetEnumerator() => ((IEnumerable<StoragePlace>)_places).GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    // Implicit conversion from StoragePlace[] so you can pass arrays directly.
    public static implicit operator StorageRow(StoragePlace[] places) => new(places);
    
    // Concatenation operators
    // row + place -> new row with place appended
    public static StorageRow operator +(StorageRow row, StoragePlace place)
    {
        var left = row._places;
        var result = new StoragePlace[left.Length + 1];
        Array.Copy(left, 0, result, 0, left.Length);
        result[left.Length] = place;
        return new StorageRow(result);
    }

    // row + row -> concatenation
    public static StorageRow operator +(StorageRow leftRow, StorageRow rightRow)
    {
        var left = leftRow._places;
        var right = rightRow._places;
        var result = new StoragePlace[left.Length + right.Length];
        Array.Copy(left, 0, result, 0, left.Length);
        Array.Copy(right, 0, result, left.Length, right.Length);
        return new StorageRow(result);
    }

    // Sequence equality
    public bool Equals(StorageRow other) => _places == other._places;

    public override bool Equals(object obj) => obj is StorageRow other && Equals(other);

    public override int GetHashCode() => _places.GetHashCode();
}