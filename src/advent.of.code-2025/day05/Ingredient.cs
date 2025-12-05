namespace advent.of.code_2025.day05;

public record Ingredient(string Value)
{
    public long Id => long.Parse(Value);

    public bool IsFresh(IngredientRange range)
    {
        return range.Contains(this);
    }

    public bool IsFresh(List<IngredientRange> ranges)
    {
        return ranges.Any(r => r.Contains(this));
    }
}