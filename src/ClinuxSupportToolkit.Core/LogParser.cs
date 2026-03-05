using System.Text.RegularExpressions;

namespace ClinuxSupportToolkit.Core;

public class LogParser
{
    private static readonly Regex Pattern =
        new(@"^(?<date>\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}) \[(?<level>\w+)\] (?<msg>.*)");

    public IEnumerable<LogEntry> ParseLines(IEnumerable<string> lines)
    {
        foreach (var line in lines)
        {
            var match = Pattern.Match(line);

            if (!match.Success)
            {
                yield return new LogEntry(null, "UNKNOWN", line, line);
                continue;
            }

            DateTime.TryParse(match.Groups["date"].Value, out var dt);

            yield return new LogEntry(
                dt,
                match.Groups["level"].Value,
                match.Groups["msg"].Value,
                line
            );
        }
    }
}