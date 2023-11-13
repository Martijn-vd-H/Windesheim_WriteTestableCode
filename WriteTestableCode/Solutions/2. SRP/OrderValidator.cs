using WriteTestableCode.Shared;

namespace WriteTestableCode.Solutions._2._SRP;

public class OrderValidator
{
    public void ThrowOnValidationFailed(HardwareType type, int number)
    {
        if (number < 1 || number > 30)
        {
            throw new ArgumentException($"Order {number} of type {type} seems incorrect");
        }
    }
}