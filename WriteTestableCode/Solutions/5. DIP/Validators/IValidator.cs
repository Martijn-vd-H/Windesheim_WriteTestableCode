namespace WriteTestableCode.Solutions._5._DIP.Validators;

public interface IValidator
{
    void ThrowOnValidationError(OrderParameters orderParameters);
}