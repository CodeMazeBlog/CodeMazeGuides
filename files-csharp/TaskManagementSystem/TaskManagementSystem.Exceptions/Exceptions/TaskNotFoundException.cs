using Microsoft.AspNetCore.Http;
using TaskManagementSystem.Exceptions.Constants;
using TaskManagementSystem.Exceptions.Exceptions.BaseExceprions;

namespace TaskManagementSystem.Exceptions.Exceptions;

public class TaskNotFoundException : CustomException
{
    public TaskNotFoundException(int id) : 
        base(StatusCodes.Status404NotFound, ErrorCodes.TaskNotFound, $"Task with ID '{id}' does not exist.")
    { 
    }
}
