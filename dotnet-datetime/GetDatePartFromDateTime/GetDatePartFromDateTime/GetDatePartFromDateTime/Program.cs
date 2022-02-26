DateTime date1 = new DateTime(2022, 02, 14, 10, 40, 00); 
DateTime date2 = new DateTime(2018, 10, 18, 11, 23, 34); 

Console.WriteLine("Full Date:"); 
Console.WriteLine(date1.ToString()); 
Console.WriteLine(date2.ToString()); 

Console.WriteLine("Only .Date part:"); 
Console.WriteLine(date1.Date.ToString()); 
Console.WriteLine(date2.Date.ToString());

Console.WriteLine("Hide the time part:"); 
Console.WriteLine(date1.Date.ToString("MM/dd/yyyy")); 
Console.WriteLine(date2.Date.ToString("dd/MM/yyyy"));