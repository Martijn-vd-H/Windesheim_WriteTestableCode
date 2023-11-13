namespace WriteTestableCode.Solutions._6._DIP.Validators;

public interface IValidator
{
    void ThrowOnValidationError(OrderParameters orderParameters);
}