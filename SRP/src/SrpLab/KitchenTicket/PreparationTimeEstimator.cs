namespace SrpLab;

public class PreparationTimeEstimator
{
    private readonly AllergenDetector _allergenDetector;

    public PreparationTimeEstimator(AllergenDetector allergenDetector)
    {
        _allergenDetector = allergenDetector;
    }

    public int Estimate(IReadOnlyList<KitchenItem> items, int openStations)
    {
        if (openStations <= 0) openStations = 1;

        var sequential = 0;
        var longest = 0;
        foreach (var item in items)
        {
            sequential += item.PrepMinutes;
            if (item.PrepMinutes > longest) longest = item.PrepMinutes;
        }

        var parallel = (int)Math.Ceiling(sequential / (double)openStations);
        if (_allergenDetector.Detect(items).Count > 0) parallel += 3;

        return Math.Max(parallel, longest);
    }
}
