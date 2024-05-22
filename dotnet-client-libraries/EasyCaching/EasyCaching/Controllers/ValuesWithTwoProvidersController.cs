using EasyCaching.API;
using EasyCaching.Core;
using EasyCaching.Dtos;
using EasyCaching.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EasyCaching.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesWithTwoProvidersController(IEasyCachingProviderFactory _factory) : ControllerBase
    {
        private ApiResponse _response = new();

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetValues()
        {
            var inMemoryProvider = _factory.GetCachingProvider("InMemoryCache");
            var sqliteProvider = _factory.GetCachingProvider("SQLiteCache");
            var prizeDto = new PrizeDto();

            Stopwatch stopwatch = Stopwatch.StartNew();
            //In memory
            if (await inMemoryProvider.ExistsAsync("today"))
            {
                var cachedTodayDate = await inMemoryProvider.GetAsync<DateTime>("today");
                prizeDto.Year = (cachedTodayDate.Value).Year;
            }
            else
            {
                await Task.Delay(50);
                var today = DateTime.Now.Date;
                prizeDto.Year = today.Year;

                await inMemoryProvider.SetAsync("today", today, TimeSpan.FromMinutes(1));
            }

            //SQLite
            if (await sqliteProvider.ExistsAsync("prizes"))
            {
                var cachedPrizes = await sqliteProvider.GetAsync<List<WinePrize>>("prizes");
                prizeDto.Prizes = cachedPrizes.Value;
            }
            else
            {
                await Task.Delay(50);
                var prizes = Data.GetWinePrizes();
                prizeDto.Prizes = prizes;

                await sqliteProvider.SetAsync("prizes", prizes, TimeSpan.FromMinutes(1));
            }
            stopwatch.Stop();

            _response.Result = prizeDto;
            _response.Duration = stopwatch.ElapsedMilliseconds;
            _response.StatusCode = System.Net.HttpStatusCode.OK;

            return Ok(_response);
        }
    }
}
