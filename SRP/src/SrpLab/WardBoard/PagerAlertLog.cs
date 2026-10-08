namespace SrpLab;

public class PagerAlertLog
{
	private readonly List<string> _pagerLog = new();

	public void AddAlert(string message)
	{
		_pagerLog.Add(message);
	}
	public IReadOnlyList<string> DrainPagerLog()
	{
		var copy = _pagerLog.ToList();
		_pagerLog.Clear();
		return copy;
	}
}