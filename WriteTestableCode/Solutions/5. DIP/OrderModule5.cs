using WriteTestableCode.Shared;

namespace WriteTestableCode.Solutions._5._DIP;

public class OrderModule5
{
    private readonly IEmailer _emailer;
    private readonly IEmailComposer _emailComposer;
    private readonly IPriceCalculator _pricingCalculator;
    private IOutputService _outputService = new ConsoleOutputService();

    public OrderModule5(IEmailer emailer, IEmailComposer emailComposer, IPriceCalculator pricingCalculator)
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

        // Output processing information
        _outputService.SetInformationMode();
        _outputService.WriteLine("Order processed");
    }
}