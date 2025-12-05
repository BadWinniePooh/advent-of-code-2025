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

    [Fact]
    public void DataStructureContract()
    {
        var sut = new Ingredient("1");
        Assert.Equal(1, sut.Id);

        var sut2 = new IngredientRange("1-2");
        Assert.Equal(1, sut2.StartId);
        Assert.Equal(2, sut2.EndId);
    }

    [Theory]
    [InlineData("1", "1-2")]
    [InlineData("2", "1-2")]
    [InlineData("2", "1-3")]
    public void IngredientIsFresh(string idString, string rangeString)
    {
        var id = idString.ToIngredient();
        var range = rangeString.ToRange();

        var sut = id.IsFresh(range);
        
        Assert.True(sut);
    }

    [Theory]
    [InlineData("1", "2-4")]
    [InlineData("5", "2-4")]
    public void IngredientIsSpoiled(string idString, string rangeString)
    {
        var id = idString.ToIngredient();
        var range = rangeString.ToRange();

        var sut = id.IsFresh(range);
        
        Assert.False(sut);
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

public record IngredientRange(string Value)
{
    private int Separator => Value.IndexOf('-');
    public int StartId => int.Parse(Value[..Separator]);
    public int EndId => int.Parse(Value[(Separator + 1)..]);
}

public record Ingredient(string Value)
{
    public int Id => int.Parse(Value);

    public bool IsFresh(IngredientRange range)
    {
        return range.StartId <= Id && Id <= range.EndId;
    }
}

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
}