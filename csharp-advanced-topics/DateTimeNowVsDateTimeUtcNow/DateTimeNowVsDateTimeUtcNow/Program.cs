var now = DateTime.Now; 
var utcNow = DateTime.UtcNow; 
Console.WriteLine("Local Now: " + now.ToString()); 
Console.WriteLine("UTC Now: " + utcNow.ToString());
now = DateTime.Now; 
utcNow = DateTime.UtcNow; 
if (utcNow.Kind == DateTimeKind.Utc) 
{ 
    var oldKind = utcNow.Kind; 
    var utcToLocal = utcNow.ToLocalTime(); 
    var newKind = utcToLocal.Kind; 
    Console.WriteLine(utcNow + " converted from UTC To Local is: " + utcToLocal); 
}
if (now.Kind == DateTimeKind.Local) 
{ 
    var oldKind = now.Kind; 
    var localToUtc = utcNow.ToUniversalTime(); 
    var newKind = localToUtc.Kind; 
    Console.WriteLine(utcNow + " converted from Local To UTC is: " + localToUtc); 
}