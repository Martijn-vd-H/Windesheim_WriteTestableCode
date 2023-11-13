using WriteTestableCode.Shared;

namespace WriteTestableCode.Solutions._5._ISP;

public class PriceCalculator
{
    public int Calculate(OrderParameters orderParameters)
    {
        if (Constants.HardwareTypes.TryGetValue(orderParameters.Type, out var type))
        {
            return type * orderParameters.Number;
        }
        throw new ArgumentOutOfRangeException(nameof(orderParameters.Type), orderParameters.Type, "Type not implemented in pricing dictionary yet");
    }
}