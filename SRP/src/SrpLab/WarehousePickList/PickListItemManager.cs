namespace SrpLab;

public class PickListItemManager
{
    private readonly List<PickListLine> _lines = new();

    public void AddNeed(string sku, string aisle, int bin, int qtyNeeded, int qtyOnHand)
    {
        _lines.Add(new PickListLine(sku, aisle, bin, qtyNeeded, qtyOnHand));
    }

    public IReadOnlyList<PickListLine> GetLines()
    {
        return _lines;
    }
}
