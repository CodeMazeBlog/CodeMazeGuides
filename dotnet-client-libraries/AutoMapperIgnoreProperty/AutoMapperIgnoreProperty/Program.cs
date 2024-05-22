using System.ComponentModel;
using AutoMapperIgnoreProperty;

var user = new User
{
    Id = 1,
    Email = "user01@codemaze.com",
    CreatedAt = DateTime.Now,
    Password = "Password123!",
    IsAdmin = true
};

var mapper1 = MapperHelper.GetMapperIgnoringSensitiveProperties();
var userDto1 = mapper1.Map<UserDto>(user);
PrintObject(user);
PrintObject(userDto1);

var mapper2 = MapperHelper.GetMapperIgnoringSensitivePropertiesWithAttribute();
var userDetailsDto = mapper2.Map<UserDetailsDto>(user);
PrintObject(user);
PrintObject(userDetailsDto);

var mapper3 = MapperHelper.GetMapperIgnoringSourceMembers();
var userDto3 = mapper3.Map<UserDto>(user);
PrintObject(user);
PrintObject(userDto3);

void PrintObject(object userObject)
{
    Console.WriteLine("*** {0} ***", userObject.GetType().Name.ToString());
    
    foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(userObject))
    {
        string name = descriptor.Name;
        object value = descriptor.GetValue(userObject);
        Console.WriteLine("{0}: {1}", name, value);
    }

    Console.WriteLine();
}