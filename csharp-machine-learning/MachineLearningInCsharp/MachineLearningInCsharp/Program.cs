using MachineLearningInCsharpEngine.DataModels.MulticlassClassification;

namespace MachineLearningInCsharp;

public class Program
{
    public static void Main()
    {
        var modelBuilder = new ModelBuilder();
        modelBuilder.LoadModel(Path.Combine(AppContext.BaseDirectory, "trainedModel.zip"));

        var modelInput = new ModelInput()
        {
            Age = 22,
            CreditAmount = 15000,
            Duration = 60
        };

        var prediction = modelBuilder.Predict(modelInput);
        Console.WriteLine($"\nExample input class is {prediction.Prediction.ToUpper()}!");

        string? inputString;
        float inputValue;

        Console.WriteLine("\nInput data:");

        Console.Write("Age in years:\t\t");
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

        prediction = modelBuilder.Predict(modelInput);
        Console.WriteLine($"\nYour credit application class is {prediction.Prediction.ToUpper()}!");
    }
}