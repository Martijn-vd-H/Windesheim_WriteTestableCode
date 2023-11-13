using WriteTestableCode.Solutions._4._LSP___ISP;

namespace WriteTestableCode.Solutions._5._DIP;

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