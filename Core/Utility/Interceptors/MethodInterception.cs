using Castle.DynamicProxy;

using System;

namespace Core.Utility.Interceptors
{
    public class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefor(IInvocation invocation)
        {
        }
        protected virtual void OnAfter(IInvocation invocation) 
        { 
        }
        protected virtual void OnException(IInvocation invocation,Exception e) 
        { 
        }
        protected virtual void OnSuccess(IInvocation invocation) 
        { 
        }
        public override void Intercept(IInvocation invocation) 
        {
            var isSuccess = true;
            OnBefor(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (System.Exception e)
            {
                isSuccess = false;
                OnException(invocation,e);
            }finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}
