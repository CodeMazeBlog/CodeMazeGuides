using Contracts;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;
using Services.Abstractions;

namespace Services;

internal sealed class CatService(IRepositoryManager repositoryManager) : ICatService
{
    public async Task<CatDto> CreateAsync(CatForCreationDto catForCreationDto, CancellationToken cancellationToken = default)
    {
        var cat = new Cat
        {
            Id = Guid.NewGuid(),
            Name = catForCreationDto.Name,
            Breed = catForCreationDto.Breed,
            DateOfBirth = catForCreationDto.DateOfBirth,
        };

        repositoryManager.CatRepository.Insert(cat);

        await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

        return new CatDto
        {
            Id = cat.Id,
            Name = cat.Name,
            Breed = cat.Breed,
            DateOfBirth = cat.DateOfBirth,
        };
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var cat = await repositoryManager.CatRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new CatNotFoundException(id);

        repositoryManager.CatRepository.Remove(cat);

        await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<CatDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var cats = await repositoryManager.CatRepository.GetAllAsync(cancellationToken);

        var catDtos = new List<CatDto>();

        foreach (var cat in cats)
        {
            catDtos.Add(new CatDto
            {
                Id = cat.Id,
                Name = cat.Name,
                Breed = cat.Breed,
                DateOfBirth = cat.DateOfBirth
            });
        }

        return catDtos;
    }

    public async Task<CatDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var cat = await repositoryManager.CatRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new CatNotFoundException(id);

        return new CatDto
        {
            Id = cat.Id,
            Name = cat.Name,
            Breed = cat.Breed,
            DateOfBirth = cat.DateOfBirth
        };
    }

    public async Task UpdateAsync(Guid id, CatForUpdateDto catForUpdateDto, CancellationToken cancellationToken = default)
    {
        var cat = await repositoryManager.CatRepository.GetByIdAsync(id, cancellationToken)
            ?? throw new CatNotFoundException(id);

        cat.Name = catForUpdateDto.Name;
        cat.Breed = catForUpdateDto.Breed;
        cat.DateOfBirth = catForUpdateDto.DateOfBirth;

        await repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
    }
}
