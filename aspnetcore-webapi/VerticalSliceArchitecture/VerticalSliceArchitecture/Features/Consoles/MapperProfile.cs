using AutoMapper;
using VerticalSliceArchitecture.Domain;

namespace VerticalSliceArchitecture.Features.Consoles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<GameConsole, GetAllConsoles.ConsoleResult>();
        }
    }
}
