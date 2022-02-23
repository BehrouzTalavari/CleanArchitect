using Castle.DynamicProxy;

using Core.Utility.Interceptors;

using System;
using System.Transactions;

namespace Core.Aspect.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            using TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, TimeSpan.FromMinutes(10));
            try
            {
                invocation.Proceed();
                transactionScope.Complete();
            }
            catch (Exception e)
            {
                transactionScope.Dispose();
                throw;
            }
        }
    }
}
