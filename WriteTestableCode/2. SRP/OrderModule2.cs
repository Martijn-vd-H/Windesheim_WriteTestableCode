using WriteTestableCode.Libraries;
using WriteTestableCode.Shared;

namespace WriteTestableCode._2._SRP;

public class OrderModule2
{
    public void Order(HardwareType type, int number)
    {
        // Validation
        var validator = new OrderValidator();
        validator.ThrowOnValidationFailed(type, number);
        
        // Order hardware with api
        var orderService = new OrderService();
        orderService.PlaceOrder(type, number);

        // Calculate price
        var priceCalculator = new PriceCalculator();
        var price = priceCalculator.Calculate(type, number);

        // Compose and send email
        var emailComposer = new EmailComposer();
        var email = emailComposer.ComposeEmail("itbusiness@example.com", price, type, number);
       
        Emailer.SendEmail(email);

        var outputService = new OutputService();
        outputService.WriteLine("Order processed");
    }
}