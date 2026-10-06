namespace SrpLab;

public class GiftMessageCardGenerator
{
    public string Generate(IReadOnlyList<CheckoutLine> lines, string fromName, decimal grandTotal)
    {
        var items = "";
        for (var i = 0; i < lines.Count; i++)
        {
            if (i > 0) items += ", ";
            items += lines[i].Sku;
        }

        return $"Dear friend,\nA gift from {fromName} awaits ({items}).\nTotal surprise value: {grandTotal:C}\n";
    }
}
