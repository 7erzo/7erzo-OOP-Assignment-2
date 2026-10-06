namespace SrpLab;

public class BedAssignment
{
    private readonly Dictionary<int, string> _bedPatient = new();

    public void AssignBed(int bed, string patientId)
    {
        if (bed <= 0)
            throw new ArgumentOutOfRangeException(nameof(bed));

        if (string.IsNullOrWhiteSpace(patientId))
            throw new ArgumentException("patient required");

        _bedPatient[bed] = patientId.Trim().ToUpperInvariant();
    }
}