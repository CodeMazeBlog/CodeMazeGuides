using System.ComponentModel.DataAnnotations;

namespace WebApiBestPractices.Application.Dtos;

public record OwnerDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public string? Address { get; init; }
}

public record OwnerForCreationDto
{
    [Required, MaxLength(60)]
    public string Name { get; init; } = string.Empty;

    [Required, EmailAddress]
    public string Email { get; init; } = string.Empty;

    [MaxLength(100)]
    public string? Address { get; init; }
}

public record OwnerForUpdateDto
{
    [Required, MaxLength(60)]
    public string Name { get; init; } = string.Empty;

    [MaxLength(100)]
    public string? Address { get; init; }
}
