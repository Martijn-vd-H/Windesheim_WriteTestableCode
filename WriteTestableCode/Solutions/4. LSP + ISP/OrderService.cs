using WriteTestableCode.Shared.Libraries;

namespace WriteTestableCode.Solutions._4._LSP___ISP;

public class OrderService
{
    public void PlaceOrder(OrderParameters orderParameters)
    {
        var apiCaller = new APICaller();
        var result = apiCaller.PlaceOrder(orderParameters.Type, orderParameters.Number);
        if (!result)
        {
            throw new Exception("Order failed");
        }
    }
}