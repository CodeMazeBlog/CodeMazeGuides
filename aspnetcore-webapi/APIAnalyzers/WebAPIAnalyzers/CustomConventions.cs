using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace WebAPIAnalyzers
{
    public static class CustomConventions
    {
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Prefix)]
        public static void Get(
        [ApiConventionNameMatch(ApiConventionNameMatchBehavior.Suffix)]
        [ApiConventionTypeMatch(ApiConventionTypeMatchBehavior.AssignableFrom)]
        int id)
        { }
    }
}