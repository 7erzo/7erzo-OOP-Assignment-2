namespace SrpLab;

public class KitchenItem
{
    public string Item { get; }
    public List<string> Ingredients { get; }
    public int PrepMinutes { get; }

    public KitchenItem(string item, IEnumerable<string> ingredients, int prepMinutes)
    {
        Item = item;
        Ingredients = new List<string>();
        foreach (var ingredient in ingredients)
            Ingredients.Add(ingredient.Trim().ToLowerInvariant());
        PrepMinutes = prepMinutes;
    }
}
