using System;
using System.Threading.Tasks;
using H2S04.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace H2S04.Authorization
{
    public class ProductAdministratorAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement,H2S04.Models.Product>
    {
        public ProductAdministratorAuthorizationHandler()
        {
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, Product resource)
        {
            if(context.User == null)
            {
                return Task.CompletedTask;
            }

            if (context.User.IsInRole(Constants.ProductAdministratorsRole))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;

        }
    }
}
