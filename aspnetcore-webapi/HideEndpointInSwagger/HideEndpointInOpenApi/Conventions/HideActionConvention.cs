using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace HideEndpointInOpenApi.Conventions;

public class HideActionConvention : IActionModelConvention
{
    public void Apply(ActionModel action)
    {
        if (action.ActionName == "GetMethodThree")
        {
            action.ApiExplorer.IsVisible = false;
        }
    }
}
