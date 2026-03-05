namespace ClinuxSupportToolkit.Core;

public class LogAnalyzer
{
    public IEnumerable<LogEntry> Filter(IEnumerable<LogEntry> entries, string? level, string? text)
    {
        var query = entries;

        if (!string.IsNullOrEmpty(level))
            query = query.Where(e => e.Level.Equals(level, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrEmpty(text))
            query = query.Where(e => e.Message.Contains(text, StringComparison.OrdinalIgnoreCase));

        return query;
    }

    public string ToCsv(IEnumerable<LogEntry> entries)
    {
        var lines = new List<string> { "timestamp,level,message" };

        foreach (var e in entries)
        {
            lines.Add($"{e.Timestamp},{e.Level},{e.Message}");
        }

        return string.Join(Environment.NewLine, lines);
    }
}