namespace CustomJsonConverter;

public record class MasterContact(
    string Name,
    Department Department,
    string Phone,
    Address Address,
    string Email) : Contact(Name, Department, Phone, Address);