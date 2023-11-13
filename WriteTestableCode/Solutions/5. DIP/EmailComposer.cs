using WriteTestableCode.Shared.Libraries;

namespace WriteTestableCode.Solutions._5._DIP;

public class EmailComposer : IEmailComposer
{
    public Email ComposeEmail(string address, int price, OrderParameters orderParameters)
    {
        var orderDetails = $"{orderParameters.Number} of {orderParameters.Type}";
        var invoiceDetails = $"Customer email: {address}\nDetails: {orderDetails}\nPrice: {price}";
        return new Email
        {
            To = address,
            From = "Ordermodule@example.com",
            Header = $"Invoice {orderParameters.Type}",
            Body = invoiceDetails,
        };
    }
}

public interface IEmailComposer
{
    Email ComposeEmail(string address, int price, OrderParameters orderParameters);
}