using WriteTestableCode._1._Start;
using WriteTestableCode.SingleResponsibility;

namespace WriteTestableCode.Test;

[TestFixture]
public class OrderModule1Tests
{
    [Test]
    public void Order_Should_ThrowExceptionOnValidationFailed()
    {
        // Arrange
        var orderModule = new OrderModule1();
        
        // If validation passes, an order wil be placed and an email will be sent... a bit risky
        // Act/Assert
        Assert.Throws<ArgumentException>(() => orderModule.Order(HardwareType.Laptop, 0));
    } 
    
    [Test]
    public void Order_Should_CalculateTotalPrice()
    {
        // Arrange
        var orderModule = new OrderModule1();
        // How do I prevent actual orders being placed or emails sent?
        
        // Act
        orderModule.Order(HardwareType.Laptop, 3);
        
        // Assert
        // How do I get the price?
    } 
}