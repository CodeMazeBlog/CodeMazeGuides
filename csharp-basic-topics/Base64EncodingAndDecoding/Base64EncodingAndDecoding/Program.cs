
using Base64EncodingAndDecoding;

Run();

void Run()
{
    var base64Operations = new Base64Operations();
    var sampletext = "To what length can the human lifespan be extended?";
    Console.WriteLine($"{sampletext} \n");

    var base64String = base64Operations.Base64Encoding(sampletext);
    Console.WriteLine($"Base64 string is '{base64String}' ");
    Console.WriteLine($"Decoded value is '{base64Operations.Base64Decoding(base64String)}' \n");

    base64String = base64Operations.Base64Encoding(sampletext, 3, 4);
    Console.WriteLine($"Base64 string is '{base64String}' ");
    Console.WriteLine($"Decoded value is '{base64Operations.Base64Decoding(base64String)}' \n");
    Console.WriteLine();

    sampletext = "The great crocodile of Queensland has been known to attain a length of 30 feet;";
    base64String = base64Operations.Base64Encoding(sampletext, true);
    Console.WriteLine($"Base64 string is '{base64String}' ");
    Console.WriteLine($"Decoded value is '{base64Operations.Base64Decoding(base64String)}' \n");

    Console.WriteLine($"Base64Url string is '{base64Operations.Base64UrlEncoding(sampletext)}' ");
}
