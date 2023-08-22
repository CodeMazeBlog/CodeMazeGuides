using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace HideEndpointInSwagger.Conventions;

public class HideControllerConvention : IActionModelConvention
{
    public void Apply(ActionModel action)
    {
        if (action.ActionName == "GetMethodThree")
        {
            action.ApiExplorer.IsVisible = false;
        }
    }
}
