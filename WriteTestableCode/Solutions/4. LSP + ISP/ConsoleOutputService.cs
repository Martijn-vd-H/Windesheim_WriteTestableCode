namespace WriteTestableCode.Solutions._4._LSP___ISP;

public class ConsoleOutputService : IOutputService, IHasColor
{
    public void WriteLine(string message)
    {
        Console.WriteLine(message);
    }

    public void SetInformationMode()
    {
        Console.ForegroundColor = ConsoleColor.Green;
    }
    
    public void SetColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
    }
}