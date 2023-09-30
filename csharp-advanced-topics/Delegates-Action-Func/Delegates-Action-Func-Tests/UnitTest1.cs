using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using WebUtilities;

namespace Delegates_Action_Func_Tests;

public class GenericDelegateTest
{
    
     public record class Laptop(int ID, string Name, string processor, int ram, string Description, double Price);

    [Fact]
    public void GivenString_WhenPostToActionDelegate_ThenAvailableInAssignedMethod()
    {
            var result = string.Empty;
            Action<string> del = (message) => {result = message; };
            del("Welcome");
            Assert.Equal("Welcome",result);
    }

    [Fact]
    public void GivenString_WhenPostToFuncDelegate_ThenReturnContentLength()
    {
            Func<string,int> del = (content) => {return content.Length;};
            Assert.Equal(del("Hello"),5);
    }
    
    [Fact]
    public void GivenCustomRulesProvided_WhenAssignedToFuncDelegate_ThenFuncDelegateExucteRuels()
    {
        Func<Laptop,string> selector = CustomCategorizeLaptops;
        List<Laptop> stocks = GetLaptopStocks();
           
        IEnumerable<string> categorizedStocks = stocks.Select(selector);

        Assert.Contains("Gaming",categorizedStocks.ToArray()[3]);
        Assert.Contains("Professional",categorizedStocks.ToArray()[2]);
        Assert.Contains("student",categorizedStocks.ToArray()[1]);
        Assert.Contains("student",categorizedStocks.ToArray()[0]);
          
    }

    [Fact]
    public void GivenValidURLExpression_WhenPosted_ThenExecuteOnSucceedCallBackActiondDelegate()
    {
       DownloadFileAsync("","Testfilename",(Pass)=>{
                 Assert.Equal(Pass, "Sucess");
            }, (Fail)=>{
                 Assert.Equal(Fail, "Failed");
            } );
    }

     [Fact]
    public void GivenEmptyURLExpression_WhenPosted_ThenExecuteOnFailedCallBackActiondDelegate()
    {
       DownloadFileAsync("","Testfilename",(Pass)=>{
                 Assert.Equal(Pass, "Sucess");
            }, (Fail)=>{
                 Assert.Equal(Fail, "Failed");
            } );
   
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
     static string CustomCategorizeLaptops(Laptop item)
     {
        if(item.processor == "i9")
            return $"Gaming Laptop - {item.Name} - {item.Description} - ${item.Price}";
        else if(item.processor == "i7")
            return $"Professional Laptop - {item.Name} - {item.Description} - ${item.Price}";
        else
            return $"student Laptop - {item.Name} - {item.Description} - ${item.Price}";
    }
    private  async void DownloadFileAsync(string url, string FileName, 
                    Action<string> onSucceed, Action<string> onFailed)  
    {
        if(string.IsNullOrEmpty(url))
            onFailed("Failed");
                else
            onSucceed("Sucess");
    }

}

