namespace WriteTestableCode.Solutions._5._DIP;

public interface IOrderValidator
{
    void ThrowOnValidationFailed(OrderParameters orderParameters);
}