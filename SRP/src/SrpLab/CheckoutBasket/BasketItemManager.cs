namespace SrpLab;

public class BasketItemManager
{
    private readonly List<CheckoutLine> _lines = new();

    public void AddLine(string sku, decimal price, int qty)
    {
        if (qty <= 0) throw new ArgumentOutOfRangeException(nameof(qty));
        _lines.Add(new CheckoutLine(sku, price, qty));
    }

    public IReadOnlyList<CheckoutLine> GetLines()
    {
        return _lines;
    }
}
