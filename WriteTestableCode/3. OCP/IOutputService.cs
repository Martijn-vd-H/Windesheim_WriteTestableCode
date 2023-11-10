namespace WriteTestableCode._3._OCP;

public interface IOutputService
{
    void WriteLine(string message);
    void SetSeverity(string severity);
    void SetColor(ConsoleColor color);
}