namespace SrpLab;

public class ExpoLaneClassifier
{
    private readonly AllergenDetector _allergenDetector;
    private readonly PreparationTimeEstimator _timeEstimator;

    public ExpoLaneClassifier(AllergenDetector allergenDetector, PreparationTimeEstimator timeEstimator)
    {
        _allergenDetector = allergenDetector;
        _timeEstimator = timeEstimator;
    }

    public string GetHint(IReadOnlyList<KitchenItem> items)
    {
        if (_allergenDetector.Detect(items).Count > 0) return "LANE-ALLERGY";
        if (_timeEstimator.Estimate(items, 2) > 20) return "LANE-SLOW";
        return "LANE-FAST";
    }
}
