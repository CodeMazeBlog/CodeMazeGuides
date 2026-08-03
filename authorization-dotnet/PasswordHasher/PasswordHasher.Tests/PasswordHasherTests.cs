using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using PasswordHasher.Api.Models;

namespace PasswordHasher.Api.Tests;

public class PasswordHasherTests
{
    [Test]
    public void GivenCompatibilityModeIsIdentityV2_WhenHashPasswordIsCalled_ThenPasswordIsHashed()
    {
        var passwordHasherOptions = new PasswordHasherOptions
        {
            CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV2
        };
        var options = new OptionsWrapper<PasswordHasherOptions>(passwordHasherOptions);
        var sut = new PasswordHasher<RegisteredUser>(options);
        var password = "password1";

        var hashedPassword = sut.HashPassword(null, password);

        Assert.That(hashedPassword, Is.Not.Null);
        Assert.That(hashedPassword, Is.Not.EqualTo(password));
    }
    
    [Test]
    public void GivenCompatibilityModeIsIdentityV3_WhenHashPasswordIsCalled_ThenPasswordIsHashed()
    {
        var passwordHasherOptions = new PasswordHasherOptions
        {
            CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3
        };
        var options = new OptionsWrapper<PasswordHasherOptions>(passwordHasherOptions);
        var sut = new PasswordHasher<RegisteredUser>(options);
        var password = "password1";

        var hashedPassword = sut.HashPassword(null, password);

        Assert.That(hashedPassword, Is.Not.Null);
        Assert.That(hashedPassword, Is.Not.EqualTo(password));
    }
    
    [Test]
    public void GivenCompatibilityModeIsIdentityV2_WhenHashPasswordTwice_ThenHashesAreDifferent()
    {
        var passwordHasherOptions = new PasswordHasherOptions
        {
            CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV2
        };
        var options = new OptionsWrapper<PasswordHasherOptions>(passwordHasherOptions);
        var sut = new PasswordHasher<RegisteredUser>(options);

        var hashedPassword1 = sut.HashPassword(null, "password");
        var hashedPassword2 = sut.HashPassword(null, "password");

        Assert.That(hashedPassword1, Is.Not.EqualTo(hashedPassword2)); 
    }
    
    [Test]
    public void GivenCompatibilityModeIsIdentityV3_WhenHashPasswordTwice_ThenHashesAreDifferent()
    {
        var passwordHasherOptions = new PasswordHasherOptions
        {
            CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3
        };
        var options = new OptionsWrapper<PasswordHasherOptions>(passwordHasherOptions);
        var sut = new PasswordHasher<RegisteredUser>(options);

        var hashedPassword1 = sut.HashPassword(null, "password");
        var hashedPassword2 = sut.HashPassword(null, "password");

        Assert.That(hashedPassword1, Is.Not.EqualTo(hashedPassword2)); 
    }
    
    [TestCase("password", "ANh5EtY9N5SXAgjEj2yhA0uGl8S2t+hEG8IQOi+/FweV8s1xtPm7TR27lI92dKNTsw==", true)]
    [TestCase("password", "ACc9dvQUOxP820IyFUBAXtOdCSdb/viylOpl1zSf2Tp7f1dvt720z+JbWNCFV+rtZg==", false)]
    public void GivenCompatibilityModeIsIdentityV2_WhenVerifyingPassword_ThenCorrectResultIsReturned(string password, string passwordHash, bool isValid)
    {
        var passwordHasherOptions = new PasswordHasherOptions
        {
            CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV2
        };
        var options = new OptionsWrapper<PasswordHasherOptions>(passwordHasherOptions);
        var sut = new PasswordHasher<RegisteredUser>(options);

        var result = sut.VerifyHashedPassword(null, passwordHash, password);

        Assert.That(result == PasswordVerificationResult.Success, Is.EqualTo(isValid)); 
    }
    
    [TestCase("password", "AQAAAAIAAYagAAAAEALAA/Jpx289ySs71Q7nmrkY4XuPtsM7YLNQAnfCuPT5gbPACr1+8dlOphcc20MqdQ==", true)]
    [TestCase("password", "AQAAAAIAAYagAAAAELA2pZe27jHKk3hy2gio2x9AwNOO28Iame+RDTQtroryHxu+Ouxp+9m1dU920LDCDQ==", false)]
    public void GivenCompatibilityModeIsIdentityV3_WhenVerifyingPassword_ThenCorrectResultIsReturned(string password, string passwordHash, bool isValid)
    {
        var passwordHasherOptions = new PasswordHasherOptions
        {
            CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3
        };
        var options = new OptionsWrapper<PasswordHasherOptions>(passwordHasherOptions);
        var sut = new PasswordHasher<RegisteredUser>(options);

        var result = sut.VerifyHashedPassword(null, passwordHash, password);

        Assert.That(result == PasswordVerificationResult.Success, Is.EqualTo(isValid)); 
    }
}