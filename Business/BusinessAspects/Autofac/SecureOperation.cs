using Business.Constants;

using Castle.DynamicProxy;

using Core.IOC;
using Core.Utility.Exceptions;
using Core.Utility.Interceptors;

using Microsoft.AspNetCore.Http;

using System;
using System.Linq;

namespace Business.BusinessAspects.Autofac
{
    public class SecureOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;
        public SecureOperation(string roles)
        {
            _roles = roles.Split(",");
            _httpContextAccessor = ServiceTool.Resolve<IHttpContextAccessor>();
        }
        protected override void OnBefor(IInvocation invocation)
        {
            if (!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                throw new AuthException(Messages.AuthenticationDenied, Messages.AuthenticationDeniedId);

            var roleClaim = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in roleClaim)
            {
                if (_roles.Contains(role))
                    return;
            }
            throw new AuthException(Messages.AuthorizeationDenied, Messages.AuthorizeationDeniedId);

        }

    }
}
