using Autofac;

using AutoFacImplementation.Implementation;
using AutoFacImplementation.Interfaces;

using System;

namespace AutoFacImplementation
{
    public class Program
    {
        static void Main(string[] args)
        {
            var container = BuildContainer();
            var personListResolver = container.Resolve<IPersonBusiness>();
            var personList = personListResolver.GetPersonList();
            foreach (var person in personList)
            {
                Console.WriteLine(person);
            }
        }

        static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<PersonBusiness>().As<IPersonBusiness>();
            return builder.Build();
        }
    }
}
