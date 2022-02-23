using Castle.DynamicProxy;

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
        protected virtual void OnException(IInvocation invocation) 
        { 
        }
        protected virtual void OnSuccess(IInvocation invocation) 
        { 
        }
        public override void Intercept(IInvocation invocation) 
        { 
        }
    }
}
