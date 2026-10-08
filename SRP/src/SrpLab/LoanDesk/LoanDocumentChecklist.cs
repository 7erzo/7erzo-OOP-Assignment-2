namespace SrpLab;

public class LoanDocumentChecklist
{
    private readonly LoanRiskAssessor _riskAssessor = new();

    public IReadOnlyList<string> GetRequiredDocuments(decimal requestedAmount, int creditScore, int employmentMonths, bool hasCollateral)
    {
        var docs = new List<string>
        {
            "National ID",
            "Proof of income (3 months)"
        };

        if (requestedAmount > 40_000m) docs.Add("Bank statements (6 months)");
        if (hasCollateral) docs.Add("Collateral ownership deed");
        if (employmentMonths < 12) docs.Add("Employer letter");
        if (!_riskAssessor.IsEligible(requestedAmount, creditScore, employmentMonths, hasCollateral))
            docs.Add("Manual underwriter referral form");

        return docs;
    }
}
