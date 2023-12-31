﻿using WriteTestableCode.Solutions._3._OCP.Validators;

namespace WriteTestableCode.Solutions._3._OCP;

public class OrderValidator
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