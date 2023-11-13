using WriteTestableCode.Shared;

namespace WriteTestableCode.Solutions._2._SRP;

public class PriceCalculator
{
    public int Calculate(HardwareType type, int number)
    {
        var price = 0;
        switch (type)
        {
            case HardwareType.Laptop:
                price = 1200 * number;
                break;
            case HardwareType.Monitor:
                price = 250 * number;
                break;
            case HardwareType.Desk:
                price = 550 * number;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }

        return price;
    }
}