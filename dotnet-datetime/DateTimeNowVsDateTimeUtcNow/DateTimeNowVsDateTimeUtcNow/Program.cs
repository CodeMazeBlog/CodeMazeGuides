var now = DateTime.Now; 
var utcNow = DateTime.UtcNow;

Console.WriteLine($"Local Now: {now}"); 
Console.WriteLine($"UTC Now: {utcNow}");

now = DateTime.Now; 
utcNow = DateTime.UtcNow; 

if (utcNow.Kind == DateTimeKind.Utc) 
{ 
    var oldKind = utcNow.Kind; 
    var utcToLocal = utcNow.ToLocalTime(); 
    var newKind = utcToLocal.Kind; 

    Console.WriteLine($"Converted {utcNow} from {oldKind} To {newKind}: " + utcToLocal); 
}

if (now.Kind == DateTimeKind.Local) 
{ 
    var oldKind = now.Kind; 
    var localToUtc = now.ToUniversalTime(); 
    var newKind = localToUtc.Kind; 

    Console.WriteLine($"Converted {now} from {oldKind} To {newKind}: " + localToUtc); 
}