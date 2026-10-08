namespace SrpLab;

public class TuitionInvoiceFormatter
{
    private readonly EnrollmentRegistry _registry;

    public TuitionInvoiceFormatter(EnrollmentRegistry registry)
    {
        _registry = registry;
    }

    public string Format(string courseCode, string studentEmail, decimal tuition)
    {
        if (!_registry.IsSeated(studentEmail)) return $"{courseCode},WAITLIST,0.00";

        var vat = Math.Round(tuition * 0.14m, 2);
        return $"{courseCode},TUITION,{tuition:0.00},VAT,{vat:0.00},TOTAL,{(tuition + vat):0.00}";
    }
}
