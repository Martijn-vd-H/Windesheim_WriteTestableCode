namespace WriteTestableCode.SingleResponsibility;

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