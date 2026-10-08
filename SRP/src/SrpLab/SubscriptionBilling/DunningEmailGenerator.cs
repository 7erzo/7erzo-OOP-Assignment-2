namespace SrpLab;

public class DunningEmailGenerator
{
    public string Generate(string customerName, decimal amount, string invoice, int failedPayments, DateOnly asOf)
    {
        var severity = "final notice before suspension";
        if (failedPayments <= 1) severity = "friendly reminder";
        else if (failedPayments == 2) severity = "second notice";

        return $"Subject: {severity} {invoice}\nHi {customerName},\nBalance {amount:C} as of {asOf:o} ({failedPayments} failures).\n";
    }
}
