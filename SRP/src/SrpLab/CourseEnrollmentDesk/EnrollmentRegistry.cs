namespace SrpLab;

public class EnrollmentRegistry
{
    private readonly List<string> _seated = new();
    private readonly List<string> _waitlist = new();

    public int SeatedCount => _seated.Count;
    public int WaitlistCount => _waitlist.Count;

    public bool IsSeated(string email)
    {
        return ContainsIgnoreCase(_seated, email);
    }

    public bool IsWaitlisted(string email)
    {
        return ContainsIgnoreCase(_waitlist, email);
    }

    public void Seat(string email)
    {
        _seated.Add(email);
    }

    public void AddToWaitlist(string email)
    {
        _waitlist.Add(email);
    }

    public int WaitlistPosition(string email)
    {
        for (var i = 0; i < _waitlist.Count; i++)
        {
            if (string.Equals(_waitlist[i], email, StringComparison.OrdinalIgnoreCase))
                return i + 1;
        }
        return -1;
    }

    public string RemoveFirstWaitlisted()
    {
        var email = _waitlist[0];
        _waitlist.RemoveAt(0);
        return email;
    }

    private bool ContainsIgnoreCase(List<string> values, string value)
    {
        foreach (var item in values)
        {
            if (string.Equals(item, value, StringComparison.OrdinalIgnoreCase)) return true;
        }
        return false;
    }
}
