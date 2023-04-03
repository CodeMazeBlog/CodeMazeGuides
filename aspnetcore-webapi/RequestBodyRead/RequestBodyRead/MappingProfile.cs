using System;
using AutoMapper;
using RequestBodyRead.Entities.Models;
using RequestBodyRead.Shared.DataTransferObjects;

namespace RequestBodyRead
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<User, UserDto>();
		}
	}
}

