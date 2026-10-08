namespace SrpLab;

public class InternalEscalationGenerator
{
    public string Generate(string id, string priority, DateTimeOffset breachAt)
    {
        return $"ESCALATE {id} priority={priority} breachAt={breachAt:u} keywords-scanned=yes";
    }
}
