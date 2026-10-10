namespace HowToSecurePasswordsWithBCryptNET;

public class PasswordLoginService
{
    public const int CurrentWorkFactor = 11;

    public string? LoginAndUpgrade(string password, string storedHash)
    {
        if (!BCrypt.Net.BCrypt.Verify(password, storedHash))
            return null;

        return BCrypt.Net.BCrypt.PasswordNeedsRehash(storedHash, CurrentWorkFactor)
            ? BCrypt.Net.BCrypt.HashPassword(password, CurrentWorkFactor)
            : null;
    }
}
