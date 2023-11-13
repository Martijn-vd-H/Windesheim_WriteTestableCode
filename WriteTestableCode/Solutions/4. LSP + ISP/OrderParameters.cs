using WriteTestableCode.Shared;

namespace WriteTestableCode.Solutions._4._LSP___ISP;

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