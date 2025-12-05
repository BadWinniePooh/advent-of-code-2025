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

    public List<Ingredient> ToList()
    {
        var counter = new List<Ingredient>();
        for (var start = StartId; start <= EndId; start++)
        {
            counter.Add(new Ingredient(start.ToString()));
        }

        return counter;
    }
}

public static class IngredientRangeExtensions
{
    public static long CountDistinct(this List<IngredientRange> ranges)
    {
        var ingredients = ConvertToIngredients(ranges);
        
        return ingredients.Distinct().Count();
    }

    private static List<Ingredient> ConvertToIngredients(List<IngredientRange> ranges)
    {
        var result = new List<Ingredient>();
        foreach (var range in ranges)
        {
            result.Add(range);
        }

        return result;
    }
}