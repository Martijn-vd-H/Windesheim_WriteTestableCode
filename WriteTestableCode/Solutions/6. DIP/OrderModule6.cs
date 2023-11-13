using WriteTestableCode.Shared;
using WriteTestableCode.Shared.Libraries;

namespace WriteTestableCode.Solutions._6._DIP;

public class OrderModule6
{
    private readonly IEmailer _emailer;
    private readonly IEmailComposer _emailComposer;
    private readonly IPriceCalculator _pricingCalculator;
    private IOutputService _outputService = new ConsoleOutputService();

    public OrderModule6(IEmailer emailer, IEmailComposer emailComposer, IPriceCalculator pricingCalculator)
    {
        _emailer = emailer;
        _emailComposer = emailComposer;
        _pricingCalculator = pricingCalculator;
    }
    
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
        var price = _pricingCalculator.Calculate(orderParameters);

        // Compose and send email
        var email = _emailComposer.ComposeEmail("itbusiness@example.com", price, orderParameters);
       
        _emailer.SendEmail(email);

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