using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace ResourceBasedAuthorization.AuthorizationRequirements;

public static class CrudOperationRequirements
{
    public static OperationAuthorizationRequirement CreateRequirement =
        new OperationAuthorizationRequirement() { Name = nameof(CreateRequirement) };

    public static OperationAuthorizationRequirement ReadRequirement =
        new OperationAuthorizationRequirement() { Name = nameof(ReadRequirement) };
    
    public static OperationAuthorizationRequirement UpdateRequirement =
        new OperationAuthorizationRequirement() { Name = nameof(UpdateRequirement) };

    public static OperationAuthorizationRequirement DeleteRequirement =
        new OperationAuthorizationRequirement() { Name = nameof(DeleteRequirement) };
}
