namespace HowToCalculateADirectorySize;

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
        var stack = new Stack<string>();

        stack.Push(directoryPath);

        while (stack.Count > 0)
        {
            string directory = stack.Pop();

            try
            {
                var files = Directory.GetFiles(directory);

                foreach (var file in files)
                {
                    size += new FileInfo(file).Length;
                }

                var subDirectories = Directory.GetDirectories(directory);

                foreach (var subDirectory in subDirectories)
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
            // Use EnumerateFiles instead of GetFiles for better performance
            Parallel.ForEach(directory.EnumerateFiles(), fileInfo =>
            {
                try
                {
                    Interlocked.Add(ref size, fileInfo.Length);
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine($"Unauthorized access to {fileInfo.FullName}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing {fileInfo.FullName}: ");
                    Console.WriteLine($"{ex.Message}");
                }
            });

            if (recursive)
            {
                Parallel.ForEach(directory.EnumerateDirectories(), subDirectory =>
                {
                    try
                    {
                        Interlocked.Add(ref size, GetSizeByParallelProcessing(subDirectory, recursive));
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Console.WriteLine($"Unauthorized access to {subDirectory.FullName}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error processing {subDirectory.FullName}: ");
                        Console.WriteLine($"{ex.Message}");
                    }
                });
            }
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine($"Unauthorized access to {directory.FullName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing {directory.FullName}: ");
            Console.WriteLine($"{ex.Message}");
        }

        return size;
    }
}
