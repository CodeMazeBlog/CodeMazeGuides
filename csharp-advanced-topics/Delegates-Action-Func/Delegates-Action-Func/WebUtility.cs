using System.ComponentModel;
using System.Net;

namespace WebUtilities {
   public class DownloadContent {
        public  async void DownloadFileAsync(string url, string FileName, 
                     Action<string> onSucceed, Action<string> onFailed)   
        {
            try 
            {
                WebClient client = new WebClient();

                client.DownloadFileCompleted += (s,e) => 
                {      
                    if(e.Error is null)

                      onSucceed("Download Completed"); 

                    else

                      onFailed($"Error while dowonloading file {e.Error?.Message}");
                };

                System.Console.WriteLine("Downloading started.");

                client.DownloadFileAsync(new Uri(url), FileName);         
            }
            catch (System.Exception ex)
            {        
                onFailed(ex.Message);
            } 
        }          
   }
}

