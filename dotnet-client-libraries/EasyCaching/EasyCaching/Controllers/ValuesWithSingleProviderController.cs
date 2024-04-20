using EasyCaching.API;
using EasyCaching.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EasyCaching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesWithSingleProviderController : ControllerBase
    {
        private readonly IEasyCachingProvider _provider;
        private ApiResponse _response;

        public ValuesWithSingleProviderController(IEasyCachingProvider provider)
        {
            _response = new ApiResponse();
            _provider = provider;
        }

        [HttpGet]
        public async Task<ApiResponse>  GetDate()
        {
            //Get
            if (await _provider.ExistsAsync("today"))
            {
                Stopwatch swCache = Stopwatch.StartNew();
                var cachedDate = await _provider.GetAsync<DateTime>("today");
                swCache.Stop();
                _response.Result = cachedDate.Value;
                _response.Duration = swCache.ElapsedMilliseconds;

                return _response;
            }
            
            Stopwatch sw = Stopwatch.StartNew();
            await Task.Delay(1500);
            var today = DateTime.Now.Date;
            sw.Stop();

            //Set
            await _provider.SetAsync("today", today, TimeSpan.FromMinutes(1));

            _response.Result = today;
            _response.Duration = sw.ElapsedMilliseconds;
            _response.StatusCode = System.Net.HttpStatusCode.OK;

            return _response;
        }
    }
}
