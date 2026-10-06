namespace SrpLab;

public sealed class GradeBook
{
    private readonly GradeRecordStore _recordStore = new();
    private readonly GradeCalculator _gradeCalculator = new();
    private readonly GradePolicy _gradePolicy = new();
    private readonly TranscriptGenerator _transcriptGenerator = new();
    private readonly GradeCsvExporter _csvExporter = new();

    public void Record(string studentId, decimal score)
    {
        if (score is < 0 or > 100) throw new ArgumentOutOfRangeException(nameof(score));
        _recordStore.Record(studentId, score);
    }

    public decimal Average(string studentId)
    {
        return _gradeCalculator.Average(_recordStore.GetScores(studentId));
    }

    public string Letter(string studentId)
    {
        return _gradePolicy.Letter(Average(studentId));
    }

    public bool MeetsHonorRoll(string studentId)
    {
        var average = Average(studentId);
        return _gradePolicy.MeetsHonorRoll(average, Letter(studentId));
    }

    public string TranscriptPlain(string studentId, string fullName)
    {
        var average = Average(studentId);
        var letter = Letter(studentId);
        var honor = _gradePolicy.MeetsHonorRoll(average, letter);
        return _transcriptGenerator.Generate(studentId, fullName, average, letter, honor);
    }

    public string ExportCsv()
    {
        return _csvExporter.Export(_recordStore.GetStudentIds(), this);
    }
}
