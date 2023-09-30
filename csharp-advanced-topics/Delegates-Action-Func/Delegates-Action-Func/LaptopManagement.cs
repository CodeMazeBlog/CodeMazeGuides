
 public record class Laptop(int ID, string Name, string processor, int ram, string Description, double Price);

 public class LaptopOrganizer {
    public IEnumerable<string> GetUserCategorizedLaptop( Func<Laptop, string>  LaptopCategorySelector)
    {
        List<Laptop> stocks = GetLaptopStocks();
            
        IEnumerable<string> categorizedStocks = stocks.Select(LaptopCategorySelector);
    
        return categorizedStocks;
    }

    public List<Laptop>  GetLaptopStocks()
    {
            List<Laptop> laptops = new List<Laptop>();
            laptops.Add( new Laptop(1,"Dell Laptop", "i3", 16, "14 Laptop, Intel Core i5-1135G7 Processor/ 16GB / 512GB SSD / 14.0", 450.00));
            laptops.Add( new Laptop(2,"Acer Nitro", "i3", 16,"12th Gen Intel Core i5 Gaming Laptop with 39.62 cm (15.6)",550.00));
            laptops.Add( new Laptop(3,"HP Chromebook", "i7", 32,"X360 Intel Celeron N4020 14 inch(35.6 cm) Micro-Edge, Touchscreen, 2-in-1 Laptop ",650.00));
            laptops.Add( new Laptop(4,"Acer Swift 5 ", "i9", 64,"SF514-55TA Intel EVO Thin and Light Laptop 14(35cm) Full HD IPS Touch Display 11th Gen Intel Core i9-1135G7 Processor 8GB",750.00 ));

            return laptops;
    }

    public IEnumerable<string> GetCategorizedLaptop()
    {
         List<Laptop> stocks = GetLaptopStocks();

         List<string> categorizedStocks = new List<string>();
         foreach (var item in stocks)
         {
             if(item.Price <= 600)
                categorizedStocks.Add( $"Student Laptop - {item.Name} - {item.Description} - ${item.Price}");
              else
                categorizedStocks.Add( $"Professional Laptop - {item.Name} - {item.Description} - ${item.Price}");
         }
         return categorizedStocks;
    }

 
 }