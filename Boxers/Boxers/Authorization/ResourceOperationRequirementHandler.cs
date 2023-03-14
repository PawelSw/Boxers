using Boxers.Entities;
using Microsoft.AspNetCore.Authorization;

namespace Boxers.Authorization
{
    public class ResourceOperationRequirementHandler : AuthorizationHandler<ResourceOperationRequirement, Boxer>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOperationRequirement requirement, Boxer boxer)
        {
            throw new NotImplementedException();
        }
    }
}
