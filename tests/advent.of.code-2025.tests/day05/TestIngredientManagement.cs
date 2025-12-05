using advent.of.code_2025.day05;

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
        Assert.Equal(7, sut.IngredientsInStorage.Count);
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

    [Theory]
    [InlineData("1-3", 3)]
    [InlineData("1-10", 10)]
    [InlineData("1-10,20-30", 21)]
    [InlineData("1-10,5-15", 15)]
    [InlineData("1-10,5-15,14-20", 20)]
    public void CountIngredientsInRange(string range, int expected)
    {
        var db = new Database();
        var ranges = range.Split(',');
        var sut = db.CountDifferentFreshIngredients(ranges);

        Assert.Equal(expected, sut);
    }

    [Fact]
    public void ApprovalTestByFile_CountFreshIngredients()
    {
        var dirtyDb = File.ReadAllLines("./Day05/TestInput.txt");
        var sut = new RiddleSolver(dirtyDb);
        var actual = sut.SolveDay5();
        
        Assert.Equal(14, actual);
    }
    
    [Fact(DisplayName = "Solution", Skip = "Skip by default")]
    //[Fact(DisplayName = "Solution")]
    public void RiddleSolution()
    {
        var expected = 0;
        var dirtyDb = File.ReadAllLines("./Day05/PuzzleInput");
        var sut = new RiddleSolver(dirtyDb);
        var actual = sut.SolveDay5();

        Assert.Equal(expected, actual);
    }
}