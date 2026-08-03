using Microsoft.AspNetCore.Mvc;

namespace APIKeyAuthentication.CustomAttribute
{
    public class ApiKeyAttribute : ServiceFilterAttribute
    {
        public ApiKeyAttribute()
            : base(typeof(ApiKeyAuthFilter))
        {
        }
    }
}