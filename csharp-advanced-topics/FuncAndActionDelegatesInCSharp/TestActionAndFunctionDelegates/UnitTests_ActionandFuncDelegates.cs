using NUnit.Framework;
using Action_and_Function_Delegates;
using System.Text.Json;
using System.Diagnostics.Metrics;

namespace TestActionAndFunctionDelegates
{

    delegate void SimpleDelegateReadNumberDeclaration(int x);

    delegate string SimpleDelegateJoinStringDeclaration(string str1, string str2);

    delegate Defender BaseDelegateGetDefenderWithHighestKills(List<Defender> defenders, bool Flag);

    delegate void BaseDelegatePrintLeaderBoards(List<Defender> defenders);

    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        public static void PrintNumber(int num) => Console.WriteLine($"Number passed in this method: {num}");

        public static string ReturnTwoStringsJoined(string str1, string str2) => (str1 + " " + str2);

        public static Defender AssignHighestKill(List<Defender> defenders, bool Flag)
        {
            if (!Flag)
            {
                return new Defender();
            }
            else
            {
                return defenders.MaxBy(defender => defender.OrcKills) ?? new Defender();
            }

        }

        public static void GetDefenderWithKillsHigherThan5000(Defender defender, List<Defender> highKillDefenders)
        {
            if (defender.OrcKills > 5000)
            {
                highKillDefenders.Add(defender);
            }
        }

        public static void OrderByAccordingToKills(List<Defender> defenders)
        {
            Console.WriteLine("Printing LeaderBoards of Battle");

            int counter = 0;

            foreach (var defender in defenders.OrderByDescending(x => x.OrcKills).ToList())
            {
                Console.WriteLine($"{counter}. {defender.Name} - {defender.OrcKills}");
                counter++;
            }
        }

        static List<Defender> Defenders = new()
        {
            new Defender { Name = "Harry Styles", Age = 24, Dept = Departments.Bard, OrcKills = 980 },
            new Defender { Name = "Legolas Mirkwood", Age = 118, Dept = Departments.Archer, OrcKills = 98088 },
            new Defender { Name = "Jaina Proudmore", Age = 32, Dept = Departments.Archmage, OrcKills = 222118 },
            new Defender { Name = "Thrall Stormhammer", Age = 29, Dept = Departments.Bard, OrcKills = 15924 },
            new Defender { Name = "Harry Potter", Age = 18, Dept = Departments.Wizard, OrcKills = 2112 },
            new Defender { Name = "Greenwich Hollow", Age = 35, Dept = Departments.Abyss, OrcKills = 9999 },
            new Defender { Name = "Abyssal Grounds", Age = 224, Dept = Departments.Abyss, OrcKills = 4902 },
            new Defender { Name = "Teethering Heavens", Age = 1118, Dept = Departments.Abyss, OrcKills = int.MaxValue },
            new Defender { Name = "Cloudburst Inferno", Age = 132, Dept = Departments.Elemental, OrcKills = 3349 },
            new Defender { Name = "Diablo Nevermore", Age = 214, Dept = Departments.Elemental, OrcKills = 8000 },
            new Defender { Name = "Frodo Baggins", Age = 111, Dept = Departments.BraveFool, OrcKills = 200 },
            new Defender { Name = "Samwise Gamgee", Age = 92, Dept = Departments.BraveFool, OrcKills = 400 }
        };

        [Test]
        public void WhenIntIsSent_BaseDelegateExecutesReferenceMethod()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);

            var baseDelegate = new SimpleDelegateReadNumberDeclaration(PrintNumber);

            baseDelegate.Invoke(125);

            var result = writer.ToString().Trim();

            Assert.That(result, Is.EqualTo("Number passed in this method: 125"));
        }

        [Test]
        public void WhenStringIsSent_BaseDelegateReturnsStringsJoined()
        {
            var baseStringDelegate = new SimpleDelegateJoinStringDeclaration(ReturnTwoStringsJoined);
            var result = baseStringDelegate("Code", "Maze");
            Assert.That(result, Is.EqualTo("Code Maze"));
        }

        [Test]
        public void WhenStringIsSent_FuncDelegateReturnsStringsJoined()
        {
            Func<string, string, string> funcStringDelegate = ReturnTwoStringsJoined;

            var result = funcStringDelegate("Code", "Maze");
            Assert.That(result, Is.EqualTo("Code Maze"));
        }

        [Test]
        public void WhenIntIsSent_ActionDelegatePrintsNumberWithoutInvoke()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);

            Action<int> actionPrintDelegate = PrintNumber;
            actionPrintDelegate(100);
            
            var output = writer.ToString().Trim();

            Assert.That(output, Is.EqualTo("Number passed in this method: 100"));
        }

        [Test]
        public void WhenIntIsSent_ActionDelegatePrintsNumberWithInvoke()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);

            Action<int> actionPrintDelegate = PrintNumber;

            actionPrintDelegate.Invoke(100);

            var output = writer.ToString().Trim();


            Assert.That(output, Is.EqualTo("Number passed in this method: 100"));
        }

        [Test]
        public void WhenDefenderListIsSent_BaseDelegateGetDefenderWithHighestOrcKills()
        {
            var baseDelegateGetDefenderWithHighestKill = new BaseDelegateGetDefenderWithHighestKills(AssignHighestKill);

            Defender baseHighestKills = baseDelegateGetDefenderWithHighestKill(Defenders, true);

            Assert.That(baseHighestKills.Name, Is.EqualTo("Teethering Heavens"));
        }

        [Test]
        public void WhenDefenderListIsSent_FuncDelegateGetDefenderWithHighestOrcKills()
        {
            Func<List<Defender>, bool, Defender> funcDelegateGetDefenderWithHighestKill = AssignHighestKill;

            Defender funcHighestKills = funcDelegateGetDefenderWithHighestKill(Defenders, true);

            Assert.That(funcHighestKills.Name, Is.EqualTo("Teethering Heavens"));
        }

        //[Test]
        //public void WhenDefenderListIsSent_BaseDelegatePrintDefenderListAccordingToKills()
        //{
        //    var writer = new StringWriter();
        //    Console.SetOut(writer);


        //    var baseDelegatePrintLeaderBoards = new BaseDelegatePrintLeaderBoards(OrderByAccordingToKills);

        //    baseDelegatePrintLeaderBoards(Defenders);

        //    var output = writer.ToString().Trim();

        //    Assert.That(output, Is.EqualTo("Printing LeaderBoards of Battle\n0. Teethering Heavens - 2147483647\n1. Jaina Proudmore - 222118\n2. Legolas Mirkwood - 98088\n3. Thrall Stormhammer - 15924\n4. Greenwich Hollow - 9999\n5. Diablo Nevermore - 8000\n6. Abyssal Grounds - 4902\n7. Cloudburst Inferno - 3349\n8. Harry Potter - 2112\n9. Harry Styles - 980\n10. Samwise Gamgee - 400\n11. Frodo Baggins - 200"));
            
        //}

        //[Test]
        //public void WhenDefenderListIsSent_ActionDelegatePrintDefenderListAccordingToKills()
        //{
        //    var writer = new StringWriter();
        //    Console.SetOut(writer);

        //    Action<List<Defender>> actionDelegatePrintLeaderBoards = OrderByAccordingToKills;
        //    actionDelegatePrintLeaderBoards(Defenders); 

        //    var output = writer.ToString().Trim();

        //    Assert.That(output, Is.EqualTo("Printing LeaderBoards of Battle\n0. Teethering Heavens - 2147483647\n1. Jaina Proudmore - 222118\n2. Legolas Mirkwood - 98088\n3. Thrall Stormhammer - 15924\n4. Greenwich Hollow - 9999\n5. Diablo Nevermore - 8000\n6. Abyssal Grounds - 4902\n7. Cloudburst Inferno - 3349\n8. Harry Potter - 2112\n9. Harry Styles - 980\n10. Samwise Gamgee - 400\n11. Frodo Baggins - 200"));

        //}
    }
}