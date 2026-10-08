namespace SrpLab;

public class CouponDiscountCalculator
{
    public decimal Calculate(string? couponRaw, decimal subtotal)
    {
        if (string.IsNullOrWhiteSpace(couponRaw)) return 0m;

        var text = couponRaw.Trim().ToUpperInvariant();

        if (text.StartsWith("SAVE") && int.TryParse(text[4..], out var pct) && pct > 0 && pct <= 50)
            return Math.Round(subtotal * pct / 100m, 2);

        if (text.Contains("FREESHIP")) return 0m;
        if (text == "WELCOME10") return Math.Min(10m, subtotal);

        return 0m;
    }
}
