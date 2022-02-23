
using Microsoft.Extensions.DependencyInjection;

using System;

namespace Core.IOC
{
    public static class ServiceTool
    {
        private static IServiceProvider _serviceProvider { get; set; }
        public static IServiceCollection Create(IServiceCollection service)
        {
            _serviceProvider = service.BuildServiceProvider();
            return service;
        }
        public static T Resolve<T>() => _serviceProvider.GetService<T>();
    }
}
