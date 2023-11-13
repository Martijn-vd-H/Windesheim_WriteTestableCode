using WriteTestableCode.Shared;
using WriteTestableCode.Shared.Libraries;

namespace WriteTestableCode.Solutions._5._ISP;

public class OrderModule5
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

        var outputService = _outputService;
      
        // TODO ISP and LSP violation. Add to earlier stages so we can fix it in 4. and 5.
        if (_outputService is ConsoleOutputService)
        {
            outputService.SetColor(ConsoleColor.Green);
        }
        else
        {
            outputService.SetSeverity("Information");
        }
        
        outputService.WriteLine("Order processed");

    }
}