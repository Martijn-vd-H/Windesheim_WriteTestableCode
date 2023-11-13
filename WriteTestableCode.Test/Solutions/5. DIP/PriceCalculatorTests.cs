using WriteTestableCode.Shared;
using WriteTestableCode.Solutions._5._DIP;

namespace WriteTestableCode.Test.Solutions._5._OCP;

public class PriceCalculatorTests
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
}