using FileScopedTypesInCSharp;

var hiddenClass = new HiddenClass();
var output = hiddenClass.Render();
Console.WriteLine(output);

// Output : Rendering public Hidden Class