namespace SrpLab;

public class SlaPolicy
{
    public DateTimeOffset CalculateDeadline(string priority, DateTimeOffset openedAt)
    {
        var hours = 72;
        if (priority == "P1") hours = 4;
        else if (priority == "P2") hours = 24;

        return openedAt.AddHours(hours);
    }

    public bool IsBreached(string priority, DateTimeOffset openedAt, DateTimeOffset now)
    {
        return now > CalculateDeadline(priority, openedAt);
    }
}
