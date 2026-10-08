namespace SrpLab;

public class WmsXmlExporter
{
    private readonly StockAllocator _stockAllocator;

    public WmsXmlExporter(StockAllocator stockAllocator)
    {
        _stockAllocator = stockAllocator;
    }

    public string Export(IReadOnlyList<PickListLine> lines, string batchId)
    {
        var allocations = _stockAllocator.Allocate(lines);
        var parts = "";
        foreach (var allocation in allocations)
            parts += $"<line sku=\"{allocation.Sku}\" qty=\"{allocation.Allocated}\" />";

        return $"<batch id=\"{batchId}\">{parts}</batch>";
    }
}
