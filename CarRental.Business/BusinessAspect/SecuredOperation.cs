using CarRental.Business.Constants;
using CarRental.Core.Extensions;
using CarRental.Core.Utilities.Interceptors;
using CarRental.Core.Utilities.IoC;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.BusinessAspect
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor; 

        public SecuredOperation(string roles) 
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)   
            {
                if (roleClaims.Contains(role)) 
                {
                    return;
                }
            }
            throw new Exception(Messages.Authorization.AuthorizationDenied());
        }
    }
}
