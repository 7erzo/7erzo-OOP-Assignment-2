namespace SrpLab;

public class PickListLine
{
    public string Sku { get; }
    public string Aisle { get; }
    public int Bin { get; }
    public int QtyNeeded { get; }
    public int QtyOnHand { get; }

    public PickListLine(string sku, string aisle, int bin, int qtyNeeded, int qtyOnHand)
    {
        Sku = sku;
        Aisle = aisle;
        Bin = bin;
        QtyNeeded = qtyNeeded;
        QtyOnHand = qtyOnHand;
    }
}
