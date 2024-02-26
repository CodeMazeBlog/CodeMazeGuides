namespace CalculateDirectorySize;

public class DirectorySizeCalculator
{
    public static long GetSizeWithRecursion(DirectoryInfo directory)
    {
        if (directory == null || !directory.Exists)
        {
            throw new DirectoryNotFoundException("Directory does not exist.");
        }

        long size = 0;

        try
        {
            size += directory.GetFiles().Sum(file => file.Length);

            size += directory.GetDirectories().Sum(GetSizeWithRecursion);
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"We do not have access to {directory}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"We encountered an error processing {directory}: ");
            Console.WriteLine($"{ex.Message}");
        }

        return size;
    }

    public static long GetSizeByIteration(string directoryPath)
    {
        long size = 0;
        Stack<string> stack = new Stack<string>();

        stack.Push(directoryPath);

        while (stack.Count > 0)
        {
            string directory = stack.Pop();

            try
            {
                string[] files = Directory.GetFiles(directory);

                foreach (var file in files)
                {
                    size += new FileInfo(file).Length;
                }

                string[] sunDirectories = Directory.GetDirectories(directory);

                foreach (var subDirectory in sunDirectories)
                {
                    stack.Push(subDirectory);
                }
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Directory not found");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"We do not have access to {directory}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"We encountered an error processing {directory}: ");
                Console.WriteLine($"{ex.Message}");
            }
        }

        return size;
    }

    public static long GetSizeByParallelProcessing(DirectoryInfo directory, bool recursive = true)
    {
        if (directory == null || !directory.Exists)
        {
            throw new DirectoryNotFoundException("Directory does not exist.");
        }

        long size = 0;

        try
        {
            foreach (var fileInfo in directory.GetFiles())
            {
                size += fileInfo.Length;
            }

            if (recursive)
            {
                Parallel.ForEach(directory.GetDirectories(), subDirectory =>
                {
                    try
                    {
                        Interlocked.Add(ref size, GetSizeByParallelProcessing(subDirectory, recursive));
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Console.WriteLine($"We do not have access to {subDirectory}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"We encountered an error processing {subDirectory}: ");
                        Console.WriteLine($"{ex.Message}");
                    }
                });
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"Unauthorized access to {directory.Name}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing {directory.Name}: ");
            Console.WriteLine($"{ex.Message}");
        }

        return size;
    }

}
