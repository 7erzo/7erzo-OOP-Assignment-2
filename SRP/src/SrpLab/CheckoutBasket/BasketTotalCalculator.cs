namespace SrpLab;

public class BasketTotalCalculator
{
    private readonly CouponDiscountCalculator _couponDiscountCalculator;

    public BasketTotalCalculator(CouponDiscountCalculator couponDiscountCalculator)
    {
        _couponDiscountCalculator = couponDiscountCalculator;
    }

    public decimal SubTotal(IReadOnlyList<CheckoutLine> lines)
    {
        decimal total = 0m;
        foreach (var line in lines)
            total += line.Price * line.Qty;
        return total;
    }

    public decimal DiscountAmount(IReadOnlyList<CheckoutLine> lines, string? couponRaw)
    {
        return _couponDiscountCalculator.Calculate(couponRaw, SubTotal(lines));
    }

    public decimal GrandTotal(IReadOnlyList<CheckoutLine> lines, string? couponRaw, bool giftWrap)
    {
        var subtotal = SubTotal(lines);
        var discount = _couponDiscountCalculator.Calculate(couponRaw, subtotal);
        var total = subtotal - discount;

        if (giftWrap) total += 4.99m;
        return Math.Max(0m, total);
    }
}
