namespace SrpLab;

public class AppointmentScheduler
{
    private readonly List<DateTimeOffset> _booked = new();
    private readonly BusinessHoursPolicy _businessHoursPolicy;

    public AppointmentScheduler(BusinessHoursPolicy businessHoursPolicy)
    {
        _businessHoursPolicy = businessHoursPolicy;
    }

    public DateTimeOffset? FindNextSlot(DateTimeOffset from, int searchHours, TimeOnly open, TimeOnly close, int slotMinutes)
    {
        var cursor = Align(from, slotMinutes);
        var end = from.AddHours(searchHours);

        while (cursor < end)
        {
            if (_businessHoursPolicy.IsWithinBusinessHours(cursor, open, close, slotMinutes) && !IsBooked(cursor))
                return cursor;
            cursor = cursor.AddMinutes(slotMinutes);
        }

        return null;
    }

    public bool TryBook(DateTimeOffset slot, TimeOnly open, TimeOnly close, int slotMinutes)
    {
        if (!_businessHoursPolicy.IsWithinBusinessHours(slot, open, close, slotMinutes) || IsBooked(slot)) return false;
        _booked.Add(slot);
        return true;
    }

    private bool IsBooked(DateTimeOffset slot)
    {
        foreach (var booked in _booked)
            if (booked == slot) return true;
        return false;
    }

    private DateTimeOffset Align(DateTimeOffset from, int slotMinutes)
    {
        var minutes = from.Minute - (from.Minute % slotMinutes);
        return new DateTimeOffset(from.Year, from.Month, from.Day, from.Hour, minutes, 0, from.Offset);
    }
}
