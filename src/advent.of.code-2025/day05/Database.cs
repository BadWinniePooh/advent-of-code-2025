namespace advent.of.code_2025.day05;

public class Database
{
    public void InitDatabase(string[] dirtyDb)
    {
        var switchDatabase = false;
        foreach (var entry in dirtyDb)
        {
            if (entry == "")
            {
                switchDatabase = true;
                continue;
            }

            if (switchDatabase)
            {
                IngredientsInStorage.Add(new(entry));
            }
            else
            {
                FreshIngredientRanges.Add(new(entry));
            }
            
        }
    }

    public List<Ingredient> IngredientsInStorage { get; } = [];

    public List<IngredientRange> FreshIngredientRanges { get; } = [];

    public long CountDifferentFreshIngredients(string[] dirtyDb)
    {
        InitDatabase(dirtyDb);
        return FreshIngredientRanges.CountDistinct();
    }
}