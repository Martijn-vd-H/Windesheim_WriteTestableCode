namespace WriteTestableCode.SingleResponsibility;

public class OrderModule1
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
        var result = apiCaller.PlaceOrder(type, number);
        if (!result)
        {
            throw new Exception("Order failed");
        }

        // Calculate price
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
        
        // Compose and send email
        var address = "itbusiness@example.com";
        var orderDetails = $"{number} of {type}";
        var invoiceDetails = $"Customer email: {address}\nDetails: {orderDetails}\nPrice: {price}";
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