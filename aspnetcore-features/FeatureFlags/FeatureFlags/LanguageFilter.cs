using Microsoft.FeatureManagement;

namespace FeatureFlags;

[FilterAlias(nameof(LanguageFilter))]
public class LanguageFilter : IFeatureFilter
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LanguageFilter(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
    {
        var userLanguage = _httpContextAccessor.HttpContext.Request.Headers["Accept-Language"].ToString();
        var settings = context.Parameters.Get<LanguageFilterSettings>();
        return Task.FromResult(settings.AllowedLanguages.Any(a => userLanguage.Contains(a)));
    }
}
