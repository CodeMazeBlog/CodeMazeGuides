using MediatR;
using PublishVsSendInMediatR.Commands;
using PublishVsSendInMediatR.Models;
using PublishVsSendInMediatR.Repositories;

namespace PublishVsSendInMediatR.CommandHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository) =>
            _userRepository = userRepository;

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User { UserName = request.UserName, Email = request.Email };

            return await _userRepository.CreateUserAsync(user);
        }
    }
}
