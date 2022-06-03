
using Base64EncodingAndDecoding;

Run();

void Run()
{
    var _base64Operations = new Base64Operations();
    var sampletext = "To what length can the human lifespan be extended?";
    Console.WriteLine($"{sampletext} \n");

    var base64String = _base64Operations.Base64Encoding(sampletext);
    Console.WriteLine(string.Format("Base64 string is '{0}' ", base64String));
    Console.WriteLine(string.Format("Decoded value is '{0}' \n", _base64Operations.Base64Decoding(base64String)));

    base64String = _base64Operations.Base64Encoding(sampletext, 3, 4);
    Console.WriteLine(string.Format("Base64 string is '{0}' ", base64String));
    Console.WriteLine(string.Format("Decoded value is '{0}' \n", _base64Operations.Base64Decoding(base64String)));
    Console.WriteLine();

    sampletext = "At length, other servants heard him, and were entranced by his wonderful song.";
    base64String = _base64Operations.Base64Encoding(sampletext, true);
    Console.WriteLine(string.Format("Base64 string is '{0}' ", base64String));
    Console.WriteLine(string.Format("Decoded value is '{0}' \n", _base64Operations.Base64Decoding(base64String)));

    Console.ReadLine();
}