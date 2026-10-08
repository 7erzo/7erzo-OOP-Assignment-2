namespace SrpLab;

public class TranscriptGenerator
{
    public string Generate(string studentId, string fullName, decimal average, string letter, bool honor)
    {
        return $"TRANSCRIPT\nStudent: {fullName} ({studentId})\nAverage: {average}\nLetter: {letter}\nHonor: {honor}\n";
    }
}
