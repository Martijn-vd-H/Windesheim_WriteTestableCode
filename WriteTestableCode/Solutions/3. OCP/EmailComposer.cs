﻿using WriteTestableCode.Shared.Libraries;

namespace WriteTestableCode.Solutions._3._OCP;

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