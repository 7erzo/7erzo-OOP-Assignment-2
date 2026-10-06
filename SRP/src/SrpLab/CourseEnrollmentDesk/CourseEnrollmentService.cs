namespace SrpLab;

public class CourseEnrollmentService
{
    private readonly EnrollmentRegistry _registry;

    public CourseEnrollmentService(EnrollmentRegistry registry)
    {
        _registry = registry;
    }

    public string Register(string studentEmail, int capacity)
    {
        if (string.IsNullOrWhiteSpace(studentEmail)) throw new ArgumentException("email");
        var email = studentEmail.Trim();

        if (_registry.IsSeated(email) || _registry.IsWaitlisted(email)) return "ALREADY_REGISTERED";

        if (_registry.SeatedCount < capacity)
        {
            _registry.Seat(email);
            return "SEATED";
        }

        _registry.AddToWaitlist(email);
        return $"WAITLIST:{_registry.WaitlistCount}";
    }

    public void PromoteFromWaitlist(int seats, int capacity)
    {
        while (seats > 0 && _registry.WaitlistCount > 0 && _registry.SeatedCount < capacity)
        {
            var next = _registry.RemoveFirstWaitlisted();
            _registry.Seat(next);
            seats--;
        }
    }

    public int WaitlistPosition(string studentEmail)
    {
        return _registry.WaitlistPosition(studentEmail);
    }
}
