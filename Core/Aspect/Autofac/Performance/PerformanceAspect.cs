using Castle.DynamicProxy;

using Core.IOC;
using Core.Utility.Interceptors;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Core.Aspect.Autofac.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;
        private Stopwatch _stopwatch;

        public PerformanceAspect(int interval)
        {
            _interval = interval;
            _stopwatch = ServiceTool.Resolve<Stopwatch>();
        }

        protected override void OnBefor(IInvocation invocation)
        {
            _stopwatch.Start();
        }
        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                Debug.WriteLine($"Performance :{invocation.Method.DeclaringType.FullName} ==> {_stopwatch.Elapsed.TotalSeconds}");
            }
            _stopwatch.Restart();
        }
    }
}
