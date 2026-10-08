namespace SrpLab;

public class StockAllocator
{
    public IReadOnlyList<(string Sku, int Allocated)> Allocate(IReadOnlyList<PickListLine> lines)
    {
        var result = new List<(string Sku, int Allocated)>();
        foreach (var line in lines)
            result.Add((line.Sku, Math.Min(line.QtyNeeded, line.QtyOnHand)));
        return result;
    }
}
