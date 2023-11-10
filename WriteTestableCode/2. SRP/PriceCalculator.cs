using WriteTestableCode.Shared;

namespace WriteTestableCode._2._SRP;

public class PriceCalculator
{
    public int Calculate(OrderParameters orderParameters)
    {
        var price = 0;
        switch (orderParameters.Type)
        {
            case HardwareType.Laptop:
                price = 1200 * orderParameters.Number;
                break;
            case HardwareType.Monitor:
                price = 250 * orderParameters.Number;
                break;
            case HardwareType.Desk:
                price = 550 * orderParameters.Number;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(orderParameters.Type), orderParameters.Type, null);
        }

        return price;
    }
}