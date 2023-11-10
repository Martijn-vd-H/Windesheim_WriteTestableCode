namespace WriteTestableCode._4._LSP;

public interface IOutputService
{
    void WriteLine(string message);
    void SetSeverity(string severity);
    void SetColor(ConsoleColor color);
}