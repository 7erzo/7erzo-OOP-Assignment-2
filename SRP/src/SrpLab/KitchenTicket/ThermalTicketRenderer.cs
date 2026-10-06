namespace SrpLab;

public class ThermalTicketRenderer
{
    private readonly AllergenDetector _allergenDetector;
    private readonly PreparationTimeEstimator _timeEstimator;

    public ThermalTicketRenderer(AllergenDetector allergenDetector, PreparationTimeEstimator timeEstimator)
    {
        _allergenDetector = allergenDetector;
        _timeEstimator = timeEstimator;
    }

    public string Render(IReadOnlyList<KitchenItem> items, int orderNumber)
    {
        var width = 32;
        var line = new string('=', width);
        var body = "";

        for (var i = 0; i < items.Count; i++)
        {
            if (i > 0) body += "\n";
            body += $"* {items[i].Item.ToUpperInvariant()} ({items[i].PrepMinutes}m)";
        }

        var allergens = _allergenDetector.Detect(items);
        var allergyLine = allergens.Count == 0
            ? "ALLERGENS: none"
            : "ALLERGENS: " + string.Join(",", allergens);

        return $"{line}\nORDER #{orderNumber}\nETA {_timeEstimator.Estimate(items, 2)} MIN\n{body}\n{allergyLine}\n{line}\n";
    }
}
