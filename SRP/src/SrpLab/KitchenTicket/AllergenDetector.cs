namespace SrpLab;

public class AllergenDetector
{
    public IReadOnlyList<string> Detect(IReadOnlyList<KitchenItem> items)
    {
        var hits = new List<string>();

        foreach (var item in items)
        {
            foreach (var ingredient in item.Ingredients)
            {
                if ((ingredient.Contains("milk") || ingredient.Contains("cheese") || ingredient.Contains("butter")) && !ContainsIgnoreCase(hits, "dairy"))
                    hits.Add("dairy");
                if ((ingredient.Contains("wheat") || ingredient.Contains("flour") || ingredient.Contains("bread")) && !ContainsIgnoreCase(hits, "gluten"))
                    hits.Add("gluten");
                if ((ingredient.Contains("peanut") || ingredient.Contains("almond") || ingredient.Contains("cashew")) && !ContainsIgnoreCase(hits, "nuts"))
                    hits.Add("nuts");
                if ((ingredient.Contains("shrimp") || ingredient.Contains("prawn") || ingredient.Contains("crab")) && !ContainsIgnoreCase(hits, "shellfish"))
                    hits.Add("shellfish");
            }
        }

        hits.Sort(StringComparer.OrdinalIgnoreCase);
        return hits;
    }

    private bool ContainsIgnoreCase(List<string> values, string value)
    {
        foreach (var item in values)
            if (string.Equals(item, value, StringComparison.OrdinalIgnoreCase)) return true;
        return false;
    }
}
