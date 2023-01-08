using System;
using Services;
using Services.Models;

namespace AsynchronousProgrammingModel.Providers
{
    public class UserProvider
    {
        private readonly Func<int, User> _getUserFunc;
        private readonly UserService _userService;

        public UserProvider()
        {
            _getUserFunc = GetUser;
            _userService = new UserService();
        }

        public User GetUser(int userId) => _userService.GetUser(userId);

        public IAsyncResult BeginGetUser(int userId, AsyncCallback callback, object state)
        {
            return _getUserFunc.BeginInvoke(userId, callback, state);
        }

        public User EndGetUser(IAsyncResult asyncResult)
        {
            return _getUserFunc.EndInvoke(asyncResult);
        }
    }
}
