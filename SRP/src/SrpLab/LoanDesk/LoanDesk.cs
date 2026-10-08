namespace SrpLab;

public sealed class LoanDesk
{
    private readonly LoanRiskAssessor _riskAssessor = new();
    private readonly LoanDocumentChecklist _documentChecklist = new();
    private readonly DecisionLetterGenerator _decisionLetterGenerator = new();
    private readonly LoanApplicationCsvExporter _csvExporter = new();

    public decimal RequestedAmount { get; }
    public int CreditScore { get; }
    public int EmploymentMonths { get; }
    public bool HasCollateral { get; }

    public LoanDesk(decimal requestedAmount, int creditScore, int employmentMonths, bool hasCollateral)
    {
        RequestedAmount = requestedAmount;
        CreditScore = creditScore;
        EmploymentMonths = employmentMonths;
        HasCollateral = hasCollateral;
    }

    public decimal RiskScore()
    {
        return _riskAssessor.Calculate(RequestedAmount, CreditScore, EmploymentMonths, HasCollateral);
    }

    public bool IsEligible()
    {
        return _riskAssessor.IsEligible(RequestedAmount, CreditScore, EmploymentMonths, HasCollateral);
    }

    public IReadOnlyList<string> RequiredDocuments()
    {
        return _documentChecklist.GetRequiredDocuments(RequestedAmount, CreditScore, EmploymentMonths, HasCollateral);
    }

    public string DecisionLetter(string applicantName)
    {
        return _decisionLetterGenerator.Generate(applicantName, RequestedAmount, RiskScore(), IsEligible(), RequiredDocuments());
    }

    public string UnderwriterCsvRow(string applicationId)
    {
        return _csvExporter.Export(applicationId, CreditScore, EmploymentMonths, HasCollateral, RiskScore(), IsEligible());
    }
}
