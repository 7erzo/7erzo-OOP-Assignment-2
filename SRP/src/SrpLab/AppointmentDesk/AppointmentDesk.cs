namespace SrpLab;

public sealed class AppointmentDesk
{
    private readonly BusinessHoursPolicy _businessHoursPolicy = new();
    private readonly AppointmentScheduler _scheduler;
    private readonly IcsCalendarGenerator _icsGenerator = new();
    private readonly SmsReminderGenerator _smsGenerator = new();

    public TimeOnly Open { get; }
    public TimeOnly Close { get; }
    public int SlotMinutes { get; }

    public AppointmentDesk(TimeOnly open, TimeOnly close, int slotMinutes)
    {
        Open = open;
        Close = close;
        SlotMinutes = slotMinutes;
        _scheduler = new AppointmentScheduler(_businessHoursPolicy);
    }

    public bool IsWithinBusinessHours(DateTimeOffset when)
    {
        return _businessHoursPolicy.IsWithinBusinessHours(when, Open, Close, SlotMinutes);
    }

    public DateTimeOffset? FindNextSlot(DateTimeOffset from, int searchHours)
    {
        return _scheduler.FindNextSlot(from, searchHours, Open, Close, SlotMinutes);
    }

    public bool TryBook(DateTimeOffset slot)
    {
        return _scheduler.TryBook(slot, Open, Close, SlotMinutes);
    }

    public string ToIcs(DateTimeOffset slot, string patientName, string clinician)
    {
        return _icsGenerator.Generate(slot, SlotMinutes, patientName, clinician);
    }

    public string SmsReminder(DateTimeOffset slot, string clinicPhone)
    {
        return _smsGenerator.Generate(slot, clinicPhone);
    }
}
