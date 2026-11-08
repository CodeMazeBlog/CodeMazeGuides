using ValidateEmailAddress;

var emailValidator = new EmailValidator();

var validEmails = new string[]
{
    "code@maze.com",
    "code.maze@codemaze.com",
    "code@code.com.us",
    "code@maze",
};

var invalidEmails = new string[]
{
    "code.maze.com",
    "code@maze@codemaze.com",
    "code@.maze.com",
    "co,de@maze.com",
    "code..maze@maze.com",
};

Validate("MailAddress", emailValidator.ValidateUsingMailAddress);
Validate("MailAddress.TryCreate", emailValidator.ValidateUsingMailAddressTryCreate);
Validate("EmailAddressAttribute", emailValidator.ValidateUsingEmailAddressAttribute);
Validate("Regex", emailValidator.ValidateUsingRegex);
Validate("GeneratedRegex", emailValidator.ValidateUsingGeneratedRegex);
Validate("FluentValidation", emailValidator.ValidateUsingFluentValidator);
Validate("FluentValidation Net4xRegex", emailValidator.ValidateUsingFluentRegexValidator);

void Validate(string approach, Func<string, bool> isValid)
{
    Console.WriteLine($" Validate Valid Email Address Using {approach}:");
    foreach (var item in validEmails)
        Console.WriteLine($"  {item,-25} ==> {(isValid(item) ? "Valid" : "Invalid")}");

    Console.WriteLine(" ----- ");

    Console.WriteLine($" Validate Invalid Email Address Using {approach}:");
    foreach (var item in invalidEmails)
        Console.WriteLine($"  {item,-25} ==> {(isValid(item) ? "Valid" : "Invalid")}");

    Console.WriteLine(" ----- ");
    Console.WriteLine();
}
