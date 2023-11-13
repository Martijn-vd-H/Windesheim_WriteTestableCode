using NSubstitute;
using WriteTestableCode.Shared;
using WriteTestableCode.Shared.Libraries;
using WriteTestableCode.Solutions._5._DIP;

namespace WriteTestableCode.Test.Solutions._5._OCP;

public class OrderModule5Tests
{
    private OrderModule5 _orderModule;
    private IEmailComposer _emailComposerMock = Substitute.For<IEmailComposer>();
    private IEmailer _emailSenderMock;
    private IPriceCalculator _pricingCalculator;
    private IOrderValidator _orderValidator;
    private IOrderService _orderService;

    [SetUp]
    public void SetUp()
    {
        _emailSenderMock = Substitute.For<IEmailer>();
        _emailComposerMock = Substitute.For<IEmailComposer>();
        _pricingCalculator = Substitute.For<IPriceCalculator>();
        _orderValidator = Substitute.For<IOrderValidator>();
        _orderService = Substitute.For<IOrderService>();
        _orderModule = new OrderModule5(_emailSenderMock, _emailComposerMock, _pricingCalculator, _orderValidator, _orderService);
    }

    [Test]
    public void Order_Should_SendInvoice()
    {
        // Act
        _orderModule.Order(HardwareType.Desk, 5);
        
        // Assert
        _emailSenderMock.Received(1).SendEmail(Arg.Any<Email>());
    }

    [Test]
    public void Order_Should_ComposeEmailWithCorrectParameters()
    {
        // Arrange
        _pricingCalculator.Calculate(Arg.Any<OrderParameters>()).Returns(6000);
        
        // Act
        _orderModule.Order(HardwareType.Laptop, 5);

        // Assert
        _emailComposerMock.Received().ComposeEmail("itbusiness@example.com", 6000, Arg.Any<OrderParameters>());
    }

    [Test]
    public void Order_Should_CallPriceCalculator()
    {
        // Act
        _orderModule.Order(HardwareType.Monitor, 1);

        // Assert
        _pricingCalculator.Received().Calculate(Arg.Is<OrderParameters>(o => o.Number == 1 && o.Type == HardwareType.Monitor));
    }
}