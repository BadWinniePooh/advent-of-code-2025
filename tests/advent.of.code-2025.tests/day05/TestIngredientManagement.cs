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

    [Theory]
    [InlineData("18", "10-14", "12-18")]
    [InlineData("10", "10-14", "12-18")]
    [InlineData("13", "10-14", "12-18")]
    public void IngredientIsFresh_WithMultipleRanges(string idString, string range1, string range2)
    {
        var id = idString.ToIngredient();
        var ranges = new List<IngredientRange>
        {
            range1.ToRange(),
            range2.ToRange()
        };

        var sut = id.IsFresh(ranges);
        
        Assert.True(sut);
    }
    
    [Theory]
    [InlineData("9", "10-14", "12-18")]
    [InlineData("19", "10-14", "12-18")]
    public void IngredientIsSpoiled_WithMultipleRanges(string idString, string range1, string range2)
    {
        var id = idString.ToIngredient();
        var ranges = new List<IngredientRange>
        {
            range1.ToRange(),
            range2.ToRange()
        };

        var sut = id.IsFresh(ranges);
        
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

    public bool Contains(Ingredient ingredient)
    {
        return StartId <= ingredient.Id && ingredient.Id <= EndId;
    }
}

public record Ingredient(string Value)
{
    public int Id => int.Parse(Value);

    public bool IsFresh(IngredientRange range)
    {
        return range.Contains(this);
    }

    public bool IsFresh(List<IngredientRange> ranges)
    {
        return ranges.Any(r => r.Contains(this));
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