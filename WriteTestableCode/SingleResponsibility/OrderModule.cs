namespace WriteTestableCode.SingleResponsibility;

public class OrderModule
{
    public void Order(HardwareType type, int number)
    {
        // Validation
        if (number < 0 || number > 30)
        {
            throw new ArgumentException($"Order {number} of type {type} seems incorrect");
        }
        
        // Order hardware with api
        var apiCaller = new APICaller();
        ApiResult result;
        switch (type)
        {
            case HardwareType.Laptop:
                result = apiCaller.OrderLaptops(number);
                break;
            case HardwareType.Monitor:
                result = apiCaller.OrderMonitors(number);
                break;
            case HardwareType.Desk:
                result = apiCaller.OrderDesks(number);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }

        
        if (!result.HasSucceeded)
        {
            throw new Exception("Order failed");
        }
        
        // Compose and send email
        var address = "itbusiness@example.com";
        var orderDetails = $"{number} of {type}";
        var invoiceDetails = $"Customer email: {address}\nDetails: {orderDetails}\nPrice: {result.Price}";
        var email = new Email()
        {
            To = address,
            From = "Ordermodule@example.com",
            Header = $"Invoice {type}",
            Body = invoiceDetails,
        };
        Emailer.SendEmail(email);
        
        Console.WriteLine("Order processed");
    }
}