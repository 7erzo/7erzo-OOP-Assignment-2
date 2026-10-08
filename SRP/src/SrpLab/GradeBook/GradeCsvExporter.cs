namespace SrpLab;

public class GradeCsvExporter
{
    public string Export(IReadOnlyList<string> studentIds, GradeBook gradeBook)
    {
        var rows = new List<string> { "studentId,average,letter,honor" };
        foreach (var id in studentIds)
            rows.Add($"{id},{gradeBook.Average(id)},{gradeBook.Letter(id)},{(gradeBook.MeetsHonorRoll(id) ? 1 : 0)}");
        return string.Join('\n', rows);
    }
}
