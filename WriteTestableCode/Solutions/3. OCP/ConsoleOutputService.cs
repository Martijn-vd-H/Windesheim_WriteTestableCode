namespace WriteTestableCode.Solutions._3._OCP;

public class ConsoleOutputService : IOutputService
{
    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }

    public void SetSeverity(string severity)
    {
        // Severity not relevant
    }

    public void SetColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
    }
}