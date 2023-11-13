using WriteTestableCode.Shared;
using WriteTestableCode.Shared.Libraries;

namespace WriteTestableCode.Solutions._2._SRP;

public class EmailComposer
{
    public Email ComposeEmail(string address, int price, HardwareType type, int number)
    {
        var orderDetails = $"{number} of {type}";
        var invoiceDetails = $"Customer email: {address}\nDetails: {orderDetails}\nPrice: {price}";
        return new Email
        {
            To = address,
            From = "Ordermodule@example.com",
            Header = $"Invoice {type}",
            Body = invoiceDetails,
        };
    }
}