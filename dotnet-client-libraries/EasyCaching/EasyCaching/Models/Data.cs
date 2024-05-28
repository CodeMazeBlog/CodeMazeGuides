namespace EasyCaching.Models
{
    public static class Data
    {
        public static List<WinePrize> GetWinePrizes()
        {
            return new ()
            {
                new WinePrize {GrapeVariety= new List<string> { "Merlot", "Cabernet"} , Dress="Red", Name="Saint-Emilion", Prize="Gold" },
                new WinePrize {GrapeVariety= new List<string> { "Semillon", "Sauvignon blanc", "Muscadelle" } , Dress="White", Name="Monbazillac", Prize="Silver" },
                new WinePrize {GrapeVariety= new List<string> { "Melon de Bourgogne" } , Dress="White", Name="Muscadet", Prize="Bronze" },
                new WinePrize {GrapeVariety= new List<string> { "Chardonnay" } , Dress="White", Name="Chablis", Prize="Gold"                                                                      }
            };

        }
    }
}
