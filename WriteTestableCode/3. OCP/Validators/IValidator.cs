namespace WriteTestableCode._3._OCP.Validators;

public interface IValidator
{
    void ThrowOnValidationError(OrderParameters orderParameters);
}