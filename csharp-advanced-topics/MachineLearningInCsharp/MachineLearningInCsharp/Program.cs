using MachineLearningInCsharpEngine.DataModels.MulticlassClassification;

namespace MachineLearningInCsharp;

public class Program
{
    private static string savedModelFilename = "trainedModel.zip";
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
        modelInput.Age = inputValue;

        Console.Write("Credit Amount:\t\t");
        inputString = Console.ReadLine();
        while (string.IsNullOrEmpty(inputString) || !float.TryParse(inputString, out inputValue))
        {
            Console.WriteLine("Incorrect input. Try again:");
            inputString = Console.ReadLine();
        }
        modelInput.CreditAmount = inputValue;

        Console.Write("Duration in months:\t");
        inputString = Console.ReadLine();
        while (string.IsNullOrEmpty(inputString) || !float.TryParse(inputString, out inputValue))
        {
            Console.WriteLine("Incorrect input. Try again:");
            inputString = Console.ReadLine();
        }
        modelInput.Duration = inputValue;

        var prediction = modelBuilder?.Predict(modelInput);

        Console.WriteLine($"\nYour credit application class is {prediction?.Prediction.ToUpper()}!");
    }
}