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

    public static long CountDistinct(this List<IngredientRange> ranges)
    {
        var mergedRanges = MergeRanges(ranges);
        return mergedRanges.Sum(range => (range.EndId - range.StartId + 1));
    }

    private static List<IngredientRange> MergeRanges(List<IngredientRange> ranges)
    {
        // Sort ranges by start ID
        var sortedRanges = ranges
            .OrderBy(r => r.StartId)
            .ToList();

        var mergedRanges = new List<IngredientRange>();
        
        // Select first IngredientRange
        var currentStart = sortedRanges[0].StartId;
        var currentEnd = sortedRanges[0].EndId;
        
        // Iterate over Ranges (skip first)
        for (var index = 1; index < sortedRanges.Count; index++)
        {
            var range = sortedRanges[index];

            //if overlapping or adjacent, merge
            if (range.StartId <= currentEnd + 1)
            {
                currentEnd = Math.Max(currentEnd, range.EndId);
            }
            //else add range to list and start new range
            else
            {
                mergedRanges.Add(new IngredientRange($"{currentStart}-{currentEnd}"));
                currentStart = range.StartId;
                currentEnd = range.EndId;
            }
        }

        // Add last range to list
        mergedRanges.Add(new IngredientRange($"{currentStart}-{currentEnd}"));
        return mergedRanges;
    }
}