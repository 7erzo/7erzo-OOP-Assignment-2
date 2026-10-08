namespace PatternsLab.Problems.Builder;

public sealed class CourseRegistration
{
    public string StudentEmail { get; }
    public string CourseCode { get; }
    public string AccessMode { get; }
    public string? GroupCode { get; }
    public string? DiscountCode { get; }
    public bool SendWhatsApp { get; }
    public bool SendEmailWelcome { get; }
    public string? MentorNote { get; }
    public DateOnly? PreferredStart { get; }

    private CourseRegistration(
        string studentEmail,
        string courseCode,
        string accessMode,
        string? groupCode,
        string? discountCode,
        bool sendWhatsApp,
        bool sendEmailWelcome,
        string? mentorNote,
        DateOnly? preferredStart)
    {
        StudentEmail = studentEmail;
        CourseCode = courseCode;
        AccessMode = accessMode;
        GroupCode = groupCode;
        DiscountCode = discountCode;
        SendWhatsApp = sendWhatsApp;
        SendEmailWelcome = sendEmailWelcome;
        MentorNote = mentorNote;
        PreferredStart = preferredStart;
    }

    public override string ToString()
        => $"{StudentEmail} → {CourseCode} [{AccessMode}] " +
           $"group={GroupCode ?? "-"} " +
           $"discount={DiscountCode ?? "-"} " +
           $"wa={SendWhatsApp} " +
           $"mail={SendEmailWelcome}";

    public sealed class Builder
    {
        private string? _studentEmail;
        private string? _courseCode;
        private string? _accessMode;
        private string? _groupCode;
        private string? _discountCode;
        private bool _sendWhatsApp;
        private bool _sendEmailWelcome;
        private string? _mentorNote;
        private DateOnly? _preferredStart;

        public Builder WithStudentEmail(string studentEmail)
        {
            _studentEmail = studentEmail;
            return this;
        }

        public Builder ForCourse(string courseCode)
        {
            _courseCode = courseCode;
            return this;
        }

        public Builder AsLiveGroup(string groupCode)
        {
            _accessMode = "LiveGroup";
            _groupCode = groupCode;
            return this;
        }

        public Builder AsVideosOnly()
        {
            _accessMode = "VideosOnly";
            _groupCode = null;
            return this;
        }

        public Builder WithDiscount(string discountCode)
        {
            _discountCode = discountCode;
            return this;
        }

        public Builder EnableWhatsApp()
        {
            _sendWhatsApp = true;
            return this;
        }

        public Builder EnableEmailWelcome()
        {
            _sendEmailWelcome = true;
            return this;
        }

        public Builder WithMentorNote(string mentorNote)
        {
            _mentorNote = mentorNote;
            return this;
        }

        public Builder WithPreferredStart(DateOnly preferredStart)
        {
            _preferredStart = preferredStart;
            return this;
        }

        public CourseRegistration Build()
        {
            if (string.IsNullOrWhiteSpace(_studentEmail))
                throw new ArgumentException("Student email is required.");

            if (string.IsNullOrWhiteSpace(_courseCode))
                throw new ArgumentException("Course code is required.");

            if (string.IsNullOrWhiteSpace(_accessMode))
                throw new InvalidOperationException(
                    "Access mode must be LiveGroup or VideosOnly.");

            if (_accessMode == "LiveGroup" &&
                string.IsNullOrWhiteSpace(_groupCode))
            {
                throw new InvalidOperationException(
                    "LiveGroup requires GroupCode.");
            }

            if (_accessMode == "VideosOnly" &&
                !string.IsNullOrWhiteSpace(_groupCode))
            {
                throw new InvalidOperationException(
                    "VideosOnly cannot have GroupCode.");
            }

            return new CourseRegistration(
                _studentEmail,
                _courseCode,
                _accessMode,
                _groupCode,
                _discountCode,
                _sendWhatsApp,
                _sendEmailWelcome,
                _mentorNote,
                _preferredStart);
        }
    }
}