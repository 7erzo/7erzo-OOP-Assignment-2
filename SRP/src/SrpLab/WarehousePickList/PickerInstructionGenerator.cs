namespace SrpLab;

public class PickerInstructionGenerator
{
    private readonly WalkingOrderCalculator _walkingOrderCalculator;
    private readonly StockAllocator _stockAllocator;

    public PickerInstructionGenerator(WalkingOrderCalculator walkingOrderCalculator, StockAllocator stockAllocator)
    {
        _walkingOrderCalculator = walkingOrderCalculator;
        _stockAllocator = stockAllocator;
    }

    public string Generate(IReadOnlyList<PickListLine> lines)
    {
        var order = _walkingOrderCalculator.Calculate(lines);
        var steps = "";

        for (var i = 0; i < order.Count; i++)
        {
            if (i > 0) steps += "\n";
            steps += $"{i + 1}. Go aisle {order[i].Aisle} bin {order[i].Bin}: pick {order[i].Qty} × {order[i].Sku}";
        }

        var allocations = _stockAllocator.Allocate(lines);
        var shortageText = "";
        foreach (var allocation in allocations)
        {
            for (var i = 0; i < lines.Count; i++)
            {
                if (lines[i].Sku == allocation.Sku)
                {
                    if (allocation.Allocated < lines[i].QtyNeeded)
                    {
                        if (shortageText.Length > 0) shortageText += ", ";
                        shortageText += allocation.Sku;
                    }
                    break;
                }
            }
        }

        var warn = shortageText.Length > 0 ? "SHORTAGES: " + shortageText : "SHORTAGES: none";
        return steps + "\n" + warn;
    }
}
