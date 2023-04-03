using System;
using AutoMapper;
using RequestBodyRead.Entities.Models;
using RequestBodyRead.Repository;
using RequestBodyRead.Service.Contracts;
using RequestBodyRead.Shared.DataTransferObjects;

namespace RequestBodyRead.Service
{
	public class UserService : IUserService
	{
		private readonly IMapper _mapper;

		public UserService(IMapper mapper)
		{
			_mapper = mapper;
		}

		public IEnumerable<UserDto> GetUsers()
		{
			var users = DataBaseMockup.Users;
			var usersDto = _mapper.Map<IEnumerable<UserDto>>(users);

			return usersDto;
		}

		public UserDto GetUser(Guid guid)
		{
			var user = DataBaseMockup.Users.Where(u => u.Id == guid)
				.FirstOrDefault();
			var userDto = _mapper.Map<UserDto>(user);

			return userDto;
		}

		public UserDto CreateUser(UserForCreationAndUpdateDto user)
		{
			var newUser = new User
			{
                Id = Guid.NewGuid(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };

			DataBaseMockup.Users.Add(newUser);
			var newUserDto = _mapper.Map<UserDto>(newUser);

			return newUserDto;
		}

		public(List<UserDto> users, string ids) CreateUserCollection(List<UserForCreationAndUpdateDto> users)
		{
			// ADD GUARD CLAUSE
			var newUsersDtos = new List<UserDto>();

			foreach (var user in users)
			{
				var newUser = CreateUser(user);
				newUsersDtos.Add(newUser);
			}

			var ids = string.Join(",", newUsersDtos.Select(u => u.Id));
			return (users: newUsersDtos, ids: ids);
		}

		public List<UserDto> GetByIds(IEnumerable<Guid> ids)
		{
			if (ids is null)
				throw new Exception("List of ids cannot be null");

			// TODO: look @ EBR code to see if this can be refactored to LINQ
			var userEntities = DataBaseMockup.Users.Where(u => ids.Contains(u.Id));

			var usersToReturn = _mapper.Map<List<UserDto>>(userEntities);

			return usersToReturn;
		}

		public UserDto UpdateUser(Guid id, UserForCreationAndUpdateDto user)
		{
			var userIfExists = DataBaseMockup.Users.Where(u => u.Id == id).FirstOrDefault();

			User newOrUpdateUser;

			if (userIfExists is null)
			{
				newOrUpdateUser = new User
				{
					Id = id,
					FirstName = user.FirstName,
					LastName = user.LastName,
					Email = user.Email
				};

				DataBaseMockup.Users.Add(newOrUpdateUser);
			}
			else
			{
				newOrUpdateUser = userIfExists;

				newOrUpdateUser.FirstName = user.FirstName;
				newOrUpdateUser.LastName = user.LastName;
				newOrUpdateUser.Email = user.Email;
			}

			var newOrUpdateUserDto = _mapper.Map<UserDto>(newOrUpdateUser);

			return newOrUpdateUserDto;
		}
	}
}

