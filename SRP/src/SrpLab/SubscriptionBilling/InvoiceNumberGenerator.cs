namespace SrpLab;

public class InvoiceNumberGenerator
{
    private static int _invoiceSeq = 1000;

    public string Generate(DateOnly periodStart)
    {
        var number = ++_invoiceSeq;
        return $"INV-{periodStart:yyyyMM}-{number:D5}";
    }
}
