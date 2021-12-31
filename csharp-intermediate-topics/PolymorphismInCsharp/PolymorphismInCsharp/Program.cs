using Polymorphism_v2;
using System;
using System.IO;

namespace Polymorphism
{
     class Program
    {
        static void Main(string[] args)
        {
            CourierBranch Branch1 = new CourierBranch("Branch 1", "12 Main str.");
            Branch1.AddPackage(new Package("Sender A", "Address A", 10, DateTime.Now));
            Branch1.AddPackage(new ExpeditedPackage("Sender B", "Address B", 10, DateTime.Now));
            Branch1.AddPackage(new InternationalPackage("Sender C", "Address C", 10, DateTime.Now, "US"));
            Branch1.PrintList();

            using (StreamWriter sw = new StreamWriter("output.log", true))
            {
                Logger log = new Logger(sw);
                log.Log("info");
                log.Log("warning", LogLevels.Warning);
                log.Log("error", 3);
            }
        }
    }
}
