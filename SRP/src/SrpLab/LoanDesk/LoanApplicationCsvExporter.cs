namespace SrpLab;

public class LoanApplicationCsvExporter
{
    public string Export(string applicationId, int creditScore, int employmentMonths, bool hasCollateral, decimal riskScore, bool eligible)
    {
        return $"{applicationId},{creditScore},{employmentMonths},{(hasCollateral ? 1 : 0)},{riskScore:0.00},{(eligible ? "Y" : "N")}";
    }
}
