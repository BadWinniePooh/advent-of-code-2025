namespace advent.of.code_2025.day04;

public record Coordinate(int Row, int Column)
{
    public int NextColumn => Column + 1;
    public int NextRow => Row + 1;
    public int PreviousColumn => Column - 1;
    public int PreviousRow => Row - 1;

    public bool IsAdjacent(Coordinate location)
    {
        return this != location;
    }
}