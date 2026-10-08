namespace SrpLab;

public class DecisionLetterGenerator
{
    public string Generate(string applicantName, decimal requestedAmount, decimal riskScore, bool eligible, IReadOnlyList<string> documents)
    {
        if (eligible)
        {
            return $"Dear {applicantName},\nYour request for {requestedAmount:C} is pre-approved (risk {riskScore:0}).\n" +
                   $"Please upload: {string.Join("; ", documents)}.\n";
        }

        return $"Dear {applicantName},\nWe are unable to approve {requestedAmount:C} at this time.\n" +
               $"Reference risk={riskScore:0}. You may reapply after improving documentation.\n";
    }
}
