using Microsoft.AspNetCore.Authorization;

namespace APIGateway.Auth;

public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        var user = context.User;

        if (user == null || !user.HasClaim(c => c.Type == "permissions"))
        {
            return Task.CompletedTask;
        }

        var permissions = user.Claims
                              .Where(c => c.Type == "permissions")
                              .Select(c => c.Value)
                              .ToList();

        if (permissions.Contains(requirement.Permission))
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
