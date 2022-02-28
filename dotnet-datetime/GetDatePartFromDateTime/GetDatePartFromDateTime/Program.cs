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

DateTime date3 = new DateTime(2022, 02, 14, 10, 40, 00); 

Console.WriteLine("Short Date Value:"); 
Console.WriteLine(date3.Date.ToShortDateString());

DateTime date = new DateTime(2021, 7, 8, 11, 10, 9); 
DateOnly dateOnly = new DateOnly(date.Year, date.Month, date.Day); 

Console.WriteLine(dateOnly);

DateTime may12 = new DateTime(2022, 5, 12, 10, 15, 11); 

Console.WriteLine(String.Format($"{may12:d}")); 
Console.WriteLine(String.Format($"{may12:D}"));

DateTime april10 = new DateTime(2022, 4, 10, 10, 15, 11); 

Console.WriteLine(String.Format($"{april10:dd-MM-yy}")); 
Console.WriteLine(String.Format($"{april10:ddd, dd MM yy}")); 
Console.WriteLine(String.Format($"{april10:dd MMM yyyy}")); 
Console.WriteLine(String.Format($"{april10:ddd, dd MMMM, yyyy}"));