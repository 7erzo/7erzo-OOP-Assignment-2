namespace PatternsLab.Problems.Builder;

public static class RegistrationCallSites
{
    public static CourseRegistration CreateLiveStudent()
    {
        return new CourseRegistration.Builder()
            .WithStudentEmail("sara@mail.com")
            .ForCourse("SEF-101")
            .AsLiveGroup("G1")
            .WithDiscount("EARLY10")
            .EnableWhatsApp()
            .EnableEmailWelcome()
            .WithMentorNote("Needs evening slot")
            .WithPreferredStart(new DateOnly(2026, 10, 1))
            .Build();
    }

    public static CourseRegistration CreateVideosOnlyStudent()
    {
        return new CourseRegistration.Builder()
            .WithStudentEmail("ali@mail.com")
            .ForCourse("SEF-101")
            .AsVideosOnly()
            .EnableEmailWelcome()
            .Build();
    }
}