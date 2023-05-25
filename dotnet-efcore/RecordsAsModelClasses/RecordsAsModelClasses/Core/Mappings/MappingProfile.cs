using AutoMapper;
using RecordsAsModelClasses.Core.DTOs;
using RecordsAsModelClasses.Core.Entities.Records;

namespace RecordsAsModelClasses.Core.Mappings;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<UpsertCarDto, Entities.Classes.Car>();
        CreateMap<UpsertCarDto, Entities.Records.Car>();

        CreateMap<Entities.Records.Car, CarDto>();
        CreateMap<Entities.Classes.Car, CarDto>();
    }
}