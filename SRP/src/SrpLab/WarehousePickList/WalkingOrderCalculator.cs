namespace SrpLab;

public class WalkingOrderCalculator
{
    public IReadOnlyList<(string Aisle, int Bin, string Sku, int Qty)> Calculate(IReadOnlyList<PickListLine> lines)
    {
        var result = new List<(string Aisle, int Bin, string Sku, int Qty)>();
        foreach (var line in lines)
        {
            var qty = Math.Min(line.QtyNeeded, line.QtyOnHand);
            if (qty > 0) result.Add((line.Aisle, line.Bin, line.Sku, qty));
        }

        for (var i = 0; i < result.Count - 1; i++)
        {
            for (var j = i + 1; j < result.Count; j++)
            {
                var first = result[i];
                var second = result[j];
                var after = string.CompareOrdinal(first.Aisle, second.Aisle) > 0 ||
                             (string.Equals(first.Aisle, second.Aisle, StringComparison.Ordinal) && first.Bin > second.Bin);
                if (after)
                {
                    result[i] = second;
                    result[j] = first;
                }
            }
        }

        return result;
    }
}
