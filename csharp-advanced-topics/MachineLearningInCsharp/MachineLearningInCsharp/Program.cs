using MachineLearningInCsharpEngine.DataModels.BinaryClassification;

namespace MachineLearningInCsharp;

public class Program
{
    private static string savedModelFilename = "binaryCreditClassificationModel.zip";
    public static void Main()
    {
        var modelBuilder = new ModelBuilder();
        modelBuilder.LoadModel(savedModelFilename);

        var modelInput = new ModelInput();

        string? inputString;
        float inputValue;

        Console.WriteLine("Input data:");

        Console.Write("Age in months:\t\t");
        inputString = Console.ReadLine();
        while (string.IsNullOrEmpty(inputString) || !float.TryParse(inputString, out inputValue))
        {
            Console.WriteLine("Incorrect input. Try again:");
            inputString = Console.ReadLine();
        }
        modelInput.age = inputValue;

        Console.Write("Credit Amount:\t\t");
        inputString = Console.ReadLine();
        while (string.IsNullOrEmpty(inputString) || !float.TryParse(inputString, out inputValue))
        {
            Console.WriteLine("Incorrect input. Try again:");
            inputString = Console.ReadLine();
        }
        modelInput.credit_amount = inputValue;

        Console.Write("Duration in months:\t");
        inputString = Console.ReadLine();
        while (string.IsNullOrEmpty(inputString) || !float.TryParse(inputString, out inputValue))
        {
            Console.WriteLine("Incorrect input. Try again:");
            inputString = Console.ReadLine();
        }
        modelInput.duration = inputValue;

        var prediction = modelBuilder?.Predict(modelInput);

        Console.WriteLine(prediction.Prediction ? 
            "\nApplication is acceptable!" : "\nApplication is not acceptable!");
    }
}