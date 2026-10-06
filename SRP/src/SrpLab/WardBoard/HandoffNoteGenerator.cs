namespace SrpLab;

public class HandoffNoteGenerator
{
    public string BuildHandoffNote(int bed, string patientId, int acuityScore)
    {
        string tone;
        if (acuityScore >= 8)
        {
            tone = "ESCALATE";
        }
        else if (acuityScore >= 4)
        {
            tone = "WATCH";
        }
        else
        {
            tone = "STABLE";
        }
        return $"[HANDOFF {DateTime.UtcNow:yyyy-MM-dd}] Bed {bed} · {patientId} · acuity={acuityScore} · {tone}";

    }
}