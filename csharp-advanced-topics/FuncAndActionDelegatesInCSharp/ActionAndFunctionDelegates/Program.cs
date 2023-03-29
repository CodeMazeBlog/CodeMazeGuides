// See https://aka.ms/new-console-template for more information
using Action_and_Function_Delegates;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Action_and_Function_Delegates
{

    delegate void SimpleDelegateReadNumberDeclaration(int x);
    class Program
    {

        delegate string SimpleDelegateJoinStringDeclaration(string str1, string str2);
        public static void PrintNumber(int num) => Console.WriteLine($"Number passed in this method: {num}");

        public static string ReturnTwoStringsJoined(string str1, string str2) => (str1 + " " + str2);

        delegate Defender BaseDelegateGetDefenderWithHighestKills(List<Defender> defenders, bool Flag);

        public static Defender AssignHighestKill(List<Defender> defenders, bool Flag)
        {
            if(!Flag)
            {
                return new Defender();
            }
            else
            {
                return defenders.MaxBy(defender => defender.OrcKills) ?? new Defender();
            }
            
        }

        delegate void BaseDelegatePrintLeaderBoards(List<Defender> defenders);

        public static void OrderByAccordingToKills(List<Defender> defenders)
        {
            Console.WriteLine("Printing LeaderBoards of Battle");
            int counter = 0; 
            foreach(var defender in defenders.OrderByDescending(x => x.OrcKills).ToList())
            {
                //string json = JsonSerializer.Serialize(defender, new JsonSerializerOptions { WriteIndented = true } );

                
                Console.WriteLine($"{counter}. {defender.Name} - {defender.OrcKills}");

                counter++;
            }
        }

        public static void GetDefenderWithKillsHigherThan5000(Defender defender, List<Defender> highKillDefenders)
        {
            if(defender.OrcKills > 5000)
            {
                highKillDefenders.Add(defender);
            }
        }

        static void Main(string[] args) 
        {
            var simpleDelegateReadNumberInitiation = new SimpleDelegateReadNumberDeclaration(PrintNumber);

            simpleDelegateReadNumberInitiation.Invoke(55);

            var simpleDelegateJoinStringInitiation = new SimpleDelegateJoinStringDeclaration(ReturnTwoStringsJoined);

            var myJoinedString = simpleDelegateJoinStringInitiation("Code", "Maze");

            Console.WriteLine("My joined string was: " + myJoinedString);

            Func<string, string, string> funcDelegateForJoinString = ReturnTwoStringsJoined;

            //Console.WriteLine("My joined string with Func delegate: " + funcDelegateForJoinString("Func", "Delegates"));


            Action<int> actionDelegateForPrintNumber = PrintNumber;

            actionDelegateForPrintNumber.Invoke(55);
            actionDelegateForPrintNumber(55); 


            Defender highestKills = new();

            Func<List<Defender>, bool, Defender> funcDelegateGetDefenderWithHighestKill = AssignHighestKill;

            var baseDelegateGetDefenderWithHighestKill = new BaseDelegateGetDefenderWithHighestKills(AssignHighestKill);

            Defender baseHighestKills = baseDelegateGetDefenderWithHighestKill(Defenders, true);

            string baseJson = JsonSerializer.Serialize(baseHighestKills, new JsonSerializerOptions { WriteIndented = true } );

            Defender funcHighestKills = funcDelegateGetDefenderWithHighestKill(Defenders, true);

            string funcJson = JsonSerializer.Serialize(funcHighestKills, new JsonSerializerOptions { WriteIndented = true });

            Action<List<Defender>> actionDelegatePrintLeaderBoards = OrderByAccordingToKills;

            var baseDelegatePrintLeaderBoards = new BaseDelegatePrintLeaderBoards(OrderByAccordingToKills);

            actionDelegatePrintLeaderBoards(Defenders);

            baseDelegatePrintLeaderBoards(Defenders);

            var defendersWithHighKills = Defenders.Where(Defender => Defender.OrcKills > 5000);

            List<Defender> actionFuncHighKillDefenders = new();

            Action<Defender, List<Defender>> actionDelegateGetHighKillsDefenders = GetDefenderWithKillsHigherThan5000;

            Defenders.ForEach(defender => GetDefenderWithKillsHigherThan5000(defender, actionFuncHighKillDefenders)); 

            string json = JsonSerializer.Serialize(actionFuncHighKillDefenders, new  JsonSerializerOptions { WriteIndented = true });

        }

        static List<Defender> Defenders = new()
        {
            new Defender { Name = "Harry Styles", Age = 24, Dept = Departments.Bard, OrcKills = Random.Shared.Next(100000) },
            new Defender { Name = "Legolas Mirkwood", Age = 118, Dept = Departments.Archer, OrcKills = Random.Shared.Next(100000) },
            new Defender { Name = "Jaina Proudmore", Age = 32, Dept = Departments.Archmage, OrcKills = Random.Shared.Next(100000) },
            new Defender { Name = "Thrall Stormhammer", Age = 29, Dept = Departments.Bard, OrcKills = Random.Shared.Next(100000) },
            new Defender { Name = "Harry Potter", Age = 18, Dept = Departments.Wizard, OrcKills = Random.Shared.Next(100000) },
            new Defender { Name = "Greenwich Hollow", Age = 35, Dept = Departments.Abyss, OrcKills = Random.Shared.Next(100000) },
            new Defender { Name = "Abyssal Grounds", Age = 224, Dept = Departments.Abyss, OrcKills = Random.Shared.Next(100000) },
            new Defender { Name = "Teethering Heavens", Age = 1118, Dept = Departments.Abyss, OrcKills = Random.Shared.Next(100000) },
            new Defender { Name = "Cloudburst Inferno", Age = 132, Dept = Departments.Elemental, OrcKills = Random.Shared.Next(100000) },
            new Defender { Name = "Diablo Nevermore", Age = 214, Dept = Departments.Elemental, OrcKills = Random.Shared.Next(100000) },
            new Defender { Name = "Frodo Baggins", Age = 111, Dept = Departments.BraveFool, OrcKills = Random.Shared.Next(100000) },
            new Defender { Name = "Samwise Gamgee", Age = 92, Dept = Departments.BraveFool, OrcKills = Random.Shared.Next(100000) }
        };


    }

    public class Defender
    {
        public string? Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public int OrcKills { get; set; } = 0;
        public Departments Dept { get; set; }
    }

    public enum Departments
    {
        Archmage,
        Elemental,
        Wizard,
        Abyss,
        Bard,
        Archer,
        BraveFool
    }
}




