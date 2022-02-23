using Castle.DynamicProxy;

using Core.CrossCuttingConcerns.Caching;
using Core.IOC;
using Core.Utility.Interceptors;

using System.Collections.Generic;
using System.Linq;

namespace Core.Aspect.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;

        public CacheAspect(int duration)
        {
            _duration = duration;
            _cacheManager = ServiceTool.Resolve<ICacheManager>();
        }

        private ICacheManager _cacheManager;
        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = GetFieldsofClass(invocation.Arguments);
            var key = $"{methodName}({arguments})";
            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration); 
        }
        private string GetFieldsofClass(params object[] entity)
        {
            List<string> result = new List<string>();
            foreach (var item in entity)
            {
                result.Add(
                    string.Join(",", item.GetType().GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                          .Where(x => x?.GetValue(item) != null)
                          .Select(x => x?.GetValue(item)).ToList()));
            }
            return string.Join(",", result);
        }
    }
}
