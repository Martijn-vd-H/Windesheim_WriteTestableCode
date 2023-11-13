namespace WriteTestableCode.Solutions._6._DIP;

public interface IOutputService
{
    void WriteLine(string message);
    void SetSeverity(string severity);
    void SetColor(ConsoleColor color);
}