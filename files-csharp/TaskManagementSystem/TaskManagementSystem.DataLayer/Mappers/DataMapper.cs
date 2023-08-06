using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagementSystem.DataLayer.Dtos;
using TaskManagementSystem.DataLayer.Entities;

namespace TaskManagementSystem.DataLayer.Mappers
{
    internal class DataMapper : Profile
    {
        public DataMapper() 
        {
            CreateMap<UserTaskDto, UserTask>().ReverseMap();
        }
    }
}
