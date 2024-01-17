namespace VirtualAndAbstractMethodInCSharp
{
    public class Program
    {
        static void Main()
        {
            var agency = new TransportAgency();
            while (true)
            {
                Console.WriteLine("\nSelect a transport mode:");
                Console.WriteLine("1. Car");
                Console.WriteLine("2. Train");
                Console.WriteLine("3. Plane");
                Console.WriteLine("4. Exit");
                Console.Write("Enter choice: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    TransportModeType modeType = 0;
                    switch (choice)
                    {
                        case 1:
                            modeType = TransportModeType.Car;
                            break;
                        case 2:
                            modeType = TransportModeType.Train;
                            break;
                        case 3:
                            modeType = TransportModeType.Plane;
                            break;
                        case 4:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid Choice. Please try again");
                            continue;
                    }

                    TransportMode mode = agency.CreateTransportMode(modeType);
                    Console.Write("Enter travel distance (km): ");                    
                    double distance = double.Parse(Console.ReadLine() ?? "0");
                    Console.WriteLine("\nEstimated travel time: {0} hours", mode.GetTravelTime(distance));
                    Console.WriteLine("Base fare: ${0}", mode.CalculateBaseFare(distance));                    
                    Console.Write("\nDo you want to choose another transport mode? (y/n): ");
                    string continueChoice = Console.ReadLine() ?? string.Empty;
                    if (!continueChoice.Equals("y", StringComparison.CurrentCultureIgnoreCase))
                    {
                        break; 
                    }                    
                }
            }
        }
    }
}

