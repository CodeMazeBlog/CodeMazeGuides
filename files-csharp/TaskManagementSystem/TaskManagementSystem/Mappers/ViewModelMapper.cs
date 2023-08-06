using AutoMapper;
using TaskManagementSystem.DataLayer.Dtos;
using TaskManagementSystem.ViewModels;

namespace TaskManagementSystem.Mappers
{
    public class ViewModelMapper : Profile
    {
        public ViewModelMapper() 
        {
            CreateMap<UserTaskViewModel, UserTaskDto>();
        }    
    }
}
