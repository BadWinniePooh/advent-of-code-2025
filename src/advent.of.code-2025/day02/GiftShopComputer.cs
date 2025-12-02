namespace advent.of.code_2025.day02;

public class GiftShopComputer
{
    public int SumInvalidIds(string unformattedIds)
    {
        var idPairs = IdPair.ConvertFrom(unformattedIds.Split(','));
        return idPairs.Sum(idPair => idPair.Verify());
    }
}