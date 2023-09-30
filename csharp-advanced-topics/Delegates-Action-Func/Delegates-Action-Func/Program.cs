
using WebUtilities;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace Action_Fun_Delegates // Note: actual namespace depends on the project name.
{
    internal class Program
    {
       
        static void Main(string[] args)
        {  
            System.Console.WriteLine("Simple Action delegates example !... \n");
            ShortActionExample();
            System.Console.WriteLine("Simple Func delegate example !... \n");
            ShortFuncExample();
            System.Console.WriteLine("Practical Action  example !... \n");
            PracticalActionDelegateExample();
             System.Console.WriteLine("Practical Func example !... \n");
            PracticalFuncDelegateExample();
            Console.ReadLine();
        }

        static void ShortActionExample()
        {
            // Represent a method that take no argument and returns void
            Action ActionNoArgument = () => System.Console.WriteLine("Hello world");
            // Invoking delegate with no input parameter 
            ActionNoArgument();

            // Represent a method that take one argument and returns void
            Action<string> DisplayAlertMessage = (message) => Console.WriteLine($"Alert Message.. , { message }!");
            // Invoking delegate with one input parameter 
            DisplayAlertMessage ("Some Alter Message"); 
        }
        static void ShortFuncExample()
        {
            // Represent a method that take no argument and returns string result
            Func<string> FuncNoArgument = () => {return "Hello world";};
            // Invoking delegate with no input parameter and get string result "Hello World"
            string result = FuncNoArgument();
            System.Console.WriteLine(result);

            // Represent a method that take one argument and returns int value as result
            Func<string,int> LengthOfContent = (message) => {return message.Length ;};
            // Invoking delegate with one input parameter and get int vlaue as result.
            int contentLength = LengthOfContent ("Some text to find lenth of content"); 
            System.Console.WriteLine(contentLength);
        }
        static void PracticalActionDelegateExample()
        {
            string filepath ="http://bulk.openweathermap.org/sample/history.city.list.json.gz"; // "http://bulk.openweathermap.org/sample/hourly_14.json.gz";  
            string newfile = "sample.csv" ; 
          
            DownloadContent downloadContent = new DownloadContent();
          
            downloadContent.DownloadFileAsync(filepath, newfile,
                       OnDownloadSuccess,OnDownloadFailure );

            Console.WriteLine($"Downloading file from {filepath} asynchronously \n");
            Console.WriteLine("Caller will be notified once file is dowonloaded completely \n");
                    
            Console.WriteLine("Let us continue with other tasks....");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Executing task {i}");
                System.Threading.Thread.Sleep(2000);
                Console.WriteLine($"Executed task {i} \n");
            }
        }
        /// <summary>
        /// This method is passed as a callback method in order to notifiy sucess result
        /// </summary>
        /// <param name="message"></param>
        static void OnDownloadSuccess(string message)
        {
                Console.WriteLine($"*** {message} ***");
        }
        /// <summary>
        /// This method is passed as a callback method in order to notifiy error messages
        /// </summary>
        /// <param name="errorMessage"></param>
        static void OnDownloadFailure(string errorMessage)
        {
               Console.WriteLine($"*** {errorMessage} ***");
        }
        static void PracticalFuncDelegateExample()
        {
            LaptopOrganizer laptopManager = new LaptopOrganizer();
            
            System.Console.WriteLine("Default Categorization List \n");
            //Default categorization rule implemented in laptopManager instance.
            foreach (var item in laptopManager.GetCategorizedLaptop())
            {
                System.Console.WriteLine(item);
            }

            System.Console.WriteLine("\nCustom Categorizaiton list based on laptop processer capacity \n");
            // Customer rules are passed as a function signature matches with Func<Laptop,String> 
            foreach (var item in laptopManager.GetUserCategorizedLaptop(CustomCategorizeLaptops))
            {
                System.Console.WriteLine(item);
            }  
         }

        /// <summary>
        /// This method implement custom rule for lapto categorization 
        /// This method is passed as parameter in GetUserCategorizedLaptop of laptopManager instance
        /// </summary>
        static string CustomCategorizeLaptops(Laptop item){
            
            if(item.processor == "i9")
                return $"Gaming Laptop - {item.Name} - {item.Description} - ${item.Price}";
            else if(item.processor == "i7")
              return $"Professional Laptop - {item.Name} - {item.Description} - ${item.Price}";
            else
                return $"student Laptop - {item.Name} - {item.Description} - ${item.Price}";

        }
    }
}