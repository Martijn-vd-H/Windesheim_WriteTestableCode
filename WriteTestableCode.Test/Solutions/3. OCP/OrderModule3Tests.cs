using FluentAssertions;
using WriteTestableCode.Shared;
using WriteTestableCode.Shared.Libraries;
using WriteTestableCode.Solutions._3._OCP;

namespace WriteTestableCode.Test.Solutions._3._OCP;

public class OrderModule3Tests
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
        //... Cannot intercept message
        // Same goes for the api calls
    }
}