using WriteTestableCode.Libraries;

namespace WriteTestableCode._4._LSP;

public class EmailComposer
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