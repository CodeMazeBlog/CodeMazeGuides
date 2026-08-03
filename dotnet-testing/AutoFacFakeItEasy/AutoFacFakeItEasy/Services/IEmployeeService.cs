using AutoFacFakeItEasy.Models;

namespace AutoFacFakeItEasy.Services;

public interface IEmployeeService
{
    Employee GetById(long id);
    List<Employee> GetAll();
}