using FluentAssertions;
using WriteTestableCode._2._SRP;
using WriteTestableCode.Libraries;
using WriteTestableCode.Shared;

namespace WriteTestableCode.Test;

public class OrderModule2Tests
{
    [Test]
    [TestCase(HardwareType.Laptop, 3, 3600)]
    [TestCase(HardwareType.Desk, 4, 2200)]
    [TestCase(HardwareType.Monitor, 2000, 500000)]
    public void Calculate_Should_CalculateTotalPrice(HardwareType type, int number, int expectedPrice)
    {
        // Arrange
        var priceCalculator = new PriceCalculator();
        
        // Act
        var price = priceCalculator.Calculate(type, number);

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
        
        // Act/Assert
        Assert.Throws<ArgumentException>(() => validator.ThrowOnValidationFailed(type, number));
    }
    
    [Test]
    [TestCase(HardwareType.Desk, 1)]
    [TestCase(HardwareType.Laptop, 20)]
    [TestCase(HardwareType.Monitor, 30)]
    public void Validator_Should_PassOnValidInput(HardwareType type, int number)
    {
        // Arrange
        var validator = new OrderValidator();

        // Act
        validator.ThrowOnValidationFailed(type, number);
        
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

        // Act
        var email = composer.ComposeEmail(address, price, type, number);
        
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