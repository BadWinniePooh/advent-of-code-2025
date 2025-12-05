namespace advent.of.code_2025.day05;

public record IngredientRange(string Value)
{
    private int Separator => Value.IndexOf('-');
    public int StartId => int.Parse(Value[..Separator]);
    public int EndId => int.Parse(Value[(Separator + 1)..]);

    public bool Contains(Ingredient ingredient)
    {
        return StartId <= ingredient.Id && ingredient.Id <= EndId;
    }
}