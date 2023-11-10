namespace WriteTestableCode._5._ISP.Validators;

public interface IValidator
{
    void ThrowOnValidationError(OrderParameters orderParameters);
}