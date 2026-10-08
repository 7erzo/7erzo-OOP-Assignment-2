namespace SrpLab;

public class GradeCalculator
{
    public decimal Average(IReadOnlyList<decimal> scores)
    {
        if (scores.Count == 0) return 0m;
        decimal total = 0m;
        foreach (var score in scores) total += score;
        return Math.Round(total / scores.Count, 2);
    }
}
