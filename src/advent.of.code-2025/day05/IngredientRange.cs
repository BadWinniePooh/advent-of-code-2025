namespace advent.of.code_2025.day05;

public record IngredientRange(string Value)
{
    private int SeparatorIndex => Value.IndexOf('-');
    public long StartId => long.Parse(Value[..SeparatorIndex]);
    public long EndId => long.Parse(Value[(SeparatorIndex + 1)..]);

    public bool Contains(Ingredient ingredient)
    {
        return StartId <= ingredient.Id && ingredient.Id <= EndId;
    }

    public long Count()
    {
        var counter = 0;
        for (var start = StartId; start <= EndId; start++)
        {
            counter++;
        }

        return counter;
    }
}