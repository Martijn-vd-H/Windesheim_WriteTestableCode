namespace WriteTestableCode._3._OCP;

public interface IValidator
{
    void ThrowOnValidationError(OrderParameters orderParameters);
}