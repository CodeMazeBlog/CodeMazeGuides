using AutoMapper;
using FanIn_Fan_out.Shared.Application.DataObjects;
using FanIn_Fan_out.Shared.Domain.Models;

namespace DTS_Project.Application.Configurations.Helpers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<SalesOrderDetail, SalesOrderDetailDTO>().ReverseMap();
    }
}