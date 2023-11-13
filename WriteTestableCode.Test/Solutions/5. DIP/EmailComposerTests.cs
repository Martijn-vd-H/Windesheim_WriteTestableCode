using FluentAssertions;
using WriteTestableCode.Shared;
using WriteTestableCode.Shared.Libraries;
using WriteTestableCode.Solutions._5._DIP;

namespace WriteTestableCode.Test.Solutions._5._OCP;

public class EmailComposerTests
{
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
}