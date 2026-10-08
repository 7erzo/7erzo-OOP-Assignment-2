namespace SrpLab;

public class CheckoutLine
{
    public string Sku { get; }
    public decimal Price { get; }
    public int Qty { get; }

    public CheckoutLine(string sku, decimal price, int qty)
    {
        Sku = sku;
        Price = price;
        Qty = qty;
    }
}
