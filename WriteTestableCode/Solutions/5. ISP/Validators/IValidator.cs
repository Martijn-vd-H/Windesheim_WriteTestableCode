namespace WriteTestableCode.Solutions._5._ISP.Validators;

public interface IValidator
{
    void ThrowOnValidationError(OrderParameters orderParameters);
}