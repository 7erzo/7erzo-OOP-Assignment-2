namespace SrpLab;

public sealed class WarehousePickList
{
    private readonly PickListItemManager _itemManager = new();
    private readonly StockAllocator _stockAllocator = new();
    private readonly WalkingOrderCalculator _walkingOrderCalculator = new();
    private readonly PickerInstructionGenerator _pickerInstructionGenerator;
    private readonly WmsXmlExporter _wmsExporter;

    public WarehousePickList()
    {
        _pickerInstructionGenerator = new PickerInstructionGenerator(_walkingOrderCalculator, _stockAllocator);
        _wmsExporter = new WmsXmlExporter(_stockAllocator);
    }

    public void AddNeed(string sku, string aisle, int bin, int qtyNeeded, int qtyOnHand)
    {
        _itemManager.AddNeed(sku, aisle, bin, qtyNeeded, qtyOnHand);
    }

    public IReadOnlyList<(string Sku, int Allocated)> Allocate()
    {
        return _stockAllocator.Allocate(_itemManager.GetLines());
    }

    public IReadOnlyList<(string Aisle, int Bin, string Sku, int Qty)> WalkingOrder()
    {
        return _walkingOrderCalculator.Calculate(_itemManager.GetLines());
    }

    public string PickerScript()
    {
        return _pickerInstructionGenerator.Generate(_itemManager.GetLines());
    }

    public string WmsXmlBatch(string batchId)
    {
        return _wmsExporter.Export(_itemManager.GetLines(), batchId);
    }
}
