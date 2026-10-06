namespace SrpLab;

public class KitchenItemManager
{
    private readonly List<KitchenItem> _items = new();

    public void AddItem(string item, IEnumerable<string> ingredients, int prepMinutes)
    {
        _items.Add(new KitchenItem(item, ingredients, prepMinutes));
    }

    public IReadOnlyList<KitchenItem> GetItems()
    {
        return _items;
    }
}
