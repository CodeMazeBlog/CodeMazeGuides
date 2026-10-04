using HowToSecurePasswordsWithBCryptNET;

var passwordHash = BCrypt.Net.BCrypt.HashPassword("Password123!");
Console.WriteLine($"Hash: {passwordHash}");
Console.WriteLine($"Verified: {BCrypt.Net.BCrypt.Verify("Password123!", passwordHash)}");

var oldHash = BCrypt.Net.BCrypt.HashPassword("Password123!", workFactor: 6);
var upgradedHash = new PasswordLoginService().LoginAndUpgrade("Password123!", oldHash);
Console.WriteLine($"Upgraded hash: {upgradedHash}");
