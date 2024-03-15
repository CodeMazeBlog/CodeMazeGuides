using Microsoft.AspNetCore.Mvc.RazorPages;
using RedisCachingInCSharp.Data;
using RedisCachingInCSharp.Model;
using RedisCachingInCSharp.Services;

namespace RedisCachingInCSharp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly GamesService _gamesService;
        private readonly RedisCacheService _cache;

        public Game[]? Games { get; set; }
        public bool IsFromCache { get; set; } = false;

        public IndexModel(GamesService gamesService, RedisCacheService cache)
        {
            _gamesService = gamesService;
            _cache = cache;
        }

        public void OnPostListGames()
        {
            var instanceId = GetInstanceId();
            var cacheKey = $"Games_Cache_{instanceId}";

            Games = _cache.GetCachedData<Game[]>(cacheKey);

            if (Games == null)
            {
                Games = _gamesService.LoadGames();
                _cache.SetCachedData(cacheKey, Games, TimeSpan.FromSeconds(60));
                IsFromCache = false;
            }
            else
            {
                IsFromCache = true;
            }
        }

        public void OnPostRemoveCache()
        {
            var instanceId = GetInstanceId();
            var cacheKey = $"Games_Cache_{instanceId}";

            _cache.RemoveCachedData(cacheKey);

            OnPostListGames();
        }

        private string GetInstanceId()
        {
            var instanceId = HttpContext.Session.GetString("InstanceId");

            if (string.IsNullOrEmpty(instanceId))
            {
                instanceId = Guid.NewGuid().ToString();
                HttpContext.Session.SetString("InstanceId", instanceId);
            }

            return instanceId;
        }
    }
}