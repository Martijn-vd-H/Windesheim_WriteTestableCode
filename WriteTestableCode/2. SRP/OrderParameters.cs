using WriteTestableCode.SingleResponsibility;

namespace WriteTestableCode._2._SRP;

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