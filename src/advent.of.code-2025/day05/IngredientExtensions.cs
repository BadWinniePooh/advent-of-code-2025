namespace advent.of.code_2025.day05;

public static class IngredientExtensions
{
    public static Ingredient ToIngredient(this string input)
    {
        return new Ingredient(input);
    }

    public static IngredientRange ToRange(this string input)
    {
        return new IngredientRange(input);
    }

    private static List<Ingredient> _ingredients;
    
    public static void Add(this List<Ingredient> source, IngredientRange items)
    {
        _ingredients = source;
        _ingredients.AddRange(items.ToList());
    }
}