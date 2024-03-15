using ValidateEmailAddress;

var emailValidator = new EmailValidator();

var validEmails = new string[]
{
    "code@maze.com",
    "code.maze@codemaze.com" ,
    "code@code.com.us",
    "code@maze",
};

var invalidEmails = new string[]
{
    "code.maze.com",
    "code@maze@codemaze.com",
    "code@.maze.com"
};

ValidateUsingMailAddress(emailValidator, validEmails, invalidEmails);

Console.WriteLine(" ----- ");
Console.WriteLine();

ValidateUsingEmailAddressAttribute(emailValidator, validEmails, invalidEmails);

Console.WriteLine(" ----- ");
Console.WriteLine();

ValidateUsingRegex(emailValidator, validEmails, invalidEmails);

Console.WriteLine(" ----- ");
Console.WriteLine();

ValidateUsingFluentValidation(emailValidator, validEmails, invalidEmails);

static void ValidateUsingMailAddress(EmailValidator emailValidator, string[] validEmails, string[] invalidEmails)
{
    Console.WriteLine(" Validate Valid Email Address Using MailAddress:");
    foreach (var item in validEmails)
        Console.WriteLine($"  {item,-25} ==> " +
            $"{(emailValidator.ValidateUsingMailAddress(item) ? "Valid" : "Invalid")}");

    Console.WriteLine(" ----- ");

    Console.WriteLine(" Validate Invalid Email Address Using MailAddress:");
    foreach (var item in invalidEmails)
        Console.WriteLine($"  {item,-25} ==> " +
            $"{(emailValidator.ValidateUsingMailAddress(item) ? "Valid" : "Invalid")}");
}

static void ValidateUsingEmailAddressAttribute(EmailValidator emailValidator, string[] validEmails, string[] invalidEmails)
{
    Console.WriteLine(" Validate Valid Email Address Using EmailAddressAttribute:");
    foreach (var item in validEmails)
        Console.WriteLine($"  {item,-25} ==> " +
            $"{(emailValidator.ValidateUsingEmailAddressAttribute(item) ? "Valid" : "Invalid")}");

    Console.WriteLine(" ----- ");

    Console.WriteLine(" Validate Invalid Email Address Using EmailAddressAttribute:");
    foreach (var item in invalidEmails)
        Console.WriteLine($"  {item,-25} ==> " +
            $"{(emailValidator.ValidateUsingEmailAddressAttribute(item) ? "Valid" : "Invalid")}");
}

static void ValidateUsingRegex(EmailValidator emailValidator, string[] validEmails, string[] invalidEmails)
{
    Console.WriteLine(" Validate Valid Email Address Using Regex");
    foreach (var item in validEmails)
    {
        Console.WriteLine($"  {item,-25} ==> " +
            $"{(emailValidator.ValidateUsingRegex(item) ? "Valid" : "Invalid")}");
    }

    Console.WriteLine(" ----- ");

    Console.WriteLine(" Validate Invalid Email Address Using Regex:");
    foreach (var item in invalidEmails)
        Console.WriteLine($"  {item,-25} ==> " +
            $"{(emailValidator.ValidateUsingRegex(item) ? "Valid" : "Invalid")}");
}

static void ValidateUsingFluentValidation(EmailValidator emailValidator, string[] validEmails, string[] invalidEmails)
{
    Console.WriteLine(" Validate Valid Email Address Using FluentValidation");
    foreach (var item in validEmails)
    {
        Console.WriteLine($"  {item,-25} ==> " +
            $"{(emailValidator.ValidateUsingFluentValidator(item) ? "Valid" : "Invalid")}");
    }

    Console.WriteLine(" ----- ");

    Console.WriteLine(" Validate Invalid Email Address Using FluentValidation:");
    foreach (var item in invalidEmails)
        Console.WriteLine($"  {item,-25} ==> " +
            $"{(emailValidator.ValidateUsingFluentValidator(item) ? "Valid" : "Invalid")}");
}