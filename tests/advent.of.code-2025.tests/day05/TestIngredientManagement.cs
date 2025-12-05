namespace advent.of.code_2025.tests.day05;

public class TestIngredientManagement
{
    [Fact]
    public void InitDatabaseStructuresInputData()
    {
        var dirtyDb = File.ReadAllLines("./Day05/TestInput.txt");
        var sut = new Database();
        sut.InitDatabase(dirtyDb);
        
        Assert.Equal(4, sut.FreshIngredientRanges.Count);
        Assert.Equal(6, sut.IngredientsInStorage.Count);
    }
}

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

    public List<Ingredient> FreshIngredientRanges { get; } = [];

    public List<IngredientRange> IngredientsInStorage { get; } = [];
}

public record IngredientRange(string range)
{
    private int Separator => range.IndexOf('-');
    public int StartId => int.Parse(range[..Separator]);
    public int EndId => int.Parse(range[Separator..]);
}

public record Ingredient(string ingredient)
{
    public int Id => int.Parse(ingredient);
}