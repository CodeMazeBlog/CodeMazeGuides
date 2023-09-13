namespace SampleClassification.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create single instance of sample data from first line of dataset for model input
            var sampleData = new SampleClassification.ModelInput()
            {
                Checking_status = @"<0",
                Duration = 60F,
                Credit_history = @"critical/other existing credit",
                Purpose = @"radio/tv",
                Credit_amount = 11690F,
                Savings_status = @"no known savings",
                Employment = @">=7",
                Installment_commitment = 40F,
                Personal_status = @"male single",
                Other_parties = @"none",
                Residence_since = 40F,
                Property_magnitude = @"real estate",
                Age = 670F,
                Other_payment_plans = @"none",
                Housing = @"own",
                Existing_credits = 20F,
                Job = @"skilled",
                Num_dependents = 10F,
                Own_telephone = @"yes",
            };

            Console.WriteLine("Using model to make single prediction -- Comparing actual Class with predicted Class from sample data...\n\n");

            Console.WriteLine($"Checking_status: {@"<0"}");
            Console.WriteLine($"Duration: {60F}");
            Console.WriteLine($"Credit_history: {@"critical/other existing credit"}");
            Console.WriteLine($"Purpose: {@"radio/tv"}");
            Console.WriteLine($"Credit_amount: {11690F}");
            Console.WriteLine($"Savings_status: {@"no known savings"}");
            Console.WriteLine($"Employment: {@">=7"}");
            Console.WriteLine($"Installment_commitment: {40F}");
            Console.WriteLine($"Personal_status: {@"male single"}");
            Console.WriteLine($"Other_parties: {@"none"}");
            Console.WriteLine($"Residence_since: {40F}");
            Console.WriteLine($"Property_magnitude: {@"real estate"}");
            Console.WriteLine($"Age: {670F}");
            Console.WriteLine($"Other_payment_plans: {@"none"}");
            Console.WriteLine($"Housing: {@"own"}");
            Console.WriteLine($"Existing_credits: {20F}");
            Console.WriteLine($"Job: {@"skilled"}");
            Console.WriteLine($"Num_dependents: {10F}");
            Console.WriteLine($"Own_telephone: {@"yes"}");
            Console.WriteLine($"Class: {@"good"}");

            var sortedScoresWithLabel = SampleClassification.PredictAllLabels(sampleData);
            Console.WriteLine($"{"Class",-40}{"Score",-20}");
            Console.WriteLine($"{"-----",-40}{"-----",-20}");

            foreach (var score in sortedScoresWithLabel)
                Console.WriteLine($"{score.Key,-40}{score.Value,-20}");

            Console.WriteLine("=============== End of process, hit any key to finish ===============");
            Console.ReadKey();
        }
    }
}