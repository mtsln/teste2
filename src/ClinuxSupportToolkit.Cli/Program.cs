using ClinuxSupportToolkit.Core;

static void PrintHelp()
{
    Console.WriteLine("""
ClinuxSupportToolkit - analisador simples de logs

Uso:
  --file <arquivo> [--level ERROR|WARN|INFO] [--contains "texto"] [--csv arquivo.csv]

Exemplo:
  --file sample.log --level ERROR
""");
}

static string? GetArg(string[] args, string name)
{
    var index = Array.FindIndex(args, a => a.Equals(name, StringComparison.OrdinalIgnoreCase));
    if (index < 0 || index + 1 >= args.Length)
        return null;

    return args[index + 1];
}

var file = GetArg(args, "--file");

if (string.IsNullOrWhiteSpace(file) || !File.Exists(file))
{
    PrintHelp();
    return;
}

var level = GetArg(args, "--level");
var contains = GetArg(args, "--contains");
var csv = GetArg(args, "--csv");

var parser = new LogParser();
var analyzer = new LogAnalyzer();

var entries = parser.ParseLines(File.ReadLines(file)).ToList();
var filtered = analyzer.Filter(entries, level, contains).ToList();

Console.WriteLine($"Total de linhas: {entries.Count}");
Console.WriteLine($"Após filtro: {filtered.Count}");

foreach (var e in filtered.Take(10))
{
    Console.WriteLine($"{e.Timestamp} [{e.Level}] {e.Message}");
}

if (!string.IsNullOrWhiteSpace(csv))
{
    File.WriteAllText(csv, analyzer.ToCsv(filtered));
    Console.WriteLine($"CSV gerado em {csv}");
}