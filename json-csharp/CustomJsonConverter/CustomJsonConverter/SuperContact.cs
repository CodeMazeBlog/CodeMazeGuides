namespace CustomJsonConverter;

public record class SuperContact(
    string Name, 
    Department Department, 
    string Phone, 
    Address Address,
    string Mobile) : Contact(Name, Department, Phone, Address);