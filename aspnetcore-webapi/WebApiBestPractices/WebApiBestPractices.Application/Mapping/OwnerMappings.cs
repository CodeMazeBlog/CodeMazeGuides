using WebApiBestPractices.Application.Dtos;
using WebApiBestPractices.Domain.Entities;

namespace WebApiBestPractices.Application.Mapping;

public static class OwnerMappings
{
    public static OwnerDto ToDto(this Owner owner) => new()
    {
        Id = owner.Id,
        Name = owner.Name,
        Email = owner.Email,
        Address = owner.Address
    };

    public static Owner ToEntity(this OwnerForCreationDto dto) => new()
    {
        Id = Guid.NewGuid(),
        Name = dto.Name,
        Email = dto.Email,
        Address = dto.Address
    };
}
