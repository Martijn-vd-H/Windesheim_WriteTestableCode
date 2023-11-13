using WriteTestableCode.Shared;

namespace WriteTestableCode.Solutions._5._DIP;

public class OrderParameters
{
    public HardwareType Type { get; set; }
    public int Number { get; set; }
    
    public OrderParameters(HardwareType type, int number)
    {
        Type = type;
        Number = number;
    }
}