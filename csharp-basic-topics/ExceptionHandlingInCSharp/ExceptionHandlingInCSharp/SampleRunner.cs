using ExceptionHandlingInCSharp.Exceptions;
using ExceptionHandlingInCSharp.Models;
using ExceptionHandlingInCSharp.Services;

namespace ExceptionHandlingInCSharp;

public static class SampleRunner
{
    public static GetUserResult GetUserById(int id)
    {
        AppDomain.CurrentDomain.UnhandledException += GlobalExceptionHandler.HandleException;
        UserService? userService = null;
        try
        {
            userService = new UserService();
            try
            {
                var user = userService.GetById(id);
                Console.WriteLine($"Got user with ID: {user.Id}");
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
            catch (NullReferenceException) 
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
}
