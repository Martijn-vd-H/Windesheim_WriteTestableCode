namespace WriteTestableCode.Shared.Libraries;

public class APICaller
{
    public bool PlaceOrder(HardwareType type, int number)
    {
        Console.WriteLine($"Ordering {number} of type {type}...");
        return true;
    }
}