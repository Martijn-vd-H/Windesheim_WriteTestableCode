namespace WriteTestableCode.Solutions._3._OCP;

public interface IOutputService
{
    void WriteLine(string message);
    void SetColor(ConsoleColor color);
    void SetSeverity(string severity);
}