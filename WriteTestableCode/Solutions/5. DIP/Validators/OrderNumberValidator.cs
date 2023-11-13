namespace WriteTestableCode.Solutions._5._DIP.Validators;

public class OrderNumberValidator : IValidator
{
    public void ThrowOnValidationError(OrderParameters orderParameters)
    {
        if (orderParameters.Number < 1 || orderParameters.Number > 30)
        {
            throw new ArgumentException($"Order {orderParameters.Number} of type {orderParameters.Type} seems incorrect");
        }
    }
}