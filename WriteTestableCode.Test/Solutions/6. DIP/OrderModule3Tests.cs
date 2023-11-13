using FluentAssertions;
using NSubstitute;
using WriteTestableCode.Shared;
using WriteTestableCode.Shared.Libraries;
using WriteTestableCode.Solutions._6._DIP;

namespace WriteTestableCode.Test.Solutions._6._OCP;

public class OrderModule6Tests
{
    [Test]
    [TestCase(HardwareType.Laptop, 3, 3600)]
    [TestCase(HardwareType.Desk, 4, 2200)]
    [TestCase(HardwareType.Monitor, 2000, 500000)]
    public void Calculate_Should_CalculateTotalPrice(HardwareType type, int number, int expectedPrice)
    {
        // Arrange
        var priceCalculator = new PriceCalculator();
        var orderParameters = new OrderParameters(type, number);
        
        // Act
        var price = priceCalculator.Calculate(orderParameters);

        // Assert
        Assert.That(price, Is.EqualTo(expectedPrice));
    } 
    
    [Test]
    [TestCase(HardwareType.Desk, -5)]
    [TestCase(HardwareType.Laptop, 0)]
    [TestCase(HardwareType.Monitor, 31)]
    public void Validator_Should_ThrowExceptionOnInvalidValues(HardwareType type, int number)
    {
        // Arrange
        var validator = new OrderValidator();
        var orderParameters = new OrderParameters(type, number);
        
        // Act/Assert
        Assert.Throws<ArgumentException>(() => validator.ThrowOnValidationFailed(orderParameters));
    }
    
    [Test]
    [TestCase(HardwareType.Desk, 1)]
    [TestCase(HardwareType.Laptop, 20)]
    [TestCase(HardwareType.Monitor, 30)]
    public void Validator_Should_PassOnValidInput(HardwareType type, int number)
    {
        // Arrange
        var validator = new OrderValidator();
        var orderParameters = new OrderParameters(type, number);

        // Act
        validator.ThrowOnValidationFailed(orderParameters);
        
        // Assert
        Assert.Pass();
    }

    [Test]
    public void Compose_Should_ReturnPopulatedEmailObject()
    {
        // Arrange
        var composer = new EmailComposer();
        var address = "test@example.com";
        var type = HardwareType.Desk;
        var price = 300;
        var number = 2;
        var orderParameters = new OrderParameters(type, number);

        // Act
        var email = composer.ComposeEmail(address, price, orderParameters);
        
        // Arrange
        var expectedEmail = new Email
        {
            To = address,
            Body = "Customer email: test@example.com\nDetails: 2 of Desk\nPrice: 300",
            From = "Ordermodule@example.com",
            Header = "Invoice Desk"
        };
        expectedEmail.Should().BeEquivalentTo(email);
    }

    [Test]
    public void Order_Should_SendInvoice()
    {
        // Arrange
        var emailSenderMock = Substitute.For<IEmailer>();
        var orderModule = new OrderModule6(emailSenderMock, Substitute.For<IEmailComposer>(), Substitute.For<PriceCalculator>());
        
        // Act
        orderModule.Order(HardwareType.Desk, 5);
        
        // Assert
        emailSenderMock.Received(1).SendEmail(Arg.Any<Email>());
    }

    [Test]
    public void Order_Should_ComposeEmailWithCorrectParameters()
    {
        // Arrange
        var emailComposerMock = Substitute.For<IEmailComposer>();
        var orderModule = new OrderModule6(Substitute.For<IEmailer>(), emailComposerMock, Substitute.For<PriceCalculator>());
        
        // Act
        orderModule.Order(HardwareType.Laptop, 5);

        // Assert
        emailComposerMock.Received().ComposeEmail("itbusiness@example.com", 6000, Arg.Any<OrderParameters>());
    }

    [Test]
    public void Order_Should_CallPriceCalculator()
    {
        // Arrange
        var pricingCalculatorMock = Substitute.For<IPriceCalculator>();
        var orderModule = new OrderModule6(Substitute.For<IEmailer>(), Substitute.For<IEmailComposer>(), pricingCalculatorMock);
        
        // Act
        orderModule.Order(HardwareType.Monitor, 1);

        // Assert
        pricingCalculatorMock.Received(1).Calculate(Arg.Is<OrderParameters>(o => o.Number == 1 && o.Type == HardwareType.Monitor));
    }
}