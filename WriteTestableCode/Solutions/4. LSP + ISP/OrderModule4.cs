using WriteTestableCode.Shared;
using WriteTestableCode.Shared.Libraries;

namespace WriteTestableCode.Solutions._4._LSP___ISP;

public class OrderModule4
{
    private IOutputService _outputService = new ConsoleOutputService();
    
    public void SetOutputService(IOutputService outputService)
    {
        _outputService = outputService;
    }
    
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
        
        // Output processing information
        _outputService.SetInformationMode();
        _outputService.WriteLine("Order processed");
    }
}