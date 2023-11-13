using WriteTestableCode.Shared;
using WriteTestableCode.Solutions._5._DIP;

namespace WriteTestableCode.Test.Solutions._5._OCP;

public class OrderValidatorTests
{
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
}