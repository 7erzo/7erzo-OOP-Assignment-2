namespace SrpLab;

public sealed class CourseEnrollmentDesk
{
    private readonly EnrollmentRegistry _registry = new();
    private readonly CourseEnrollmentService _enrollmentService;
    private readonly WelcomePacketGenerator _welcomePacketGenerator;
    private readonly TuitionInvoiceFormatter _invoiceFormatter;

    public int Capacity { get; }
    public decimal Tuition { get; }
    public string CourseCode { get; }

    public CourseEnrollmentDesk(string courseCode, int capacity, decimal tuition)
    {
        CourseCode = courseCode;
        Capacity = capacity;
        Tuition = tuition;
        _enrollmentService = new CourseEnrollmentService(_registry);
        _welcomePacketGenerator = new WelcomePacketGenerator(_registry);
        _invoiceFormatter = new TuitionInvoiceFormatter(_registry);
    }

    public string Register(string studentEmail)
    {
        return _enrollmentService.Register(studentEmail, Capacity);
    }

    public int WaitlistPosition(string studentEmail)
    {
        return _enrollmentService.WaitlistPosition(studentEmail);
    }

    public string WelcomePacketMarkdown(string studentEmail, string studentName)
    {
        return _welcomePacketGenerator.Generate(CourseCode, studentEmail, studentName);
    }

    public string TuitionInvoiceLine(string studentEmail)
    {
        return _invoiceFormatter.Format(CourseCode, studentEmail, Tuition);
    }

    public void PromoteFromWaitlist(int seats)
    {
        _enrollmentService.PromoteFromWaitlist(seats, Capacity);
    }
}
