namespace SrpLab;

public sealed class CheckoutBasket
{
    private readonly BasketItemManager _itemManager = new();
    private readonly CouponDiscountCalculator _couponCalculator = new();
    private readonly BasketTotalCalculator _totalCalculator;
    private readonly GiftMessageCardGenerator _giftMessageGenerator = new();
    private readonly PaymentAuthorizer _paymentAuthorizer = new();
    private string? _couponRaw;
    private bool _giftWrap;

    public CheckoutBasket()
    {
        _totalCalculator = new BasketTotalCalculator(_couponCalculator);
    }

    public void AddLine(string sku, decimal price, int qty)
    {
        _itemManager.AddLine(sku, price, qty);
    }

    public void ApplyCouponText(string? couponText)
    {
        _couponRaw = couponText;
    }

    public void EnableGiftWrap()
    {
        _giftWrap = true;
    }

    public decimal SubTotal()
    {
        return _totalCalculator.SubTotal(_itemManager.GetLines());
    }

    public decimal DiscountAmount()
    {
        return _totalCalculator.DiscountAmount(_itemManager.GetLines(), _couponRaw);
    }

    public decimal GrandTotal()
    {
        return _totalCalculator.GrandTotal(_itemManager.GetLines(), _couponRaw, _giftWrap);
    }

    public string GiftMessageCard(string fromName)
    {
        return _giftMessageGenerator.Generate(_itemManager.GetLines(), fromName, GrandTotal());
    }

    public string AuthorizePaymentStub(string cardLast4)
    {
        return _paymentAuthorizer.Authorize(GrandTotal(), cardLast4, _itemManager.GetLines().Count);
    }
}
