using WriteTestableCode.Shared;
using WriteTestableCode.Shared.Libraries;

namespace WriteTestableCode.Solutions._2._SRP;

public class OrderService
{
    public void PlaceOrder(HardwareType type, int number)
    {
        var apiCaller = new APICaller();
        var result = apiCaller.PlaceOrder(type, number);
        if (!result)
        {
            throw new Exception("Order failed");
        }
    }
}