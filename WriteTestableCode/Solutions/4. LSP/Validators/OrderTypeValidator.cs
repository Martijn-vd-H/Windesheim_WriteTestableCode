using WriteTestableCode.Shared;

namespace WriteTestableCode.Solutions._4._LSP.Validators;

public class OrderTypeValidator : IValidator
{
    public void ThrowOnValidationError(OrderParameters orderParameters)
    {
        var allowedTypes = new List<HardwareType>
        {
            HardwareType.Desk,
            HardwareType.Monitor,
            HardwareType.Laptop,
        };
        if (!allowedTypes.Contains(orderParameters.Type))
        {
            throw new ArgumentException($"Hardware of type {orderParameters.Type} not allowed");
        }
    }
}