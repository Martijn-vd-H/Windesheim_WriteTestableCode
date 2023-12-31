﻿using WriteTestableCode.Solutions._5._DIP.Validators;

namespace WriteTestableCode.Solutions._5._DIP;

public class OrderValidator : IOrderValidator
{
    public void ThrowOnValidationFailed(OrderParameters orderParameters)
    {
        foreach (var validator in GetValidators()) {
            validator.ThrowOnValidationError(orderParameters);
        }
    }

    private IEnumerable<IValidator> GetValidators()
    {
        return System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
            .Where(mytype => mytype.GetInterfaces().Contains(typeof(IValidator)))
            .Select(t => (IValidator)Activator.CreateInstance(t));
    }
}