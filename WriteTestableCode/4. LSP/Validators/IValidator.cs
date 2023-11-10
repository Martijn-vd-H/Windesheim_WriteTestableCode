namespace WriteTestableCode._4._LSP.Validators;

public interface IValidator
{
    void ThrowOnValidationError(OrderParameters orderParameters);
}