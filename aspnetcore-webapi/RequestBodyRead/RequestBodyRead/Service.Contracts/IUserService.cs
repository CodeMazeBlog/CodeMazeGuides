using System;
using Microsoft.AspNetCore.Mvc;
using RequestBodyRead.Shared.DataTransferObjects;

namespace RequestBodyRead.Service.Contracts
{
	public interface IUserService
	{
        public IEnumerable<UserDto> GetUsers();

        public UserDto GetUser(Guid guid);

        public List<UserDto> GetByIds(IEnumerable<Guid> ids);

        public UserDto CreateUser(UserForCreationAndUpdateDto user);

        public (List<UserDto> users, string ids) CreateUserCollection(List<UserForCreationAndUpdateDto> users);

        public UserDto UpdateUser(Guid id, UserForCreationAndUpdateDto user);
    }
}   

    