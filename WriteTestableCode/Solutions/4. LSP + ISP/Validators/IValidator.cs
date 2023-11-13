namespace WriteTestableCode.Solutions._4._LSP___ISP.Validators;

public interface IValidator
{
    void ThrowOnValidationError(OrderParameters orderParameters);
}