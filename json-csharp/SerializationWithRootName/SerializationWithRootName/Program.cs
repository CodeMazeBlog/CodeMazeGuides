using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace SerializationWithRootName
{
	public class Program
	{
		static void Main(string[] args)
		{
		List<Car> cars =
		[
			new Car { Make = "Toyota", Model = "Camry", Year = 2022 },
			new Car { Make = "Honda", Model = "Accord", Year = 2021 }
		];


			// JSON Serialization
			string json = Serialization.SerializeToJsonWithRootName(cars);
			Console.WriteLine("JSON Serialization:\n");
			Console.WriteLine(json);


			string xml = Serialization.SerializeToXmlWithRootName(cars);
			Console.WriteLine(" \n XML Serialization: \n");
			Console.WriteLine(xml);

			Console.ReadLine();

		}
	}
}
