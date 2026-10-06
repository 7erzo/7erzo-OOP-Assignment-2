namespace SrpLab;

public class WelcomePacketGenerator
{
    private readonly EnrollmentRegistry _registry;

    public WelcomePacketGenerator(EnrollmentRegistry registry)
    {
        _registry = registry;
    }

    public string Generate(string courseCode, string studentEmail, string studentName)
    {
        var status = _registry.IsSeated(studentEmail)
            ? "confirmed seat"
            : $"waitlist #{_registry.WaitlistPosition(studentEmail)}";

        return $"# Welcome to {courseCode}\nHi {studentName},\nYour status: **{status}**.\n" +
               $"Bring a laptop. Discord onboarding link: https://example.invalid/{courseCode.ToLowerInvariant()}\n";
    }
}
