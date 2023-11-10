using WriteTestableCode.Libraries;

namespace WriteTestableCode._4._LSP;

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