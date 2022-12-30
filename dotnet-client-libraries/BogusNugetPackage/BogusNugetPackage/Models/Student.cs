using BogusNugetPackage.Enums;

namespace BogusNugetPackage.Models;
public sealed record Student(
    string FirstName,
    string LastName,
    string Address,
    string Username,
    string Email,
    int YearsOld,
    StudentType StudentType,
    ICollection<Course> Courses);
