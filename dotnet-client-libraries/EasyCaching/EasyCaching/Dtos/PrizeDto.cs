using EasyCaching.Models;

namespace EasyCaching.Dtos
{
    public class PrizeDto
    {
        public List<WinePrize> Prizes { get; set; } = new();
        public int Year { get; set; }
    }
}
