using PlugInBase;
using System.Reflection;

namespace PluginPatternInCSharp;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Load commands from plugins.
            var binDir = Environment.CurrentDirectory;
            var files = Directory.GetFiles(binDir, "*.dll").ToList();

            // remove assembly for this base app aka this assembly we are coding in now
            files.Remove(typeof(Program).Assembly.Location);
            files.Remove(Path.Combine(binDir, "PlugInBase.dll"));

            var commands = files.SelectMany(pluginPath =>
            {
                var pluginAssembly = LoadPlugin(pluginPath);

                return CreateCommands(pluginAssembly);
            }).ToList();

            if (args.Length == 0)
            {
                Console.WriteLine("Welcome to the Weather App. Here are the available commands: \n\nCommands: ");
                // Output the loaded commands.
                foreach (var command in commands)
                {
                    Console.WriteLine($"{command.Name}\t - {command.Description}");
                }
            }
            else
            {
                foreach (string commandName in args)
                {
                    Console.WriteLine($"-- {commandName} --");

                    // Execute the command with the name passed as an argument.
                    var command = commands.FirstOrDefault(c => c.Name == commandName);
                    if (command == null)
                    {
                        Console.WriteLine();
                        Console.WriteLine("No such command is known.");

                        return;
                    }

                    command.Invoke();
                }
            }

            Console.WriteLine("\nApplication Closing");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    static Assembly LoadPlugin(string assemblyPath)
    {
        Console.WriteLine($"Loading commands from: {assemblyPath}");
        var loadContext = new PluginLoadContext(assemblyPath);

        return loadContext.LoadFromAssemblyName(new AssemblyName(Path.GetFileNameWithoutExtension(assemblyPath)));
    }

    static IEnumerable<ICommand> CreateCommands(Assembly assembly)
    {
        int count = 0;

        foreach (var type in assembly.GetTypes())
        {
            if (type is not null &&
                type.GetInterfaces().Any(intf => intf.FullName?.Contains(nameof(ICommand)) ?? false))
            {
                var result = Activator.CreateInstance(type) as ICommand;
                if (result != null)
                {
                    count++;

                    yield return result;
                }
            }
        }

        if (count == 0)
        {
            var availableTypes = string.Join(",", assembly.GetTypes().Select(t => t.FullName));
            throw new ApplicationException(
                $"Can't find any type which implements ICommand in {assembly} from {assembly.Location}.\n" +
                $"Available types: {availableTypes}");
        }
    }
}