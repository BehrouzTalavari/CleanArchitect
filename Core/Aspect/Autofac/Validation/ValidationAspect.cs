using Castle.DynamicProxy;

using Core.CrossCuttingConcerns.Validation;
using Core.Messages;
using Core.Utility.Interceptors;

using FluentValidation;

using System;
using System.Linq;

namespace Core.Aspect.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;

        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception(CoreMassages.WrongValidationType);
            }
            _validatorType = validatorType;
        }
        protected override void OnBefor(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(x => x.GetType() == entityType);
            foreach (var item in entities)
            {
                ValidationTool.Validate(validator,item);
            }
        }

    }
}
