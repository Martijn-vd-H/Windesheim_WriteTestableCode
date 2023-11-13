namespace WriteTestableCode.Solutions._5._ISP;

public interface IOutputService
{
    void WriteLine(string message);
    void SetSeverity(string severity);
    void SetColor(ConsoleColor color);
}