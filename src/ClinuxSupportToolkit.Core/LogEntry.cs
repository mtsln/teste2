namespace ClinuxSupportToolkit.Core;

public record LogEntry(DateTime? Timestamp, string Level, string Message, string RawLine);