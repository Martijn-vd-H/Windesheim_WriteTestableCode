using WriteTestableCode.Libraries;
using WriteTestableCode.Shared;

namespace WriteTestableCode._3._OCP;

public class OrderModule3
{
    public void Order(HardwareType type, int number)
    {
        var orderParameters = new OrderParameters(type, number);
            
        // Validation
        var validator = new OrderValidator();
        validator.ThrowOnValidationFailed(orderParameters);
        
        // Order hardware with api
        var orderService = new OrderService();
        orderService.PlaceOrder(orderParameters);

        // Calculate price
        var priceCalculator = new PriceCalculator();
        var price = priceCalculator.Calculate(orderParameters);

        // Compose and send email
        var emailComposer = new EmailComposer();
        var email = emailComposer.ComposeEmail("itbusiness@example.com", price, orderParameters);
       
        Emailer.SendEmail(email);

        var outputService = new OutputService();
        outputService.WriteLine("Order processed");
    }
}