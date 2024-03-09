using ExceptionHandlingInCSharp.Exceptions;
using ExceptionHandlingInCSharp.Models;
using ExceptionHandlingInCSharp.Services;

namespace ExceptionHandlingInCSharp;

public static class SampleRunner
{
    public static GetUserResult GetUserById(int id)
    {
        AppDomain.CurrentDomain.UnhandledException += GlobalExceptionHandler.HandleException;

        var userService = new UserService();

        try
        {
            try
            {
                var user = userService.GetById(id);
                Console.WriteLine($"Got user with ID: {user.Id}");
                LogUserDetails(user);

                return GetUserResult.Success(user);
            }
            catch(InvalidUserIdException) when (id <= 0)
            {
                return GetUserResult.Error("User Id should be a positive number.");
            }
            catch (InvalidUserIdException) when (id >= 1000)
            {
                return GetUserResult.Error("User ID should be less than 1000.");
            }
            catch (InvalidOperationException) 
            { 
                return GetUserResult.Error("User not found."); 
            }
        }
        catch (Exception)
        {
            Console.WriteLine("An Unexpected Error has occurred.");
            throw;
        }
        finally
        {
            userService?.Clear();
        }
    }

    private static void LogUserDetails(User user)
    {
        var previousColor = Console.ForegroundColor;
        try
        {
            Console.ForegroundColor = ConsoleColor.Green;
            ArgumentNullException.ThrowIfNull(user, nameof(user));
            Console.WriteLine($"ID: {user.Id}");
            Console.WriteLine($"Name: {user.Name}");
        }
        finally
        {
            Console.ForegroundColor = previousColor;
        }
    }
}
