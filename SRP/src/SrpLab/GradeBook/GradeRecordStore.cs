namespace SrpLab;

public class GradeRecordStore
{
    private readonly Dictionary<string, List<decimal>> _scores = new(StringComparer.OrdinalIgnoreCase);

    public void Record(string studentId, decimal score)
    {
        if (!_scores.TryGetValue(studentId, out var list))
        {
            list = new List<decimal>();
            _scores[studentId] = list;
        }
        list.Add(score);
    }

    public IReadOnlyList<decimal> GetScores(string studentId)
    {
        if (_scores.TryGetValue(studentId, out var list)) return list;
        return new List<decimal>();
    }

    public IReadOnlyList<string> GetStudentIds()
    {
        var ids = new List<string>();
        foreach (var id in _scores.Keys) ids.Add(id);
        ids.Sort(StringComparer.Ordinal);
        return ids;
    }
}
