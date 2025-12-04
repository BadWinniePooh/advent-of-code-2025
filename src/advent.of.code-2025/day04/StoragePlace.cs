namespace advent.of.code_2025.day04;

public sealed class StoragePlace(char value) : IEquatable<StoragePlace>
{
    private readonly char _value = value;
    public static readonly StoragePlace FreeStoragePlace = '.';
    private static readonly StoragePlace PaperRoll = '@';

    // Allow implicit conversion from char so `'a' == place` will compile.
    public static implicit operator StoragePlace(char c) => new(c);

    // Allow explicit conversion back to char if needed.
    public static explicit operator char(StoragePlace p) => p._value;
    
    public bool Equals(StoragePlace? other) => _value == other?._value;
    
    public override bool Equals(object? obj) => obj is StoragePlace sp && Equals(sp);

    public override int GetHashCode() => _value.GetHashCode();
    
    public override string ToString() => $"{_value}";

    public bool IsFree() => Equals(FreeStoragePlace);
    
    public bool IsOccupied() => Equals(PaperRoll);
}