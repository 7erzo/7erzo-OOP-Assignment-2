namespace SrpLab;

public sealed class KitchenTicket
{
    private readonly KitchenItemManager _itemManager = new();
    private readonly AllergenDetector _allergenDetector = new();
    private readonly PreparationTimeEstimator _timeEstimator;
    private readonly ThermalTicketRenderer _renderer;
    private readonly ExpoLaneClassifier _laneClassifier;

    public KitchenTicket()
    {
        _timeEstimator = new PreparationTimeEstimator(_allergenDetector);
        _renderer = new ThermalTicketRenderer(_allergenDetector, _timeEstimator);
        _laneClassifier = new ExpoLaneClassifier(_allergenDetector, _timeEstimator);
    }

    public void AddItem(string item, IEnumerable<string> ingredients, int prepMinutes)
    {
        _itemManager.AddItem(item, ingredients, prepMinutes);
    }

    public IReadOnlyList<string> DetectAllergens()
    {
        return _allergenDetector.Detect(_itemManager.GetItems());
    }

    public int EstimatedReadyMinutes(int openStations)
    {
        return _timeEstimator.Estimate(_itemManager.GetItems(), openStations);
    }

    public string RenderThermalTicket(int orderNumber)
    {
        return _renderer.Render(_itemManager.GetItems(), orderNumber);
    }

    public string ExpoLaneHint()
    {
        return _laneClassifier.GetHint(_itemManager.GetItems());
    }
}
